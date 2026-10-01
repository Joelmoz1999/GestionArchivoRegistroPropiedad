using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class GestionCustodiaForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private Libro? _libroSeleccionado = null;
        private Custodia? _custodiaActual = null;

        public GestionCustodiaForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public GestionCustodiaForm() { InitializeComponent(); }

        // ============================================================
        // EVENTO LOAD
        // ============================================================
        private void GestionCustodiaForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Configurar grilla de libros
            dgvLibrosDisponibles.AutoGenerateColumns = true;
            dgvLibrosDisponibles.ReadOnly = true;
            dgvLibrosDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibrosDisponibles.MultiSelect = false;
            dgvLibrosDisponibles.AllowUserToAddRows = false;
            dgvLibrosDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargar tipos de libros en el ComboBox
            cmbFiltrarTipo.Items.Clear();
            cmbFiltrarTipo.Items.Add("TODOS");
            cmbFiltrarTipo.Items.AddRange(new object[]
            {
                "Propiedad", "Sentencias", "Protocolos", "Poderes", "Hipotecas", "Otros"
            });
            cmbFiltrarTipo.SelectedIndex = 0;

            // Cargar funcionarios activos en el ComboBox
            CargarFuncionariosActivos();

            // Configurar DateTimePicker
            dtpFechaPrestamo.Value = DateTime.Now;
            dtpFechaPrestamo.Format = DateTimePickerFormat.Custom;
            dtpFechaPrestamo.CustomFormat = "dd/MM/yyyy HH:mm";

            btnRegistrarPrestamo.Enabled = false;
            btnRegistrarDevolucion.Enabled = false;
            lblCodigoSeleccionado.Text = "";

            // Cargar todos los libros disponibles
            CargarLibrosDisponibles("TODOS");
            CargarHistorialInicial();

        }

        // ============================================================
        // CARGAR FUNCIONARIOS ACTIVOS EN EL COMBOBOX
        // ============================================================
        private void CargarFuncionariosActivos()
        {
            try
            {
                _context.ChangeTracker.Clear();

                var funcionarios = _context.Funcionarios
                    .AsNoTracking()
                    .Where(f => f.Activo == true)
                    .OrderBy(f => f.Apellidos)
                    .Select(f => new
                    {
                        f.FuncionarioId,
                        NombreCompleto = f.Nombres + " " + f.Apellidos + " (" + f.Cedula + ")"
                    })
                    .ToList();

                cmbFuncionario.DataSource = funcionarios;
                cmbFuncionario.DisplayMember = "NombreCompleto";
                cmbFuncionario.ValueMember = "FuncionarioId";
                cmbFuncionario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar funcionarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CARGAR LIBROS DISPONIBLES SEGÚN EL TIPO
        // ============================================================
        private void CargarLibrosDisponibles(string tipoFiltro)
        {
            try
            {
                _context.ChangeTracker.Clear();

                var query = _context.Libros
                    .AsNoTracking()
                    .Where(l => l.Estado == "Disponible");

                if (tipoFiltro != "TODOS")
                    query = query.Where(l => l.TipoLibro == tipoFiltro);

                var libros = query
                    .Select(l => new
                    {
                        l.LibroId,
                        l.CodigoBarras,
                        l.TipoLibro,
                        l.Anio,
                        l.Tomo,
                        l.PartidaInicial,
                        l.PartidaFinal,
                        l.Estado
                    })
                    .OrderBy(l => l.TipoLibro)
                    .ThenByDescending(l => l.Anio)
                    .ThenBy(l => l.Tomo)
                    .ToList();

                dgvLibrosDisponibles.DataSource = libros;

                if (dgvLibrosDisponibles.Columns["LibroID"] != null)
                    dgvLibrosDisponibles.Columns["LibroID"].Visible = false;
                if (dgvLibrosDisponibles.Columns["CodigoBarras"] != null)
                    dgvLibrosDisponibles.Columns["CodigoBarras"].HeaderText = "Código";
                if (dgvLibrosDisponibles.Columns["TipoLibro"] != null)
                    dgvLibrosDisponibles.Columns["TipoLibro"].HeaderText = "Tipo";
                if (dgvLibrosDisponibles.Columns["PartidaInicial"] != null)
                    dgvLibrosDisponibles.Columns["PartidaInicial"].HeaderText = "P. Inicial";
                if (dgvLibrosDisponibles.Columns["PartidaFinal"] != null)
                    dgvLibrosDisponibles.Columns["PartidaFinal"].HeaderText = "P. Final";

                _libroSeleccionado = null;
                btnRegistrarPrestamo.Enabled = false;
                lblCodigoSeleccionado.Text = "";
                lblInfoLibro.Text = "📖 Sin libro seleccionado";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // FILTRAR LIBROS
        // ============================================================
        private void btnFiltrarLibros_Click(object sender, EventArgs e)
        {
            string tipo = cmbFiltrarTipo.SelectedItem?.ToString() ?? "TODOS";
            CargarLibrosDisponibles(tipo);
        }

        // ============================================================
        // SELECCIONAR UN LIBRO DE LA GRILLA
        // ============================================================
        private void dgvLibrosDisponibles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLibrosDisponibles.CurrentRow == null) return;

            try
            {
                int libroID = (int)dgvLibrosDisponibles.CurrentRow.Cells["LibroID"].Value;

                _context.ChangeTracker.Clear();
                var libro = _context.Libros.AsNoTracking().FirstOrDefault(l => l.LibroId == libroID);

                if (libro == null) return;

                _libroSeleccionado = libro;

                lblInfoLibro.Text = $"📖 {libro.TipoLibro} - Año {libro.Anio} - Tomo {libro.Tomo}";
                lblCodigoSeleccionado.Text = $"Código: {libro.CodigoBarras}";
                btnRegistrarPrestamo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // REGISTRAR PRÉSTAMO
        // ============================================================
        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            if (_libroSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un libro primero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbFuncionario.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un funcionario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int funcionarioID = (int)cmbFuncionario.SelectedValue!;

                // Verificar que el libro siga disponible
                _context.ChangeTracker.Clear();
                var libroBD = _context.Libros.FirstOrDefault(l => l.LibroId == _libroSeleccionado.LibroId);
                if (libroBD == null || libroBD.Estado != "Disponible")
                {
                    MessageBox.Show("El libro ya no está disponible.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarLibrosDisponibles(cmbFiltrarTipo.SelectedItem?.ToString() ?? "TODOS");
                    return;
                }

                // Crear la custodia
                var nuevaCustodia = new Custodia
                {
                    LibroId = libroBD.LibroId,
                    FuncionarioId = funcionarioID,
                    UsuarioRegistraId = SesionActual.UsuarioLogueado!.UsuarioId,
                    FechaEntrega = dtpFechaPrestamo.Value,
                    ObservacionesEntrega = string.IsNullOrWhiteSpace(txtObservacionesPrestamo.Text)
                        ? null : txtObservacionesPrestamo.Text.Trim(),
                    FechaDevolucion = null
                };

                // Actualizar el estado del libro
                libroBD.Estado = "En Custodia";

                _context.Custodias.Add(nuevaCustodia);
                _context.SaveChanges();

                MessageBox.Show($"Préstamo registrado correctamente.\n\nLibro: {libroBD.CodigoBarras}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar
                LimpiarPrestamo();
                CargarLibrosDisponibles(cmbFiltrarTipo.SelectedItem?.ToString() ?? "TODOS");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar préstamo: {ex.Message}\n\nDetalle: {ex.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarPrestamo_Click(object sender, EventArgs e)
        {
            LimpiarPrestamo();
        }

        private void LimpiarPrestamo()
        {
            _libroSeleccionado = null;
            cmbFuncionario.SelectedIndex = -1;
            dtpFechaPrestamo.Value = DateTime.Now;
            txtObservacionesPrestamo.Clear();
            lblInfoLibro.Text = "📖 Sin libro seleccionado";
            lblCodigoSeleccionado.Text = "";
            btnRegistrarPrestamo.Enabled = false;
        }

        // ============================================================
        // BUSCAR CUSTODIA PARA DEVOLUCIÓN
        // ============================================================
        private void btnBuscarDevolucion_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscarDevolucion.Text.Trim();

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

                // Buscar la custodia activa
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

                // Obtener datos del funcionario
                var funcionario = _context.Funcionarios.AsNoTracking()
                    .FirstOrDefault(f => f.FuncionarioId == custodia.FuncionarioId);

                _custodiaActual = custodia;

                lblInfoDevolucion.Text =
                    $"📖 Libro: {libro.CodigoBarras}\n" +
                    $"Tipo: {libro.TipoLibro} | Año: {libro.Anio} | Tomo: {libro.Tomo}\n" +
                    $"Partidas: {libro.PartidaInicial} - {libro.PartidaFinal}\n\n" +
                    $"👤 Funcionario: {funcionario?.Nombres} {funcionario?.Apellidos}\n" +
                    $"Cédula: {funcionario?.Cedula}\n\n" +
                    $"📅 Fecha de entrega: {custodia.FechaEntrega:dd/MM/yyyy HH:mm}\n" +
                    $"📝 Observaciones: {custodia.ObservacionesEntrega ?? "(ninguna)"}";

                btnRegistrarDevolucion.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // REGISTRAR DEVOLUCIÓN
        // ============================================================
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
                custodiaBD.ObservacionesDevolucion = string.IsNullOrWhiteSpace(txtObservacionesDevolucion.Text)
                    ? null : txtObservacionesDevolucion.Text.Trim();

                // Actualizar estado del libro
                var libroBD = _context.Libros.FirstOrDefault(l => l.LibroId == custodiaBD.LibroId);
                if (libroBD != null)
                    libroBD.Estado = "Disponible";

                _context.SaveChanges();

                MessageBox.Show("Devolución registrada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarDevolucion();
                CargarLibrosDisponibles(cmbFiltrarTipo.SelectedItem?.ToString() ?? "TODOS");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar devolución: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarDevolucion()
        {
            _custodiaActual = null;
            txtBuscarDevolucion.Clear();
            txtObservacionesDevolucion.Clear();
            lblInfoDevolucion.Text = "";
            btnRegistrarDevolucion.Enabled = false;
        }






        // ============================================================
        // HISTORIAL: Cargar datos iniciales al abrir el módulo
        // ============================================================
        private void CargarHistorialInicial()
        {
            // Llenar el ComboBox de estado
            cmbEstadoHistorial.Items.Clear();
            cmbEstadoHistorial.Items.AddRange(new object[] { "Todos", "En Custodia", "Devueltos" });
            cmbEstadoHistorial.SelectedIndex = 0;

            // Llenar el ComboBox de funcionarios (todos, activos e inactivos)
            try
            {
                _context.ChangeTracker.Clear();

                var funcionarios = _context.Funcionarios
                    .AsNoTracking()
                    .OrderBy(f => f.Apellidos)
                    .Select(f => new
                    {
                        f.FuncionarioId,
                        NombreCompleto = f.Nombres + " " + f.Apellidos
                    })
                    .ToList();

                // Agregar opción "Todos"
                var listaFuncionarios = new System.Collections.Generic.List<object>
                {
                    new { FuncionarioID = 0, NombreCompleto = "--- Todos ---" }
                };
                foreach (var f in funcionarios)
                    listaFuncionarios.Add(f);

                cmbFiltrarFuncionario.DataSource = listaFuncionarios;
                cmbFiltrarFuncionario.DisplayMember = "NombreCompleto";
                cmbFiltrarFuncionario.ValueMember = "FuncionarioID";
                cmbFiltrarFuncionario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar funcionarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Cargar todo el historial al inicio
            CargarHistorial();
        }

        // ============================================================
        // HISTORIAL: Cargar según filtros
        // ============================================================
        private void CargarHistorial()
        {
            try
            {
                _context.ChangeTracker.Clear();

                string filtroEstado = cmbEstadoHistorial.SelectedItem?.ToString() ?? "Todos";
                string filtroCodigo = txtFiltrarCodigoHistorial.Text.Trim();
                int filtroFuncionario = 0;
                if (cmbFiltrarFuncionario.SelectedValue is int id)
                    filtroFuncionario = id;

                var query = from c in _context.Custodias.AsNoTracking()
                            join l in _context.Libros.AsNoTracking() on c.LibroId equals l.LibroId
                            join f in _context.Funcionarios.AsNoTracking() on c.FuncionarioId equals f.FuncionarioId
                            join u in _context.Usuarios.AsNoTracking() on c.UsuarioRegistraId equals u.UsuarioId
                            select new
                            {
                                c.CustodiaId,
                                l.CodigoBarras,
                                l.TipoLibro,
                                l.Anio,
                                l.Tomo,
                                Funcionario = f.Nombres + " " + f.Apellidos,
                                CedulaFuncionario = f.Cedula,
                                c.FechaEntrega,
                                c.FechaDevolucion,
                                Estado = c.FechaDevolucion == null ? "En Custodia" : "Devuelto",
                                UsuarioRegistro = u.NombreCompleto,
                                c.ObservacionesEntrega,
                                c.ObservacionesDevolucion
                            };

                // Aplicar filtros
                if (filtroEstado == "En Custodia")
                    query = query.Where(x => x.FechaDevolucion == null);
                else if (filtroEstado == "Devueltos")
                    query = query.Where(x => x.FechaDevolucion != null);

                if (!string.IsNullOrWhiteSpace(filtroCodigo))
                    query = query.Where(x => x.CodigoBarras.Contains(filtroCodigo));

                if (filtroFuncionario > 0)
                    query = query.Where(x => x.CedulaFuncionario == (
                        _context.Funcionarios.Where(f => f.FuncionarioId == filtroFuncionario)
                            .Select(f => f.Cedula).FirstOrDefault()));

                var resultado = query
                    .OrderByDescending(x => x.FechaEntrega)
                    .ToList();

                dgvHistorial.DataSource = resultado;

                // Ocultar columna ID
                if (dgvHistorial.Columns["CustodiaID"] != null)
                    dgvHistorial.Columns["CustodiaID"].Visible = false;

                // Renombrar encabezados
                if (dgvHistorial.Columns["CodigoBarras"] != null)
                    dgvHistorial.Columns["CodigoBarras"].HeaderText = "Código";
                if (dgvHistorial.Columns["TipoLibro"] != null)
                    dgvHistorial.Columns["TipoLibro"].HeaderText = "Tipo";
                if (dgvHistorial.Columns["FechaEntrega"] != null)
                    dgvHistorial.Columns["FechaEntrega"].HeaderText = "F. Entrega";
                if (dgvHistorial.Columns["FechaDevolucion"] != null)
                    dgvHistorial.Columns["FechaDevolucion"].HeaderText = "F. Devolución";
                if (dgvHistorial.Columns["UsuarioRegistro"] != null)
                    dgvHistorial.Columns["UsuarioRegistro"].HeaderText = "Usuario";
                if (dgvHistorial.Columns["ObservacionesEntrega"] != null)
                    dgvHistorial.Columns["ObservacionesEntrega"].HeaderText = "Obs. Entrega";
                if (dgvHistorial.Columns["ObservacionesDevolucion"] != null)
                    dgvHistorial.Columns["ObservacionesDevolucion"].HeaderText = "Obs. Devolución";
                if (dgvHistorial.Columns["CedulaFuncionario"] != null)
                    dgvHistorial.Columns["CedulaFuncionario"].HeaderText = "Cédula";

                lblTotalHistorial.Text = $"Total de registros: {resultado.Count}";

                // Colorear filas según estado
                foreach (DataGridViewRow row in dgvHistorial.Rows)
                {
                    string estado = row.Cells["Estado"].Value?.ToString() ?? "";
                    if (estado == "En Custodia")
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    else
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}\n\nDetalle: {ex.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // HISTORIAL: Botón Filtrar
        // ============================================================
        private void btnFiltrarHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        // ============================================================
        // HISTORIAL: Botón Limpiar Filtros
        // ============================================================
        private void btnLimpiarFiltrosHistorial_Click(object sender, EventArgs e)
        {
            cmbEstadoHistorial.SelectedIndex = 0;
            cmbFiltrarFuncionario.SelectedIndex = 0;
            txtFiltrarCodigoHistorial.Clear();
            CargarHistorial();
        }


















        // ============================================================
        // MÉTODOS VACÍOS PARA EVENTOS HUÉRFANOS
        // ============================================================
        private void lblFiltrarTipo_Click(object sender, EventArgs e) { }
        private void cmbFiltrarTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblInfoLibro_Click(object sender, EventArgs e) { }
        private void lblCodigoSeleccionado_Click(object sender, EventArgs e) { }
        private void lblFuncionario_Click(object sender, EventArgs e) { }
        private void cmbFuncionario_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblFechaPrestamo_Click(object sender, EventArgs e) { }
        private void dtpFechaPrestamo_ValueChanged(object sender, EventArgs e) { }
        private void lblObservacionesPrestamo_Click(object sender, EventArgs e) { }
        private void txtObservacionesPrestamo_TextChanged(object sender, EventArgs e) { }
        private void lblBuscarDevolucion_Click(object sender, EventArgs e) { }
        private void txtBuscarDevolucion_TextChanged(object sender, EventArgs e) { }
        private void lblInfoDevolucion_Click(object sender, EventArgs e) { }
        private void lblObservacionesDevolucion_Click(object sender, EventArgs e) { }
        private void txtObservacionesDevolucion_TextChanged(object sender, EventArgs e) { }
        private void tabPrestamo_Click(object sender, EventArgs e) { }
        private void tabDevolucion_Click(object sender, EventArgs e) { }

        private void lblTotalHistorial_Click(object sender, EventArgs e)
        {

        }
    }
}