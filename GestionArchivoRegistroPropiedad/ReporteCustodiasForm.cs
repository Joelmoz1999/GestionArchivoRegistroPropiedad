using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class ReporteCustodiasForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;

        public ReporteCustodiasForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public ReporteCustodiasForm() { InitializeComponent(); }

        private void ReporteCustodiasForm_Load(object sender, EventArgs e)
        {
            dgvReporte.AutoGenerateColumns = true;
            dgvReporte.ReadOnly = true;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.MultiSelect = false;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new object[] { "Todos", "En Custodia", "Devueltos" });
            cmbEstado.SelectedIndex = 0;

            CargarFuncionarios();

            dtpDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;

            GenerarReporte();
        }

        private void CargarFuncionarios()
        {
            try
            {
                _context.ChangeTracker.Clear();
                var funcionarios = _context.Funcionarios
                    .AsNoTracking()
                    .OrderBy(f => f.Apellidos)
                    .Select(f => new
                    {
                        f.FuncionarioId,
                        NombreCompleto = f.Nombres + " " + f.Apellidos
                    })
                    .ToList();

                var lista = new List<object> { new { FuncionarioID = 0, NombreCompleto = "--- Todos ---" } };
                foreach (var f in funcionarios) lista.Add(f);

                cmbFuncionario.DataSource = lista;
                cmbFuncionario.DisplayMember = "NombreCompleto";
                cmbFuncionario.ValueMember = "FuncionarioID";
                cmbFuncionario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar funcionarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkUsarFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkUsarFechas.Checked;
            dtpHasta.Enabled = chkUsarFechas.Checked;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                _context.ChangeTracker.Clear();

                string estado = cmbEstado.SelectedItem?.ToString() ?? "Todos";
                int funcionarioID = cmbFuncionario.SelectedValue is int id ? id : 0;
                bool usarFechas = chkUsarFechas.Checked;
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

                var query = from c in _context.Custodias.AsNoTracking()
                            join l in _context.Libros.AsNoTracking() on c.LibroId equals l.LibroId
                            join f in _context.Funcionarios.AsNoTracking() on c.FuncionarioId equals f.FuncionarioId
                            select new
                            {
                                c.CustodiaId,
                                l.CodigoBarras,
                                l.TipoLibro,
                                Funcionario = f.Nombres + " " + f.Apellidos,
                                CedulaFuncionario = f.Cedula,
                                c.FechaEntrega,
                                c.FechaDevolucion,
                                Estado = c.FechaDevolucion == null ? "En Custodia" : "Devuelto",
                                c.ObservacionesEntrega,
                                c.ObservacionesDevolucion
                            };

                if (estado == "En Custodia")
                    query = query.Where(x => x.FechaDevolucion == null);
                else if (estado == "Devueltos")
                    query = query.Where(x => x.FechaDevolucion != null);

                if (funcionarioID > 0)
                {
                    var cedulaFunc = _context.Funcionarios
                        .Where(f => f.FuncionarioId == funcionarioID)
                        .Select(f => f.Cedula).FirstOrDefault();
                    query = query.Where(x => x.CedulaFuncionario == cedulaFunc);
                }

                if (usarFechas)
                    query = query.Where(x => x.FechaEntrega >= desde && x.FechaEntrega <= hasta);

                var resultado = query.OrderByDescending(x => x.FechaEntrega).ToList();

                dgvReporte.DataSource = resultado;

                if (dgvReporte.Columns["CustodiaID"] != null)
                    dgvReporte.Columns["CustodiaID"].Visible = false;
                if (dgvReporte.Columns["CodigoBarras"] != null)
                    dgvReporte.Columns["CodigoBarras"].HeaderText = "Código";
                if (dgvReporte.Columns["TipoLibro"] != null)
                    dgvReporte.Columns["TipoLibro"].HeaderText = "Tipo";
                if (dgvReporte.Columns["CedulaFuncionario"] != null)
                    dgvReporte.Columns["CedulaFuncionario"].HeaderText = "Cédula";
                if (dgvReporte.Columns["FechaEntrega"] != null)
                    dgvReporte.Columns["FechaEntrega"].HeaderText = "F. Entrega";
                if (dgvReporte.Columns["FechaDevolucion"] != null)
                    dgvReporte.Columns["FechaDevolucion"].HeaderText = "F. Devolución";

                int total = resultado.Count;
                int enCust = resultado.Count(x => x.Estado == "En Custodia");
                int dev = resultado.Count(x => x.Estado == "Devuelto");

                lblTotales.Text = $"Total: {total} | En Custodia: {enCust} | Devueltos: {dev}";

                foreach (DataGridViewRow row in dgvReporte.Rows)
                {
                    string est = row.Cells["Estado"].Value?.ToString() ?? "";
                    row.DefaultCellStyle.BackColor = est == "En Custodia"
                        ? System.Drawing.Color.LightYellow
                        : System.Drawing.Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "PDF|*.pdf",
                FileName = $"Reporte_Libros_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var dt = ReporteHelper.ConvertirDataGridViewADataTable(dgvReporte);

                QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(30);
                        page.DefaultTextStyle(x => x.FontSize(9));

                        page.Header().Column(col =>
                        {
                            col.Item().Text("REGISTRO DE LA PROPIEDAD - PEDRO VICENTE MALDONADO").Bold().FontSize(14);
                            col.Item().Text("Reporte de Libros").FontSize(11);
                            col.Item().Text($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}")
                                .FontSize(8).FontColor(Colors.Grey.Darken2);
                            col.Item().Text(lblTotales.Text).FontSize(9).Bold();
                        });

                        page.Content().PaddingVertical(10).Table(table =>
                        {
                            // Definir columnas según el DataTable
                            table.ColumnsDefinition(cols =>
                            {
                                foreach (DataColumn c in dt.Columns)
                                    cols.RelativeColumn();
                            });

                            // Encabezados
                            table.Header(h =>
                            {
                                foreach (DataColumn c in dt.Columns)
                                    h.Cell().Background(Colors.Grey.Lighten2).Padding(3).Text(c.ColumnName).Bold();
                            });

                            // Filas
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn c in dt.Columns)
                                    table.Cell().Padding(2).Text(row[c]?.ToString() ?? "");
                            }
                        });

                        page.Footer().AlignCenter().Text(t =>
                        {
                            t.Span("Página ");
                            t.CurrentPageNumber();
                            t.Span(" de ");
                            t.TotalPages();
                        });
                    });
                }).GeneratePdf(sfd.FileName);

                MessageBox.Show($"PDF generado correctamente:\n{sfd.FileName}", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = sfd.FileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos vacíos
        private void lblEstado_Click(object sender, EventArgs e) { }
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblFuncionario_Click(object sender, EventArgs e) { }
        private void cmbFuncionario_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblDesde_Click(object sender, EventArgs e) { }
        private void dtpDesde_ValueChanged(object sender, EventArgs e) { }
        private void lblHasta_Click(object sender, EventArgs e) { }
        private void dtpHasta_ValueChanged(object sender, EventArgs e) { }
        private void lblTotales_Click(object sender, EventArgs e) { }
        private void dgvReporte_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}