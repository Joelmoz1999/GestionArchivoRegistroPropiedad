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

        // ============================================================
        // EVENTO LOAD
        // ============================================================
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

            // 🔑 NUEVO: Iniciar el reloj
            timerReloj.Start();
            ActualizarFechaHora();

            // 🔑 NUEVO: Mostrar usuario en el status
            lblUsuarioStatus.Text = $"👤 {SesionActual.UsuarioLogueado.NombreUsuario}  |  {SesionActual.UsuarioLogueado.Rol}";

            // 🔑 NUEVO: Mostrar versión
            lblVersion.Text = "📌 v1.0";
        }

        // ============================================================
        // APLICAR PERMISOS POR ROL
        // ============================================================
        private void AplicarPermisosPorRol()
        {
            // Los formularios de Mantenimiento solo son visibles para el Administrador
            mnuGestionUsuarios.Visible = SesionActual.EsAdministrador;
           // mnuGestionTipoLibro.Visible = SesionActual.EsAdministrador;

            mnuGestionUsuarios.Visible = SesionActual.EsEncargadoArchivo;

            // Custodia y Reportes son visibles para ambos roles
            mnuCustodia.Visible = true;
            mnuReportes.Visible = true;
            mnuAgregarLibro.Visible = true;
            mnuModificarLibro.Visible = true;
            mnuImprimirEtiquetas.Visible = true;
            mnuMantenimiento.Visible = true;
            mnuGestionTipoLibro.Visible = true;
        }

        // ============================================================
        // TIMER: ACTUALIZAR FECHA Y HORA
        // ============================================================
        private void timerReloj_Tick(object sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        private void ActualizarFechaHora()
        {
            lblFechaHora.Text = $"📅 {DateTime.Now:dd/MM/yyyy}   🕐 {DateTime.Now:HH:mm:ss}";
        }

        // ============================================================
        // CERRAR SESIÓN
        // ============================================================
        private void mnuCerrarSesion_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Desea cerrar la sesión actual?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                timerReloj.Stop(); // 🔑 Detener el reloj
                SesionActual.CerrarSesion();
                this.Hide();
                var login = new LoginForm(_context);
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
        }

        // ============================================================
        // SALIR
        // ============================================================
        private void mnuSalir_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Seguro que desea salir del sistema?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ============================================================
        // MENÚ: GESTIÓN DE USUARIOS
        // ============================================================
        private void mnuGestionUsuarios_Click_1(object sender, EventArgs e)
        {
            var form = new GestionUsuariosForm(_context);
            form.ShowDialog();
        }

        // ============================================================
        // MENÚ: CUSTODIA (PRÉSTAMO)
        // ============================================================
        private void mnuCustodia_Click_1(object sender, EventArgs e)
        {
            var form = new RegistrarPrestamoForm(_context);
            form.ShowDialog();
        }

        // ============================================================
        // MENÚ: REPORTES
        // ============================================================
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

        // ============================================================
        // MENÚ: LIBROS
        // ============================================================
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

        // ============================================================
        // MENÚ: DEVOLUCIÓN
        // ============================================================
        private void registrarDevoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RegistrarDevolucionForm(_context);
            form.ShowDialog();
        }

        // ============================================================
        // MENÚ: HISTORIAL
        // ============================================================
        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HistorialCustodiasForm(_context);
            form.ShowDialog();
        }

        // ============================================================
        // MENÚ: TIPOS DE LIBROS
        // ============================================================
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

        // ============================================================
        // MENÚ: IMPRIMIR ETIQUETAS
        // ============================================================
        private void codigoDeBarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new mnuImprimirEtiquetas(_context);
            form.ShowDialog();
        }

        // ============================================================
        // EVENTOS VACÍOS (para eventos huérfanos)
        // ============================================================
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lblUsuarioStatus_Click(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new AgregarLibroForm(_context);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ReporteLibrosForm(_context);
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new RegistrarPrestamoForm(_context);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ReporteLibrosForm(_context);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new GestionUsuariosForm(_context);
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new RegistrarDevolucionForm(_context);
            form.ShowDialog();
        }
    }
}