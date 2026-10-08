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

        private Image? _logoRegistro;

        public mnuImprimirEtiquetas(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;

            // 🔑 Conectar eventos manualmente (por si el diseñador no los tiene)
            dgvLibros.CellValueChanged += dgvLibros_CellValueChanged;
            dgvLibros.CurrentCellDirtyStateChanged += dgvLibros_CurrentCellDirtyStateChanged;
            dgvLibros.CellClick += dgvLibros_CellClick;
            dgvLibros.CellDoubleClick += dgvLibros_CellDoubleClick;
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

            _logoRegistro = Properties.Resources.LogoRPPVM3;

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
                HeaderText = "F. Inicial",
                ReadOnly = true
            });

            dgvLibros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PartidaFinal",
                HeaderText = "F. Final",
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

        // ============================================================
        // EVENTOS DEL CHECKBOX
        // ============================================================
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

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvLibros.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                bool valorActual = dgvLibros.Rows[e.RowIndex].Cells["Seleccionar"].Value is bool b && b;
                dgvLibros.Rows[e.RowIndex].Cells["Seleccionar"].Value = !valorActual;
                ActualizarTotalSeleccionados();
            }
        }

        private void dgvLibros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            bool valorActual = dgvLibros.Rows[e.RowIndex].Cells["Seleccionar"].Value is bool b && b;
            dgvLibros.Rows[e.RowIndex].Cells["Seleccionar"].Value = !valorActual;
            ActualizarTotalSeleccionados();
        }

        // ============================================================
        // BOTONES
        // ============================================================
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

                // ============================================================
                // CONFIGURAR TAMAÑO DE ETIQUETA
                // 100 mm x 180 mm => 393 x 708 (centésimas de pulgada)
                // ============================================================
                PaperSize tamanoEtiqueta = null;

                foreach (PaperSize ps in printDoc.PrinterSettings.PaperSizes)
                {
                    string nombre = ps.PaperName.ToLower();
                    if (nombre.Contains("user") || (nombre.Contains("100") && nombre.Contains("180")))
                    {
                        tamanoEtiqueta = ps;
                        break;
                    }
                }

                if (tamanoEtiqueta == null)
                {
                    tamanoEtiqueta = new PaperSize("Etiqueta100x180", 393, 708);
                }

                printDoc.DefaultPageSettings.PaperSize = tamanoEtiqueta;
                printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                printDoc.DefaultPageSettings.Landscape = false;

                _indiceImpresion = 0;
                printDoc.PrintPage += PrintDoc_PrintPage;

                using var printDialog = new PrintDialog
                {
                    Document = printDoc,
                    UseEXDialog = false
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

        // ============================================================
        // IMPRESIÓN PÁGINA POR PÁGINA
        // Contenido CENTRADO vertical y horizontalmente en la etiqueta
        // - "RPPVM" arriba, centrado sobre el código
        // - Logo a la izquierda del código
        // - Texto del código abajo, centrado
        // ============================================================
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_indiceImpresion >= _etiquetasAImprimir.Count)
            {
                e.HasMorePages = false;
                return;
            }

            var etiqueta = _etiquetasAImprimir[_indiceImpresion];
            var g = e.Graphics!;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            // Área real de la etiqueta
            float anchoEtiqueta = e.PageBounds.Width;
            float altoEtiqueta = e.PageBounds.Height;

            // Factor de conversión mm -> centésimas de pulgada
            float factor = 100f / 25.4f;

            // ============================================================
            // TAMAÑOS EN MM
            // ============================================================
            float anchoCodigoMm = 35f;
            float altoCodigoMm = 6f;

            float anchoLogoMm = 12f;
            float altoLogoMm = 12f;
            float espacioLogoMm = 1f;

            float anchoCodigo = anchoCodigoMm * factor;
            float altoCodigo = altoCodigoMm * factor;
            float anchoLogo = anchoLogoMm * factor;
            float altoLogo = altoLogoMm * factor;
            float espacio = espacioLogoMm * factor;

            // ============================================================
            // FUENTES
            // ============================================================
            using var fontTitulo = new Font("Arial", 10, FontStyle.Bold);
            using var fontCodigo = new Font("Arial", 8, FontStyle.Bold);

            string titulo = "RPPVM";
            SizeF tamTitulo = g.MeasureString(titulo, fontTitulo);
            SizeF tamTexto = g.MeasureString(etiqueta.Codigo, fontCodigo);

            // ============================================================
            // CALCULAR ALTO TOTAL DEL CONTENIDO
            // título + espacio + código + espacio + texto
            // ============================================================
            float espacioTituloCodigo = 1f;
            float espacioCodigoTexto = 1f;

            float altoContenido = tamTitulo.Height
                                + espacioTituloCodigo
                                + altoCodigo
                                + espacioCodigoTexto
                                + tamTexto.Height;

            // ============================================================
            // POSICIÓN VERTICAL: centrado en la etiqueta
            // ============================================================
            float yContenido = (altoEtiqueta - altoContenido) / 2f;

            // ============================================================
            // POSICIÓN HORIZONTAL: logo + espacio + código, centrado
            // ============================================================
            float anchoTotal = anchoLogo + espacio + anchoCodigo;
            float xInicio = (anchoEtiqueta - anchoTotal) / 2f;

            // Coordenadas X del código (a la derecha del logo)
            float xCodigo = xInicio + anchoLogo + espacio;

            // ============================================================
            // 1) TÍTULO "RPPVM" — centrado sobre el código
            // ============================================================
            float xTitulo = xCodigo + (anchoCodigo - tamTitulo.Width) / 2f;
            float yTitulo = yContenido;

            g.DrawString(titulo, fontTitulo, Brushes.Black, xTitulo, yTitulo);

            // ============================================================
            // 2) LOGO — a la izquierda del código, alineado con el código
            // ============================================================
            float yCodigo = yTitulo + tamTitulo.Height + espacioTituloCodigo;

            // 👇 el logo se centra verticalmente con el código
            float yLogo = yCodigo + (altoCodigo - altoLogo) / 2f;

            if (_logoRegistro != null)
            {
                g.DrawImage(_logoRegistro,
                    xInicio, yLogo,
                    anchoLogo, altoLogo);
            }

            // ============================================================
            // 3) CÓDIGO DE BARRAS
            // ============================================================
            if (etiqueta.ImagenCodigo != null)
            {
                g.DrawImage(etiqueta.ImagenCodigo,
                    xCodigo, yCodigo,
                    anchoCodigo, altoCodigo);

                // ============================================================
                // 4) TEXTO DEL CÓDIGO — centrado bajo el código
                // ============================================================
                float xTexto = xCodigo + (anchoCodigo - tamTexto.Width) / 2f;
                float yTexto = yCodigo + altoCodigo + espacioCodigoTexto;

                g.DrawString(etiqueta.Codigo, fontCodigo, Brushes.Black, xTexto, yTexto);
            }

            _indiceImpresion++;
            e.HasMorePages = _indiceImpresion < _etiquetasAImprimir.Count;
        }

        // ============================================================
        // GENERAR IMAGEN DEL CÓDIGO DE BARRAS (alta resolución)
        // ============================================================
        private Image GenerarImagenCodigoBarras(string contenido)
        {
            var writer = new ZXing.Windows.Compatibility.BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = 200,
                    Width = 900,
                    Margin = 0,
                    PureBarcode = true
                },
                Renderer = new ZXing.Windows.Compatibility.BitmapRenderer()
            };

            return writer.Write(contenido);
        }

        // ============================================================
        // CLASE AUXILIAR
        // ============================================================
        private class EtiquetaImpresion
        {
            public string Codigo { get; set; } = "";
            public string Tipo { get; set; } = "";
            public string Anio { get; set; } = "";
            public string Tomo { get; set; } = "";
            public string PartidaInicial { get; set; } = "";
            public string PartidaFinal { get; set; } = "";
            public Image? ImagenCodigo { get; set; }
            public Image? Logo { get; set; }
        }

        // ============================================================
        // MÉTODOS VACÍOS PARA EVENTOS HUÉRFANOS
        // ============================================================
        private void lblFiltroTipo_Click(object sender, EventArgs e) { }
        private void cmbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblFiltroCodigo_Click(object sender, EventArgs e) { }
        private void txtFiltroCodigo_TextChanged(object sender, EventArgs e) { }
        private void lblTotalSeleccionados_Click(object sender, EventArgs e) { }
        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}