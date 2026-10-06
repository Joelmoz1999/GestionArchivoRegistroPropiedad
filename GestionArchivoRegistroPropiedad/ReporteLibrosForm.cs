using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class ReporteLibrosForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;

        public ReporteLibrosForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public ReporteLibrosForm() { InitializeComponent(); }

        private void ReporteLibrosForm_Load(object sender, EventArgs e)
        {
            // Configurar grilla
            dgvReporte.AutoGenerateColumns = true;
            dgvReporte.ReadOnly = true;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.MultiSelect = false;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargar tipos desde la base de datos
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("TODOS");
            cmbTipo.Items.AddRange(TiposLibrosHelper.ObtenerTiposActivos(_context).ToArray());
            cmbTipo.SelectedIndex = 0;

            // Fechas por defecto
            dtpDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpHasta.Value = DateTime.Now;

            // Deshabilitar fechas si no está marcado el check
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;

            GenerarReporte();
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

                string tipo = cmbTipo.SelectedItem?.ToString() ?? "TODOS";
                bool usarFechas = chkUsarFechas.Checked;
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

                var query = _context.Libros.AsNoTracking().AsQueryable();

                if (tipo != "TODOS")
                    query = query.Where(l => l.TipoLibro == tipo);

                if (usarFechas)
                    query = query.Where(l => l.FechaRegistro >= desde && l.FechaRegistro <= hasta);

                var resultado = query
                    .Select(l => new
                    {
                        l.CodigoBarras,
                        l.TipoLibro,
                        l.Anio,
                        l.Tomo,
                        l.PartidaInicial,
                        l.PartidaFinal,
                        l.Estado,
                        Observacion = l.Observacion ?? "",
                        FechaRegistro = l.FechaRegistro
                    })
                    .OrderBy(l => l.TipoLibro)
                    .ThenByDescending(l => l.Anio)
                    .ThenBy(l => l.Tomo)
                    .ToList();

                dgvReporte.DataSource = resultado;

                if (dgvReporte.Columns["CodigoBarras"] != null)
                    dgvReporte.Columns["CodigoBarras"].HeaderText = "Código";
                if (dgvReporte.Columns["TipoLibro"] != null)
                    dgvReporte.Columns["TipoLibro"].HeaderText = "Tipo";
                if (dgvReporte.Columns["PartidaInicial"] != null)
                    dgvReporte.Columns["PartidaInicial"].HeaderText = "P. Inicial";
                if (dgvReporte.Columns["PartidaFinal"] != null)
                    dgvReporte.Columns["PartidaFinal"].HeaderText = "P. Final";
                if (dgvReporte.Columns["FechaRegistro"] != null)
                    dgvReporte.Columns["FechaRegistro"].HeaderText = "Fecha Registro";

                int total = resultado.Count;
                int disponibles = resultado.Count(l => l.Estado == "Disponible");
                int enCustodia = resultado.Count(l => l.Estado == "En Custodia");

                lblTotales.Text = $"Total: {total} libros | Disponibles: {disponibles} | En Custodia: {enCustodia}";
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
        private void lblTipo_Click(object sender, EventArgs e) { }
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblDesde_Click(object sender, EventArgs e) { }
        private void dtpDesde_ValueChanged(object sender, EventArgs e) { }
        private void lblHasta_Click(object sender, EventArgs e) { }
        private void dtpHasta_ValueChanged(object sender, EventArgs e) { }
        private void lblTotales_Click(object sender, EventArgs e) { }
        private void dgvReporte_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        
    }
}