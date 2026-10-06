using GestionArchivoRegistroPropiedad.Models;
using System;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class MenuPrincipalForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;

        public MenuPrincipalForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public MenuPrincipalForm() { InitializeComponent(); }

        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa. Cerrando...", "Aviso");
                this.Close();
                return;
            }

            // Mostrar el nombre del usuario logueado
            this.Text = $"Sistema de Archivo - {SesionActual.UsuarioLogueado.NombreCompleto} ({SesionActual.UsuarioLogueado.Rol})";

            // Aplicar permisos según el rol
            AplicarPermisosPorRol();
        }

        private void AplicarPermisosPorRol()
        {
            // Los formularios de Mantenimiento solo son visibles para el Administrador
            mnuGestionFuncionarios.Visible = SesionActual.EsAdministrador;
            mnuGestionUsuarios.Visible = SesionActual.EsAdministrador;
            mnuMantenimiento.Visible = SesionActual.EsEncargadoArchivo;
            mnuMantenimiento.Visible = SesionActual.EsAdministrador;
            mnuGestionUsuarios.Visible = SesionActual.EsAdministrador;
            //mnuGestionArchivoRegistroPropiedad.mnuGestionTipoLibro.Visible = SesionActual.EsAdministrador;
            mnuGestionTipoLibro.Visible = SesionActual.EsAdministrador;
            mnuImprimirEtiquetas.Visible = SesionActual.EsAdministrador;

            // Custodia y Reportes son visibles para ambos roles
            mnuCustodia.Visible = true;
            mnuReportes.Visible = true;
            mnuAgregarLibro.Visible = true;
            mnuModificarLibro.Visible = true;
        }

        private void mnuCerrarSesion_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Desea cerrar la sesión actual?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                SesionActual.CerrarSesion();
                this.Hide();
                var login = new LoginForm(_context);
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
        }

        private void mnuSalir_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Seguro que desea salir del sistema?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Los siguientes eventos los dejamos listos para los próximos pasos:


        private void mnuGestionFuncionarios_Click_1(object sender, EventArgs e)
        {
            var formFunc = new GestionFuncionariosForm(_context);
            formFunc.ShowDialog();
        }

        private void mnuGestionUsuarios_Click_1(object sender, EventArgs e)
        {
            var form = new GestionUsuariosForm(_context);
            form.ShowDialog();
        }

        private void mnuCustodia_Click_1(object sender, EventArgs e)
        {
            var form = new RegistrarPrestamoForm(_context);
            form.ShowDialog();
        }

        private void mnuReportes_Click_1(object sender, EventArgs e)
        {
            var form = new ReporteLibrosForm(_context);
            form.ShowDialog();
        }

        private void reporteDeCustodiasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var form = new ReporteCustodiasForm(_context);
            form.ShowDialog();

        }

        private void agregarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AgregarLibroForm(_context);
            form.ShowDialog();
        }

        private void modificarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModificarLibroForm(_context);
            form.ShowDialog();
        }

        private void eliminarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EliminarLibroForm(_context);
            form.ShowDialog();
        }

        private void registrarDevoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RegistrarDevolucionForm(_context);
            form.ShowDialog();

        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HistorialCustodiasForm(_context);
            form.ShowDialog();
        }

        private void agregarTipoLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new mnuGestionTipoLibro(_context);
            form.ShowDialog();
        }

        private void agregarTipoLibroToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new mnuGestionTipoLibro(_context);
            form.ShowDialog();
        }

        private void codigoDeBarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new mnuImprimirEtiquetas(_context);
            form.ShowDialog();
        }
    }
}