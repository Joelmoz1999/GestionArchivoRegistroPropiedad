using GestionArchivoRegistroPropiedad.Models;
using BCrypt.Net;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class LoginForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;

        public LoginForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
           // string hash = BCrypt.Net.BCrypt.HashPassword("Admin123");
            //MessageBox.Show(hash, "Hash generado - Cópialo");


        }

        // Constructor vacío para el diseñador
        public LoginForm() { InitializeComponent(); }

        private void btnIngresar_Click(object sender, EventArgs e)
        {


           



            lblMensaje.Text = "";
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                lblMensaje.Text = "Debe ingresar usuario y contraseña.";
                return;
            }

            try
            {
                // Buscar el usuario en la BD
                var user = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario && u.Activo == true);

                if (user == null)
                {
                    lblMensaje.Text = "Usuario no encontrado o inactivo.";
                    return;
                }

                // Verificar la contraseña con BCrypt
                bool contrasenaValida = BCrypt.Net.BCrypt.Verify(contrasena, user.ContrasenaHash);

                if (!contrasenaValida)
                {
                    lblMensaje.Text = "Contraseña incorrecta.";
                    return;
                }

                // Login exitoso: guardar en sesión
                SesionActual.UsuarioLogueado = user;

                // Abrir el menú principal
                this.Hide();
                var menu = new MenuPrincipalForm(_context);
                menu.FormClosed += (s, args) => this.Close(); // Si cierran el menú, se cierra el login
                menu.Show();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}