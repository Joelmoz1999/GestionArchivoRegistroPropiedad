using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class EliminarLibroForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private Libro? _libroAEliminar = null;

        public EliminarLibroForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public EliminarLibroForm() { InitializeComponent(); }

        private void EliminarLibroForm_Load(object sender, EventArgs e)
        {
            if (!SesionActual.EsAdministrador)
            {
                MessageBox.Show("Solo el Administrador puede eliminar libros.",
                    "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            btnEliminar.Enabled = false;
            lblInfo.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese un código de barras.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context.ChangeTracker.Clear();

                var libro = _context.Libros.AsNoTracking()
                    .FirstOrDefault(l => l.CodigoBarras == codigo);

                if (libro == null)
                {
                    MessageBox.Show("No se encontró ningún libro con ese código.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _libroAEliminar = null;
                    btnEliminar.Enabled = false;
                    lblInfo.Text = "";
                    return;
                }

                bool enCustodia = _context.Custodias.Any(c =>
                    c.LibroId == libro.LibroId && c.FechaDevolucion == null);

                if (enCustodia)
                {
                    MessageBox.Show("Este libro está actualmente en custodia. Debe devolverse antes de poder eliminarlo.",
                        "En custodia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _libroAEliminar = null;
                    btnEliminar.Enabled = false;
                    lblInfo.Text = "";
                    return;
                }

                _libroAEliminar = libro;
                btnEliminar.Enabled = true;

                lblInfo.Text =
                    $"📖 Libro encontrado:\n" +
                    $"Código: {libro.CodigoBarras}\n" +
                    $"Tipo: {libro.TipoLibro}\n" +
                    $"Año: {libro.Anio}\n" +
                    $"Tomo: {libro.Tomo}\n" +
                    $"Partidas: {libro.PartidaInicial} - {libro.PartidaFinal}\n" +
                    $"Estado: {libro.Estado}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_libroAEliminar == null) return;

            var confirm = MessageBox.Show(
                $"⚠️ ¿Está SEGURO de eliminar este libro?\n\n" +
                $"Código: {_libroAEliminar.CodigoBarras}\n" +
                $"Tipo: {_libroAEliminar.TipoLibro} | Año: {_libroAEliminar.Anio} | Tomo: {_libroAEliminar.Tomo}\n\n" +
                $"Esta acción NO se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _context.ChangeTracker.Clear();

                var libroBD = _context.Libros.FirstOrDefault(l => l.LibroId == _libroAEliminar.LibroId);

                if (libroBD == null)
                {
                    MessageBox.Show("El libro ya no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _context.Libros.Remove(libroBD);
                _context.SaveChanges();

                MessageBox.Show($"Libro '{libroBD.CodigoBarras}' eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _libroAEliminar = null;
                txtCodigo.Clear();
                lblInfo.Text = "";
                btnEliminar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos vacíos para eventos huérfanos
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void lblCodigo_Click(object sender, EventArgs e) { }
        private void txtCodigo_TextChanged(object sender, EventArgs e) { }
        private void lblInfo_Click(object sender, EventArgs e) { }

        private void lblCodigo_Click_1(object sender, EventArgs e)
        {

        }
    }
}