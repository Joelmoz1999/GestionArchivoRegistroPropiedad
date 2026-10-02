using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class GestionUsuariosForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private Usuario? _usuarioSeleccionado = null;
        private bool _modoEdicion = false; // true = editando/creando, false = solo viendo

        public GestionUsuariosForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public GestionUsuariosForm() { InitializeComponent(); }

        // ============================================================
        // EVENTO LOAD
        // ============================================================
        private void GestionUsuariosForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null || !SesionActual.EsAdministrador)
            {
                MessageBox.Show("Solo el Administrador puede gestionar usuarios.",
                    "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Configurar grilla
            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargar roles
            cmbRol.Items.Clear();
            cmbRol.Items.AddRange(new object[] { "Administrador", "EncargadoArchivo" });
            cmbRol.SelectedIndex = 1;

            // Estado inicial
            DeshabilitarEdicion();
            ActualizarBotones();

            CargarUsuarios();
        }

        // ============================================================
        // CARGAR USUARIOS EN LA GRILLA
        // ============================================================
        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                _context.ChangeTracker.Clear();

                var query = _context.Usuarios.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(filtro))
                    query = query.Where(u => u.NombreUsuario.Contains(filtro) ||
                                             u.NombreCompleto.Contains(filtro));

                var usuarios = query
                    .Select(u => new
                    {
                        u.UsuarioId,
                        u.NombreCompleto,
                        u.NombreUsuario,
                        u.Rol,
                        Activo = u.Activo ?? false,
                        u.FechaCreacion
                    })
                    .OrderBy(u => u.NombreUsuario)
                    .ToList();

                dgvUsuarios.DataSource = usuarios;

                if (dgvUsuarios.Columns["UsuarioID"] != null)
                    dgvUsuarios.Columns["UsuarioID"].Visible = false;
                if (dgvUsuarios.Columns["NombreCompleto"] != null)
                    dgvUsuarios.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
                if (dgvUsuarios.Columns["NombreUsuario"] != null)
                    dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
                if (dgvUsuarios.Columns["Rol"] != null)
                    dgvUsuarios.Columns["Rol"].HeaderText = "Rol";
                if (dgvUsuarios.Columns["Activo"] != null)
                    dgvUsuarios.Columns["Activo"].HeaderText = "Activo";
                if (dgvUsuarios.Columns["FechaCreacion"] != null)
                    dgvUsuarios.Columns["FechaCreacion"].HeaderText = "Fecha Creación";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // SELECCIONAR USUARIO DE LA GRILLA
        // ============================================================


        // ============================================================
        // ACTUALIZAR ESTADO DE BOTONES
        // ============================================================
        private void ActualizarBotones()
        {
            bool haySeleccion = _usuarioSeleccionado != null;

            // Si estamos en modo edición, deshabilitar botones de acción
            if (_modoEdicion)
            {
                btnNuevoUsuario.Enabled = false;
                btnBuscar.Enabled = false;
                btnMostrarTodos.Enabled = false;
                btnCambiarContrasena.Enabled = false;
                btnDesactivar.Enabled = false;
                btnReactivar.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
                return;
            }

            // Modo normal
            btnNuevoUsuario.Enabled = true;
            btnBuscar.Enabled = true;
            btnMostrarTodos.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            btnCambiarContrasena.Enabled = haySeleccion;

            if (haySeleccion)
            {
                bool activo = _usuarioSeleccionado!.Activo ?? false;
                btnDesactivar.Enabled = activo;
                btnReactivar.Enabled = !activo;
            }
            else
            {
                btnDesactivar.Enabled = false;
                btnReactivar.Enabled = false;
            }
        }

        // ============================================================
        // HABILITAR / DESHABILITAR CAMPOS DE EDICIÓN
        // ============================================================
        private void HabilitarEdicion(bool esNuevo)
        {
            txtNombreCompleto.Enabled = true;
            txtNombreUsuario.Enabled = esNuevo; // No se puede cambiar el usuario al editar
            cmbRol.Enabled = true;
            txtContrasena.Enabled = true;
            txtConfirmar.Enabled = true;
            chkActivo.Enabled = true;

            _modoEdicion = true;
            ActualizarBotones();
        }

        private void DeshabilitarEdicion()
        {
            txtNombreCompleto.Enabled = false;
            txtNombreUsuario.Enabled = false;
            cmbRol.Enabled = false;
            txtContrasena.Enabled = false;
            txtConfirmar.Enabled = false;
            chkActivo.Enabled = false;

            _modoEdicion = false;
            ActualizarBotones();
        }

        private void LimpiarCampos()
        {
            txtNombreCompleto.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            txtConfirmar.Clear();
            cmbRol.SelectedIndex = 1;
            chkActivo.Checked = true;
        }

        // ============================================================
        // BOTÓN: Nuevo Usuario
        // ============================================================
        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            _usuarioSeleccionado = null;
            LimpiarCampos();
            HabilitarEdicion(esNuevo: true);
            txtNombreCompleto.Focus();
        }

        // ============================================================
        // BOTÓN: Guardar (crear o actualizar)
        // ============================================================


        // ============================================================
        // BOTÓN: Cancelar
        // ============================================================


        // ============================================================
        // BOTÓN: Cambiar Contraseña
        // ============================================================
        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Habilitar campos de contraseña y modo edición
            _modoEdicion = true;
            txtContrasena.Enabled = true;
            txtConfirmar.Enabled = true;
            txtContrasena.Clear();
            txtConfirmar.Clear();
            txtContrasena.Focus();

            MessageBox.Show("Ingrese la nueva contraseña en los campos de Contraseña y Confirmar, " +
                "y presione 'Guardar'.", "Cambiar Contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Habilitar solo Guardar y Cancelar
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevoUsuario.Enabled = false;
            btnBuscar.Enabled = false;
            btnMostrarTodos.Enabled = false;
            btnCambiarContrasena.Enabled = false;
            btnDesactivar.Enabled = false;
            btnReactivar.Enabled = false;
        }

        // ============================================================
        // BOTÓN: Buscar
        // ============================================================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text.Trim());
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarUsuarios();
        }

        // ============================================================
        // BOTÓN: Desactivar
        // ============================================================
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null) return;

            // Verificar que no sea el mismo usuario logueado
            if (_usuarioSeleccionado.UsuarioId == SesionActual.UsuarioLogueado!.UsuarioId)
            {
                MessageBox.Show("No puede desactivar el usuario con el que está logueado.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que no sea el último Administrador activo
            if (_usuarioSeleccionado.Rol == "Administrador")
            {
                int adminsActivos = _context.Usuarios
                    .Count(u => u.Rol == "Administrador" && u.Activo == true);

                if (adminsActivos <= 1)
                {
                    MessageBox.Show("No puede desactivar al último Administrador activo.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de desactivar al usuario '{_usuarioSeleccionado.NombreUsuario}'?\n\n" +
                $"El usuario no podrá iniciar sesión hasta que sea reactivado.",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _context.ChangeTracker.Clear();

                var usuarioBD = _context.Usuarios
                    .FirstOrDefault(u => u.UsuarioId == _usuarioSeleccionado.UsuarioId);

                if (usuarioBD == null) return;

                usuarioBD.Activo = false;
                _context.SaveChanges();

                MessageBox.Show("Usuario desactivado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _usuarioSeleccionado = null;
                CargarUsuarios();
                LimpiarCampos();
                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // BOTÓN: Reactivar
        // ============================================================
        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null) return;

            var confirm = MessageBox.Show(
                $"¿Desea reactivar al usuario '{_usuarioSeleccionado.NombreUsuario}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _context.ChangeTracker.Clear();

                var usuarioBD = _context.Usuarios
                    .FirstOrDefault(u => u.UsuarioId == _usuarioSeleccionado.UsuarioId);

                if (usuarioBD == null) return;

                usuarioBD.Activo = true;
                _context.SaveChanges();

                MessageBox.Show("Usuario reactivado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _usuarioSeleccionado = null;
                CargarUsuarios();
                LimpiarCampos();
                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reactivar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MÉTODOS VACÍOS PARA EVENTOS HUÉRFANOS
        // ============================================================
        private void lblBuscar_Click(object sender, EventArgs e) { }
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void lblNombreCompleto_Click(object sender, EventArgs e) { }
        private void txtNombreCompleto_TextChanged(object sender, EventArgs e) { }
        private void lblNombreUsuario_Click(object sender, EventArgs e) { }
        private void txtNombreUsuario_TextChanged(object sender, EventArgs e) { }
        private void lblRol_Click(object sender, EventArgs e) { }
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblContrasena_Click(object sender, EventArgs e) { }
        private void txtContrasena_TextChanged(object sender, EventArgs e) { }
        private void lblConfirmar_Click(object sender, EventArgs e) { }
        private void txtConfirmar_TextChanged(object sender, EventArgs e) { }
        private void chkActivo_CheckedChanged(object sender, EventArgs e) { }
        private void grpDatos_Enter(object sender, EventArgs e) { }
        private void grpAcciones_Enter(object sender, EventArgs e) { }
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (_modoEdicion) return; // No cambiar si está en modo edición

            if (dgvUsuarios.CurrentRow == null)
            {
                _usuarioSeleccionado = null;
                LimpiarCampos();
                ActualizarBotones();
                return;
            }

            try
            {
                int usuarioID = (int)dgvUsuarios.CurrentRow.Cells["UsuarioID"].Value;

                _context.ChangeTracker.Clear();
                _usuarioSeleccionado = _context.Usuarios.AsNoTracking()
                    .FirstOrDefault(u => u.UsuarioId == usuarioID);

                if (_usuarioSeleccionado != null)
                {
                    txtNombreCompleto.Text = _usuarioSeleccionado.NombreCompleto;
                    txtNombreUsuario.Text = _usuarioSeleccionado.NombreUsuario;
                    cmbRol.SelectedItem = _usuarioSeleccionado.Rol;
                    chkActivo.Checked = _usuarioSeleccionado.Activo ?? false;
                    txtContrasena.Clear();
                    txtConfirmar.Clear();
                }

                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            DeshabilitarEdicion();
            LimpiarCampos();
            _usuarioSeleccionado = null;
            ActualizarBotones();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
         
            string nombreCompleto = txtNombreCompleto.Text.Trim();
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string rol = cmbRol.SelectedItem?.ToString() ?? "";
            string contrasena = txtContrasena.Text;
            string confirmar = txtConfirmar.Text;

            // Validaciones generales
            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                MessageBox.Show("Debe ingresar el nombre completo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(rol))
            {
                MessageBox.Show("Debe seleccionar un rol.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context.ChangeTracker.Clear();

                if (_usuarioSeleccionado == null)
                {
                    // === CREAR NUEVO ===
                    if (string.IsNullOrWhiteSpace(contrasena))
                    {
                        MessageBox.Show("Debe ingresar una contraseña.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (contrasena != confirmar)
                    {
                        MessageBox.Show("Las contraseñas no coinciden.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (contrasena.Length < 6)
                    {
                        MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_context.Usuarios.Any(u => u.NombreUsuario == nombreUsuario))
                    {
                        MessageBox.Show("Ya existe un usuario con ese nombre.", "Duplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string hash = BCrypt.Net.BCrypt.HashPassword(contrasena);

                    var nuevoUsuario = new Usuario
                    {
                        NombreCompleto = nombreCompleto,
                        NombreUsuario = nombreUsuario,
                        ContrasenaHash = hash,
                        Rol = rol,
                        Activo = chkActivo.Checked,
                        FechaCreacion = DateTime.Now
                    };

                    _context.Usuarios.Add(nuevoUsuario);
                    _context.SaveChanges();

                    MessageBox.Show($"Usuario '{nombreUsuario}' creado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // === ACTUALIZAR ===
                    var usuarioBD = _context.Usuarios
                        .FirstOrDefault(u => u.UsuarioId == _usuarioSeleccionado.UsuarioId);

                    if (usuarioBD == null)
                    {
                        MessageBox.Show("El usuario ya no existe.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    usuarioBD.NombreCompleto = nombreCompleto;
                    usuarioBD.Rol = rol;
                    usuarioBD.Activo = chkActivo.Checked;

                    // Si se ingresó una nueva contraseña, cambiarla
                    if (!string.IsNullOrWhiteSpace(contrasena))
                    {
                        if (contrasena != confirmar)
                        {
                            MessageBox.Show("Las contraseñas no coinciden.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (contrasena.Length < 6)
                        {
                            MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        usuarioBD.ContrasenaHash = BCrypt.Net.BCrypt.HashPassword(contrasena);
                    }

                    _context.SaveChanges();

                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DeshabilitarEdicion();
                LimpiarCampos();
                _usuarioSeleccionado = null;
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}\n\nDetalle: {ex.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }
    }
}