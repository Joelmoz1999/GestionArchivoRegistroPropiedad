using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class RegistrarPrestamoForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private Libro? _libroSeleccionado = null;

        public RegistrarPrestamoForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public RegistrarPrestamoForm() { InitializeComponent(); }

        private void RegistrarPrestamoForm_Load_1(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Configurar grilla
            dgvLibrosDisponibles.AutoGenerateColumns = true;
            dgvLibrosDisponibles.ReadOnly = true;
            dgvLibrosDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibrosDisponibles.MultiSelect = false;
            dgvLibrosDisponibles.AllowUserToAddRows = false;
            dgvLibrosDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargar tipos desde la base de datos
            cmbFiltrarTipo.Items.Clear();
            cmbFiltrarTipo.Items.Add("TODOS");
            cmbFiltrarTipo.Items.AddRange(TiposLibrosHelper.ObtenerTiposActivos(_context).ToArray());
            cmbFiltrarTipo.SelectedIndex = 0;

            // Cargar funcionarios activos
            CargarFuncionariosActivos();

            // Configurar fecha
            dtpFechaPrestamo.Value = DateTime.Now;
            dtpFechaPrestamo.Format = DateTimePickerFormat.Custom;
            dtpFechaPrestamo.CustomFormat = "dd/MM/yyyy HH:mm";

            btnRegistrarPrestamo.Enabled = false;

            CargarLibrosDisponibles("TODOS");
        }

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
                cmbFuncionario.ValueMember = "FuncionarioID";
                cmbFuncionario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar funcionarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                LimpiarPrestamo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string tipo = cmbFiltrarTipo.SelectedItem?.ToString() ?? "TODOS";
            CargarLibrosDisponibles(tipo);
        }

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

                _context.ChangeTracker.Clear();
                var libroBD = _context.Libros.FirstOrDefault(l => l.LibroId == _libroSeleccionado.LibroId);
                if (libroBD == null || libroBD.Estado != "Disponible")
                {
                    MessageBox.Show("El libro ya no está disponible.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarLibrosDisponibles(cmbFiltrarTipo.SelectedItem?.ToString() ?? "TODOS");
                    return;
                }

                var nuevaCustodia = new Custodia
                {
                    LibroId = libroBD.LibroId,
                    FuncionarioId = funcionarioID,
                    UsuarioRegistraId = SesionActual.UsuarioLogueado!.UsuarioId,
                    FechaEntrega = dtpFechaPrestamo.Value,
                    ObservacionesEntrega = string.IsNullOrWhiteSpace(txtObservaciones.Text)
                        ? null : txtObservaciones.Text.Trim(),
                    FechaDevolucion = null
                };

                libroBD.Estado = "En Custodia";

                _context.Custodias.Add(nuevaCustodia);
                _context.SaveChanges();

                MessageBox.Show($"Préstamo registrado correctamente.\n\nLibro: {libroBD.CodigoBarras}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarPrestamo();
                CargarLibrosDisponibles(cmbFiltrarTipo.SelectedItem?.ToString() ?? "TODOS");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar préstamo: {ex.Message}\n\nDetalle: {ex.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPrestamo();
        }

        private void LimpiarPrestamo()
        {
            _libroSeleccionado = null;
            cmbFuncionario.SelectedIndex = -1;
            dtpFechaPrestamo.Value = DateTime.Now;
            txtObservaciones.Clear();
            lblInfoLibro.Text = "📖 Sin libro seleccionado";
            // lblCodigoSeleccionado.Text = "";
            btnRegistrarPrestamo.Enabled = false;
        }

        private void dgvLibrosDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                //lblCodigoSeleccionado.Text = $"Código: {libro.CodigoBarras}";
                btnRegistrarPrestamo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        // Métodos vacíos para eventos huérfanos
        private void lblFiltrarTipo_Click(object sender, EventArgs e) { }
        private void cmbFiltrarTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblInfoLibro_Click(object sender, EventArgs e) { }
        private void lblCodigoSeleccionado_Click(object sender, EventArgs e) { }
        private void lblFuncionario_Click(object sender, EventArgs e) { }
        private void cmbFuncionario_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblFechaPrestamo_Click(object sender, EventArgs e) { }
        private void dtpFechaPrestamo_ValueChanged(object sender, EventArgs e) { }
        private void lblObservaciones_Click(object sender, EventArgs e) { }
        private void txtObservaciones_TextChanged(object sender, EventArgs e) { }

        private void cmbFuncionario_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}