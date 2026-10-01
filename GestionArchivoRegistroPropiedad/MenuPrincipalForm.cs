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
            mnuGestionLibros.Visible = SesionActual.EsAdministrador;
            mnuGestionFuncionarios.Visible = SesionActual.EsAdministrador;
            mnuGestionUsuarios.Visible = SesionActual.EsAdministrador;

            // Custodia y Reportes son visibles para ambos roles
            mnuCustodia.Visible = true;
            mnuReportes.Visible = true;
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
        private void mnuGestionLibros_Click_1(object sender, EventArgs e)
        {
            var formLibros = new GestionLibrosForm(_context);
            formLibros.ShowDialog();
        }

        private void mnuGestionFuncionarios_Click_1(object sender, EventArgs e)
        {
            var formFunc = new GestionFuncionariosForm(_context);
            formFunc.ShowDialog();
        }

        private void mnuGestionUsuarios_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Usuarios (Próximamente).", "Próximamente");
        }

        private void mnuCustodia_Click_1(object sender, EventArgs e)
        {
            var formCustodia = new GestionCustodiaForm(_context);
            formCustodia.ShowDialog();
        }

        private void mnuReportes_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Reportes (Paso 6).", "Próximamente");
        }
    }
}