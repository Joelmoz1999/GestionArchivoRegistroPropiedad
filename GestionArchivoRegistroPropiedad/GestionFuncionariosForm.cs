using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class GestionFuncionariosForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private Funcionario? _funcionarioSeleccionado = null;
        private Funcionario? _funcionarioAEliminar = null;

        public GestionFuncionariosForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public GestionFuncionariosForm() { InitializeComponent(); }

        // ============================================================
        // EVENTO LOAD
        // ============================================================
        private void GestionFuncionariosForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa. Cerrando módulo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Solo Administrador puede gestionar funcionarios
            if (!SesionActual.EsAdministrador)
            {
                MessageBox.Show("Solo el Administrador puede gestionar funcionarios.",
                    "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Configurar la grilla
            dgvFuncionarios.AutoGenerateColumns = true;
            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuncionarios.MultiSelect = false;
            dgvFuncionarios.AllowUserToAddRows = false;
            dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Estado inicial
            btnEliminarFuncionario.Enabled = false;
            btnReactivarFuncionario.Enabled = false;
            lblInfoEliminarFunc.Text = "";

            CargarTodosLosFuncionarios();
        }

        // ============================================================
        // CARGAR TODOS LOS FUNCIONARIOS EN LA GRILLA
        // ============================================================
        private void CargarTodosLosFuncionarios()
        {
            try
            {
                _context.ChangeTracker.Clear();

                var funcionarios = _context.Funcionarios
                    .AsNoTracking()
                    .Select(f => new
                    {
                        f.FuncionarioId,
                        f.Nombres,
                        f.Apellidos,
                        f.Cedula,
                        f.Cargo,
                        Activo = f.Activo ?? false
                    })
                    .OrderBy(f => f.Apellidos)
                    .ThenBy(f => f.Nombres)
                    .ToList();

                dgvFuncionarios.DataSource = funcionarios;

                if (dgvFuncionarios.Columns["FuncionarioID"] != null)
                    dgvFuncionarios.Columns["FuncionarioID"].Visible = false;
                if (dgvFuncionarios.Columns["Nombres"] != null)
                    dgvFuncionarios.Columns["Nombres"].HeaderText = "Nombres";
                if (dgvFuncionarios.Columns["Apellidos"] != null)
                    dgvFuncionarios.Columns["Apellidos"].HeaderText = "Apellidos";
                if (dgvFuncionarios.Columns["Cedula"] != null)
                    dgvFuncionarios.Columns["Cedula"].HeaderText = "Cédula";
                if (dgvFuncionarios.Columns["Cargo"] != null)
                    dgvFuncionarios.Columns["Cargo"].HeaderText = "Cargo";
                if (dgvFuncionarios.Columns["Activo"] != null)
                    dgvFuncionarios.Columns["Activo"].HeaderText = "Activo";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar funcionarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // VALIDACIÓN DE CÉDULA ECUATORIANA
        // ============================================================
        private bool ValidarCedulaEcuatoriana(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return false;
            if (cedula.Length != 10) return false;
            if (!Regex.IsMatch(cedula, @"^\d{10}$")) return false;

            // Validar provincia (01-24)
            int provincia = int.Parse(cedula.Substring(0, 2));
            if (provincia < 1 || provincia > 24) return false;

            // Algoritmo del dígito verificador
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;

            for (int i = 0; i < 9; i++)
            {
                int valor = int.Parse(cedula[i].ToString()) * coeficientes[i];
                if (valor >= 10) valor -= 9;
                suma += valor;
            }

            int digitoVerificador = (10 - (suma % 10)) % 10;
            int ultimoDigito = int.Parse(cedula[9].ToString());

            return digitoVerificador == ultimoDigito;
        }

        // ============================================================
        // PESTAÑA AGREGAR: Guardar funcionario
        // ============================================================
        private void btnGuardarFuncionario_Click(object sender, EventArgs e)
        {
            lblMensajeAgregar.Text = "";

            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string cargo = txtCargo.Text.Trim();

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombres))
            {
                lblMensajeAgregar.Text = "Debe ingresar los nombres.";
                return;
            }

            if (string.IsNullOrWhiteSpace(apellidos))
            {
                lblMensajeAgregar.Text = "Debe ingresar los apellidos.";
                return;
            }

            if (!ValidarCedulaEcuatoriana(cedula))
            {
                lblMensajeAgregar.Text = "La cédula ingresada no es válida.";
                return;
            }

            if (string.IsNullOrWhiteSpace(cargo))
            {
                lblMensajeAgregar.Text = "Debe ingresar el cargo.";
                return;
            }

            try
            {
                // Verificar que la cédula no exista
                bool existe = _context.Funcionarios.Any(f => f.Cedula == cedula);
                if (existe)
                {
                    lblMensajeAgregar.Text = "Ya existe un funcionario con esa cédula.";
                    return;
                }

                var nuevoFuncionario = new Funcionario
                {
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Cedula = cedula,
                    Cargo = cargo,
                    Activo = true
                };

                _context.Funcionarios.Add(nuevoFuncionario);
                _context.SaveChanges();

                MessageBox.Show("Funcionario registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposAgregar();
                CargarTodosLosFuncionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PESTAÑA AGREGAR: Limpiar
        // ============================================================
        private void btnLimpiarFuncionario_Click(object sender, EventArgs e)
        {
            LimpiarCamposAgregar();
        }

        private void LimpiarCamposAgregar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCedula.Clear();
            txtCargo.Clear();
            lblMensajeAgregar.Text = "";
            txtNombres.Focus();
        }

        // ============================================================
        // PESTAÑA BUSCAR: Buscar por cédula o apellidos
        // ============================================================
        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscarFuncionario.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                MessageBox.Show("Ingrese una cédula o apellidos para buscar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context.ChangeTracker.Clear();

                var resultados = _context.Funcionarios
                    .AsNoTracking()
                    .Where(f => f.Cedula.Contains(filtro) ||
                                f.Apellidos.Contains(filtro) ||
                                f.Nombres.Contains(filtro))
                    .Select(f => new
                    {
                        f.FuncionarioId,
                        f.Nombres,
                        f.Apellidos,
                        f.Cedula,
                        f.Cargo,
                        Activo = f.Activo ?? false
                    })
                    .OrderBy(f => f.Apellidos)
                    .ToList();

                dgvFuncionarios.DataSource = resultados;

                if (dgvFuncionarios.Columns["FuncionarioId"] != null)
                    dgvFuncionarios.Columns["FuncionarioId"].Visible = false;

                if (resultados.Count == 1)
                {
                    // Cargar en los campos de edición
                    var func = _context.Funcionarios.FirstOrDefault(f => f.FuncionarioId == resultados[0].FuncionarioId);
                    if (func != null) CargarDatosEnCamposEdicion(func);
                }
                else if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron funcionarios con ese criterio.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposEdicion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarTodosFuncionarios_Click(object sender, EventArgs e)
        {
            txtBuscarFuncionario.Clear();
            LimpiarCamposEdicion();
            CargarTodosLosFuncionarios();
        }

        // ============================================================
        // CARGAR DATOS EN CAMPOS DE EDICIÓN
        // ============================================================
        private void CargarDatosEnCamposEdicion(Funcionario func)
        {
            _funcionarioSeleccionado = func;
            txtEditNombres.Text = func.Nombres;
            txtEditApellidos.Text = func.Apellidos;
            txtEditCedula.Text = func.Cedula;
            txtEditCargo.Text = func.Cargo;
            chkEditActivo.Checked = func.Activo ?? false;
        }

        private void LimpiarCamposEdicion()
        {
            _funcionarioSeleccionado = null;
            txtEditNombres.Clear();
            txtEditApellidos.Clear();
            txtEditCedula.Clear();
            txtEditCargo.Clear();
            chkEditActivo.Checked = true;
        }

        // ============================================================
        // PESTAÑA BUSCAR: Actualizar funcionario
        // ============================================================
        private void btnActualizarFuncionario_Click(object sender, EventArgs e)
        {
            if (_funcionarioSeleccionado == null)
            {
                MessageBox.Show("Debe buscar y seleccionar un funcionario primero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombres = txtEditNombres.Text.Trim();
            string apellidos = txtEditApellidos.Text.Trim();
            string cargo = txtEditCargo.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(cargo))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context.ChangeTracker.Clear();

                var funcBD = _context.Funcionarios
                    .FirstOrDefault(f => f.FuncionarioId == _funcionarioSeleccionado.FuncionarioId);

                if (funcBD == null)
                {
                    MessageBox.Show("El funcionario ya no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                funcBD.Nombres = nombres;
                funcBD.Apellidos = apellidos;
                funcBD.Cargo = cargo;
                funcBD.Activo = chkEditActivo.Checked;

                _context.SaveChanges();

                MessageBox.Show("Funcionario actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTodosLosFuncionarios();
                LimpiarCamposEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarEdicionFuncionario_Click(object sender, EventArgs e)
        {
            LimpiarCamposEdicion();
            CargarTodosLosFuncionarios();
        }

        // ============================================================
        // PESTAÑA ELIMINAR: Buscar funcionario
        // ============================================================
        private void btnBuscarEliminarFunc_Click(object sender, EventArgs e)
        {
            string cedula = txtEliminarCedulaFunc.Text.Trim();

            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("Ingrese una cédula.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context.ChangeTracker.Clear();

                var func = _context.Funcionarios
                    .AsNoTracking()
                    .FirstOrDefault(f => f.Cedula == cedula);

                if (func == null)
                {
                    MessageBox.Show("No se encontró un funcionario con esa cédula.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _funcionarioAEliminar = null;
                    btnEliminarFuncionario.Enabled = false;
                    btnReactivarFuncionario.Enabled = false;
                    lblInfoEliminarFunc.Text = "";
                    return;
                }

                _funcionarioAEliminar = func;

                bool activo = func.Activo ?? false;

                lblInfoEliminarFunc.Text =
                    $"👤 Funcionario encontrado:\n" +
                    $"Nombres: {func.Nombres} {func.Apellidos}\n" +
                    $"Cédula: {func.Cedula}\n" +
                    $"Cargo: {func.Cargo}\n" +
                    $"Estado: {(activo ? "ACTIVO" : "INACTIVO")}";

                btnEliminarFuncionario.Enabled = activo;
                btnReactivarFuncionario.Enabled = !activo;

                // Verificar si tiene custodias activas
                if (activo)
                {
                    bool tieneCustodiasActivas = _context.Custodias.Any(c =>
                        c.FuncionarioId == func.FuncionarioId && c.FechaDevolucion == null);

                    if (tieneCustodiasActivas)
                    {
                        MessageBox.Show("Este funcionario tiene libros en custodia. " +
                            "Debe devolverlos antes de poder desactivarlo.",
                            "En custodia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnEliminarFuncionario.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PESTAÑA ELIMINAR: Desactivar funcionario
        // ============================================================
        private void btnEliminarFuncionario_Click(object sender, EventArgs e)
        {
            if (_funcionarioAEliminar == null) return;

            var confirm = MessageBox.Show(
                $"¿Está seguro de DESACTIVAR a este funcionario?\n\n" +
                $"{_funcionarioAEliminar.Nombres} {_funcionarioAEliminar.Apellidos}\n" +
                $"Cédula: {_funcionarioAEliminar.Cedula}\n\n" +
                $"El funcionario dejará de aparecer en las listas de custodia.",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _context.ChangeTracker.Clear();

                var funcBD = _context.Funcionarios
                    .FirstOrDefault(f => f.FuncionarioId == _funcionarioAEliminar.FuncionarioId);

                if (funcBD == null)
                {
                    MessageBox.Show("El funcionario ya no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                funcBD.Activo = false;
                _context.SaveChanges();

                MessageBox.Show("Funcionario desactivado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _funcionarioAEliminar = null;
                txtEliminarCedulaFunc.Clear();
                lblInfoEliminarFunc.Text = "";
                btnEliminarFuncionario.Enabled = false;
                btnReactivarFuncionario.Enabled = false;

                CargarTodosLosFuncionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PESTAÑA ELIMINAR: Reactivar funcionario
        // ============================================================
        private void btnReactivarFuncionario_Click(object sender, EventArgs e)
        {
            if (_funcionarioAEliminar == null) return;

            var confirm = MessageBox.Show(
                $"¿Desea REACTIVAR a este funcionario?\n\n" +
                $"{_funcionarioAEliminar.Nombres} {_funcionarioAEliminar.Apellidos}",
                "Confirmar reactivación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _context.ChangeTracker.Clear();

                var funcBD = _context.Funcionarios
                    .FirstOrDefault(f => f.FuncionarioId == _funcionarioAEliminar.FuncionarioId);

                if (funcBD == null) return;

                funcBD.Activo = true;
                _context.SaveChanges();

                MessageBox.Show("Funcionario reactivado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _funcionarioAEliminar = null;
                txtEliminarCedulaFunc.Clear();
                lblInfoEliminarFunc.Text = "";
                btnEliminarFuncionario.Enabled = false;
                btnReactivarFuncionario.Enabled = false;

                CargarTodosLosFuncionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reactivar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        // ============================================================
        // MÉTODOS VACÍOS PARA EVENTOS ASIGNADOS POR EL DISEÑADOR
        // ============================================================

        // --- Pestaña Agregar ---
        private void lblNombres_Click(object sender, EventArgs e) { }
        private void lblApellidos_Click(object sender, EventArgs e) { }
        private void lblCedula_Click(object sender, EventArgs e) { }
        private void lblCargo_Click(object sender, EventArgs e) { }
        private void txtNombres_TextChanged(object sender, EventArgs e) { }
        private void txtApellidos_TextChanged(object sender, EventArgs e) { }
        private void txtCedula_TextChanged(object sender, EventArgs e) { }
        private void txtCargo_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void tabAgregar_Click(object sender, EventArgs e) { }

        // --- Pestaña Buscar / Modificar ---
        private void lblBuscarFuncionario_Click(object sender, EventArgs e) { }
        private void txtBuscarFuncionario_TextChanged(object sender, EventArgs e) { }
        private void dgvFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblEditNombres_Click(object sender, EventArgs e) { }
        private void lblEditApellidos_Click(object sender, EventArgs e) { }
        private void lblEditCedula_Click(object sender, EventArgs e) { }
        private void lblEditCargo_Click(object sender, EventArgs e) { }
        private void txtEditNombres_TextChanged(object sender, EventArgs e) { }
        private void txtEditApellidos_TextChanged(object sender, EventArgs e) { }
        private void txtEditCedula_TextChanged(object sender, EventArgs e) { }
        private void txtEditCargo_TextChanged(object sender, EventArgs e) { }
        private void grpEdicionFuncionario_Enter(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }

        // --- Pestaña Eliminar ---
        private void lblEliminarTituloFunc_Click(object sender, EventArgs e) { }
        private void lblEliminarCedula_Click(object sender, EventArgs e) { }
        private void txtEliminarCedulaFunc_TextChanged(object sender, EventArgs e) { }
        private void lblInfoEliminarFunc_Click(object sender, EventArgs e) { }
        private void tabEliminar_Click(object sender, EventArgs e) { }








    }







}