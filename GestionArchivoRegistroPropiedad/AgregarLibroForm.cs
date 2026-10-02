using System;
using System.Collections.Generic;
using GestionArchivoRegistroPropiedad.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace GestionArchivoRegistroPropiedad
{
    public partial class AgregarLibroForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private readonly string[] _tiposLibros = { "Propiedad", "Sentencias", "Protocolos", "Poderes", "Hipotecas", "Otros" };

        public AgregarLibroForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public AgregarLibroForm() { InitializeComponent(); }

        private void AgregarLibroForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            cmbTipoLibro.Items.Clear();
            cmbTipoLibro.Items.AddRange(_tiposLibros);
            cmbTipoLibro.SelectedIndex = 0;

            numAnio.Minimum = 1900;
            numAnio.Maximum = 2100;
            numAnio.Value = DateTime.Now.Year;

            numTomo.Minimum = 1;
            numTomo.Maximum = 9999;
            numTomo.Value = 1;

            numPartidaIni.Minimum = 1;
            numPartidaIni.Maximum = 9999999;
            numPartidaIni.Value = 1;

            numPartidaFin.Minimum = 1;
            numPartidaFin.Maximum = 9999999;
            numPartidaFin.Value = 1;
        }

        private void btnGenerarVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoEjemplo = GenerarCodigoBarrasString(
                    cmbTipoLibro.SelectedItem?.ToString() ?? "PROP",
                    (int)numAnio.Value,
                    (int)numTomo.Value);

                txtCodigoBarras.Text = codigoEjemplo;
                picCodigoBarras.Image = GenerarImagenCodigoBarras(codigoEjemplo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar vista previa: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private string GenerarCodigoBarrasString(string tipo, int anio, int tomo)
        {
            string prefijoTipo = tipo.Length >= 4
                ? tipo.Substring(0, 4).ToUpper()
                : tipo.ToUpper().PadRight(4, 'X');

            int secuencial = _context.Libros.Count(l =>
                l.TipoLibro == tipo && l.Anio == anio && l.Tomo == tomo) + 1;

            return $"{prefijoTipo}-{anio}-{tomo:D3}-{secuencial:D4}";
        }

        private string GenerarCodigoBarrasUnico(string tipo, int anio, int tomo)
        {
            string codigo = GenerarCodigoBarrasString(tipo, anio, tomo);
            int intentos = 0;

            while (_context.Libros.Any(l => l.CodigoBarras == codigo) && intentos < 100)
            {
                intentos++;
                string prefijoTipo = tipo.Length >= 4
                    ? tipo.Substring(0, 4).ToUpper()
                    : tipo.ToUpper().PadRight(4, 'X');

                int totalExistentes = _context.Libros.Count(l =>
                    l.TipoLibro == tipo && l.Anio == anio && l.Tomo == tomo);

                codigo = $"{prefijoTipo}-{anio}-{tomo:D3}-{(totalExistentes + intentos + 1):D4}";
            }

            return codigo;
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

        // Métodos vacíos para eventos huérfanos
        private void lblTipo_Click(object sender, EventArgs e) { }
        private void cmbTipoLibro_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblAnio_Click(object sender, EventArgs e) { }
        private void numAnio_ValueChanged(object sender, EventArgs e) { }
        private void lblTomo_Click(object sender, EventArgs e) { }
        private void numTomo_ValueChanged(object sender, EventArgs e) { }
        private void lblPartidaIni_Click(object sender, EventArgs e) { }
        private void numPartidaIni_ValueChanged(object sender, EventArgs e) { }
        private void lblPartidaFin_Click(object sender, EventArgs e) { }
        private void numPartidaFin_ValueChanged(object sender, EventArgs e) { }
        private void lblObservacion_Click(object sender, EventArgs e) { }
        private void txtObservacion_TextChanged(object sender, EventArgs e) { }
        private void lblCodigoBarras_Click(object sender, EventArgs e) { }
        private void txtCodigoBarras_TextChanged(object sender, EventArgs e) { }
        private void picCodigoBarras_Click(object sender, EventArgs e) { }

        private void bntGuardarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoLibro.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de libro.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numPartidaFin.Value < numPartidaIni.Value)
                {
                    MessageBox.Show("La Partida Final no puede ser menor que la Partida Inicial.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = cmbTipoLibro.SelectedItem.ToString()!;
                int anio = (int)numAnio.Value;
                int tomo = (int)numTomo.Value;

                bool existe = _context.Libros.Any(l =>
                    l.TipoLibro == tipo && l.Anio == anio && l.Tomo == tomo);

                if (existe)
                {
                    MessageBox.Show($"Ya existe un libro de tipo '{tipo}' del año {anio} con el tomo {tomo}.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string codigoBarras = GenerarCodigoBarrasUnico(tipo, anio, tomo);

                var nuevoLibro = new Libro
                {
                    TipoLibro = tipo,
                    Anio = anio,
                    Tomo = tomo,
                    PartidaInicial = (int)numPartidaIni.Value,
                    PartidaFinal = (int)numPartidaFin.Value,
                    Observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim(),
                    CodigoBarras = codigoBarras,
                    Estado = "Disponible",
                    FechaRegistro = DateTime.Now
                };

                _context.Libros.Add(nuevoLibro);
                _context.SaveChanges();

                txtCodigoBarras.Text = codigoBarras;
                picCodigoBarras.Image = GenerarImagenCodigoBarras(codigoBarras);

                MessageBox.Show($"¡Libro guardado correctamente!\n\nCódigo de Barras: {codigoBarras}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
          
            cmbTipoLibro.SelectedIndex = 0;
            numAnio.Value = DateTime.Now.Year;
            numTomo.Value = 1;
            numPartidaIni.Value = 1;
            numPartidaFin.Value = 1;
            txtObservacion.Clear();
            txtCodigoBarras.Clear();
            picCodigoBarras.Image = null;
        
    }
    }
}