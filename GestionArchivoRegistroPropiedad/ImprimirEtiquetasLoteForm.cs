using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace GestionArchivoRegistroPropiedad
{
    public partial class mnuImprimirEtiquetas : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private List<EtiquetaImpresion> _etiquetasAImprimir = new();
        private int _indiceImpresion = 0;

        public mnuImprimirEtiquetas(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public mnuImprimirEtiquetas() { InitializeComponent(); }

        private void ImprimirEtiquetasLoteForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Configurar grilla
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = true;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.AutoGenerateColumns = false;

            // Definir columnas
            ConfigurarColumnasGrilla();

            // Cargar tipos desde la base de datos
            cmbFiltroTipo.Items.Clear();
            cmbFiltroTipo.Items.Add("TODOS");
            cmbFiltroTipo.Items.AddRange(TiposLibrosHelper.ObtenerTiposActivos(_context).ToArray());
            cmbFiltroTipo.SelectedIndex = 0;

            CargarLibros("TODOS");
        }

        private void ConfigurarColumnasGrilla()
        {
            dgvLibros.Columns.Clear();

            dgvLibros.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Seleccionar",
                HeaderText = "✓",
                Width = 40
            });

            dgvLibros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LibroID",
                Visible = false
            });

            dgvLibros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodigoBarras",
                HeaderText = "Código",
                ReadOnly = true
            });

            dgvLibros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoLibro",
                HeaderText = "Tipo",
                ReadOnly = true
            });

            dgvLibros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Anio",
                HeaderText = "Año",
                ReadOnly = true
            });

            dgvLibros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tomo",
                HeaderText = "Tomo",
                ReadOnly = true
            });

            dgvLibros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PartidaInicial",
                HeaderText = "P. Inicial",
                ReadOnly = true
            });

            dgvLibros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PartidaFinal",
                HeaderText = "P. Final",
                ReadOnly = true
            });
        }

        private void CargarLibros(string tipoFiltro, string codigoFiltro = "")
        {
            try
            {
                _context.ChangeTracker.Clear();

                var query = _context.Libros.AsNoTracking().AsQueryable();

                if (tipoFiltro != "TODOS")
                    query = query.Where(l => l.TipoLibro == tipoFiltro);

                if (!string.IsNullOrWhiteSpace(codigoFiltro))
                    query = query.Where(l => l.CodigoBarras.Contains(codigoFiltro));

                var libros = query
                    .OrderBy(l => l.TipoLibro)
                    .ThenByDescending(l => l.Anio)
                    .ThenBy(l => l.Tomo)
                    .Select(l => new
                    {
                        l.LibroId,
                        l.CodigoBarras,
                        l.TipoLibro,
                        l.Anio,
                        l.Tomo,
                        l.PartidaInicial,
                        l.PartidaFinal
                    })
                    .ToList();

                dgvLibros.Rows.Clear();

                foreach (var libro in libros)
                {
                    int index = dgvLibros.Rows.Add();
                    dgvLibros.Rows[index].Cells["Seleccionar"].Value = false;
                    dgvLibros.Rows[index].Cells["LibroID"].Value = libro.LibroId;
                    dgvLibros.Rows[index].Cells["CodigoBarras"].Value = libro.CodigoBarras;
                    dgvLibros.Rows[index].Cells["TipoLibro"].Value = libro.TipoLibro;
                    dgvLibros.Rows[index].Cells["Anio"].Value = libro.Anio;
                    dgvLibros.Rows[index].Cells["Tomo"].Value = libro.Tomo;
                    dgvLibros.Rows[index].Cells["PartidaInicial"].Value = libro.PartidaInicial;
                    dgvLibros.Rows[index].Cells["PartidaFinal"].Value = libro.PartidaFinal;
                }

                ActualizarTotalSeleccionados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTotalSeleccionados()
        {
            int total = 0;
            foreach (DataGridViewRow row in dgvLibros.Rows)
            {
                if (row.Cells["Seleccionar"].Value is bool b && b)
                    total++;
            }

            lblTotalSeleccionados.Text = $"Seleccionados: {total}";
            btnImprimirSeleccionados.Enabled = total > 0;
        }

        private void dgvLibros_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLibros.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                ActualizarTotalSeleccionados();
            }
        }

        private void dgvLibros_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLibros.IsCurrentCellDirty)
                dgvLibros.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            string tipo = cmbFiltroTipo.SelectedItem?.ToString() ?? "TODOS";
            CargarLibros(tipo, txtFiltroCodigo.Text.Trim());
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cmbFiltroTipo.SelectedIndex = 0;
            txtFiltroCodigo.Clear();
            CargarLibros("TODOS");
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvLibros.Rows)
                row.Cells["Seleccionar"].Value = true;

            ActualizarTotalSeleccionados();
        }

        private void btnDeseleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvLibros.Rows)
                row.Cells["Seleccionar"].Value = false;

            ActualizarTotalSeleccionados();
        }

        private void btnImprimirSeleccionados_Click(object sender, EventArgs e)
        {
            try
            {
                _etiquetasAImprimir.Clear();

                foreach (DataGridViewRow row in dgvLibros.Rows)
                {
                    if (row.Cells["Seleccionar"].Value is bool b && b)
                    {
                        var etiqueta = new EtiquetaImpresion
                        {
                            Codigo = row.Cells["CodigoBarras"].Value?.ToString() ?? "",
                            Tipo = row.Cells["TipoLibro"].Value?.ToString() ?? "",
                            Anio = row.Cells["Anio"].Value?.ToString() ?? "",
                            Tomo = row.Cells["Tomo"].Value?.ToString() ?? "",
                            PartidaInicial = row.Cells["PartidaInicial"].Value?.ToString() ?? "",
                            PartidaFinal = row.Cells["PartidaFinal"].Value?.ToString() ?? ""
                        };

                        etiqueta.ImagenCodigo = GenerarImagenCodigoBarras(etiqueta.Codigo);
                        _etiquetasAImprimir.Add(etiqueta);
                    }
                }

                if (_etiquetasAImprimir.Count == 0)
                {
                    MessageBox.Show("No hay etiquetas seleccionadas.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"¿Imprimir {_etiquetasAImprimir.Count} etiquetas?",
                    "Confirmar impresión",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                var printDoc = new PrintDocument();
                printDoc.DocumentName = "Etiquetas en lote";
                printDoc.DefaultPageSettings.PaperSize = new PaperSize("Etiqueta", 500, 300);
                printDoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

                _indiceImpresion = 0;
                printDoc.PrintPage += PrintDoc_PrintPage;

                using var printDialog = new PrintDialog
                {
                    Document = printDoc,
                    UseEXDialog = true
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    MessageBox.Show($"{_etiquetasAImprimir.Count} etiquetas enviadas a la impresora.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_indiceImpresion >= _etiquetasAImprimir.Count)
            {
                e.HasMorePages = false;
                return;
            }

            var etiqueta = _etiquetasAImprimir[_indiceImpresion];
            var g = e.Graphics!;

            float x = 10;
            float y = 10;

            using var fontTitulo = new Font("Arial", 8, FontStyle.Bold);
            using var fontNormal = new Font("Arial", 7);
            using var fontCodigo = new Font("Consolas", 8, FontStyle.Bold);

            g.DrawString("REGISTRO DE LA PROPIEDAD", fontTitulo, Brushes.Black, x, y);
            y += 15;
            g.DrawString("Pedro Vicente Maldonado", fontNormal, Brushes.Black, x, y);
            y += 15;
            g.DrawLine(Pens.Black, x, y, x + 470, y);
            y += 5;

            g.DrawString($"Tipo: {etiqueta.Tipo}", fontNormal, Brushes.Black, x, y);
            y += 15;
            g.DrawString($"Año: {etiqueta.Anio}   Tomo: {etiqueta.Tomo}", fontNormal, Brushes.Black, x, y);
            y += 15;
            g.DrawString($"Partidas: {etiqueta.PartidaInicial} - {etiqueta.PartidaFinal}",
                fontNormal, Brushes.Black, x, y);
            y += 20;

            if (etiqueta.ImagenCodigo != null)
            {
                int anchoImg = 300;
                int altoImg = 80;
                float xCentrado = x + (470 - anchoImg) / 2;
                g.DrawImage(etiqueta.ImagenCodigo, xCentrado, y, anchoImg, altoImg);
                y += altoImg + 5;
            }

            SizeF tamTexto = g.MeasureString(etiqueta.Codigo, fontCodigo);
            float xTexto = x + (470 - tamTexto.Width) / 2;
            g.DrawString(etiqueta.Codigo, fontCodigo, Brushes.Black, xTexto, y);

            _indiceImpresion++;
            e.HasMorePages = _indiceImpresion < _etiquetasAImprimir.Count;
        }

        private Image GenerarImagenCodigoBarras(string contenido)
        {
            var writer = new ZXing.Windows.Compatibility.BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = 100,
                    Width = 300,
                    Margin = 5,
                    PureBarcode = false
                },
                Renderer = new ZXing.Windows.Compatibility.BitmapRenderer()
            };

            return writer.Write(contenido);
        }

        private class EtiquetaImpresion
        {
            public string Codigo { get; set; } = "";
            public string Tipo { get; set; } = "";
            public string Anio { get; set; } = "";
            public string Tomo { get; set; } = "";
            public string PartidaInicial { get; set; } = "";
            public string PartidaFinal { get; set; } = "";
            public Image? ImagenCodigo { get; set; }
        }

        // Métodos vacíos
        private void lblFiltroTipo_Click(object sender, EventArgs e) { }
        private void cmbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblFiltroCodigo_Click(object sender, EventArgs e) { }
        private void txtFiltroCodigo_TextChanged(object sender, EventArgs e) { }
        private void lblTotalSeleccionados_Click(object sender, EventArgs e) { }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}