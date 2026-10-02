using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class RegistrarDevolucionForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private Custodia? _custodiaActual = null;

        public RegistrarDevolucionForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public RegistrarDevolucionForm() { InitializeComponent(); }

        private void RegistrarDevolucionForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            btnRegistrar.Enabled = false;
            lblInfo.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscarCodigo.Text.Trim();

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
                    MessageBox.Show("No se encontró el libro.", "Sin resultados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarDevolucion();
                    return;
                }

                if (libro.Estado != "En Custodia")
                {
                    MessageBox.Show($"El libro no está en custodia. Estado actual: {libro.Estado}",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarDevolucion();
                    return;
                }

                var custodia = _context.Custodias
                    .AsNoTracking()
                    .Where(c => c.LibroId == libro.LibroId && c.FechaDevolucion == null)
                    .OrderByDescending(c => c.FechaEntrega)
                    .FirstOrDefault();

                if (custodia == null)
                {
                    MessageBox.Show("No se encontró una custodia activa para este libro.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarDevolucion();
                    return;
                }

                var funcionario = _context.Funcionarios.AsNoTracking()
                    .FirstOrDefault(f => f.FuncionarioId == custodia.FuncionarioId);

                _custodiaActual = custodia;

                lblInfo.Text =
                    $"📖 Libro: {libro.CodigoBarras}\n" +
                    $"Tipo: {libro.TipoLibro} | Año: {libro.Anio} | Tomo: {libro.Tomo}\n" +
                    $"Partidas: {libro.PartidaInicial} - {libro.PartidaFinal}\n\n" +
                    $"👤 Funcionario: {funcionario?.Nombres} {funcionario?.Apellidos}\n" +
                    $"Cédula: {funcionario?.Cedula}\n\n" +
                    $"📅 Fecha de entrega: {custodia.FechaEntrega:dd/MM/yyyy HH:mm}\n" +
                    $"📝 Observaciones: {custodia.ObservacionesEntrega ?? "(ninguna)"}";

                btnRegistrar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            if (_custodiaActual == null) return;

            var confirm = MessageBox.Show("¿Confirmar la devolución de este libro?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _context.ChangeTracker.Clear();

                var custodiaBD = _context.Custodias
                    .FirstOrDefault(c => c.CustodiaId == _custodiaActual.CustodiaId);

                if (custodiaBD == null)
                {
                    MessageBox.Show("La custodia ya no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarDevolucion();
                    return;
                }

                custodiaBD.FechaDevolucion = DateTime.Now;
                custodiaBD.ObservacionesDevolucion = string.IsNullOrWhiteSpace(txtObservaciones.Text)
                    ? null : txtObservaciones.Text.Trim();

                var libroBD = _context.Libros.FirstOrDefault(l => l.LibroId == custodiaBD.LibroId);
                if (libroBD != null)
                    libroBD.Estado = "Disponible";

                _context.SaveChanges();

                MessageBox.Show("Devolución registrada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarDevolucion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar devolución: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDevolucion();
        }

        private void LimpiarDevolucion()
        {
            _custodiaActual = null;
            txtBuscarCodigo.Clear();
            txtObservaciones.Clear();
            lblInfo.Text = "";
            btnRegistrar.Enabled = false;
        }

        // Métodos vacíos
        private void lblBuscar_Click(object sender, EventArgs e) { }
        private void txtBuscarCodigo_TextChanged(object sender, EventArgs e) { }
        private void lblInfo_Click(object sender, EventArgs e) { }
        private void lblObservaciones_Click(object sender, EventArgs e) { }
        private void txtObservaciones_TextChanged(object sender, EventArgs e) { }
    }
}