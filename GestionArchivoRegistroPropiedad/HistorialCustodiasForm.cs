using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class HistorialCustodiasForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;

        public HistorialCustodiasForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public HistorialCustodiasForm() { InitializeComponent(); }

        private void HistorialCustodiasForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Configurar grilla
            dgvHistorial.AutoGenerateColumns = true;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new object[] { "Todos", "En Custodia", "Devueltos" });
            cmbEstado.SelectedIndex = 0;

            // Funcionarios
            CargarFuncionarios();

            // Cargar historial
            CargarHistorial();
        }

        private void CargarFuncionarios()
        {
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

                var lista = new List<object>
                {
                    new { FuncionarioID = 0, NombreCompleto = "--- Todos ---" }
                };
                foreach (var f in funcionarios) lista.Add(f);

                cmbFuncionario.DataSource = lista;
                cmbFuncionario.DisplayMember = "NombreCompleto";
                cmbFuncionario.ValueMember = "FuncionarioID";
                cmbFuncionario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar funcionarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                _context.ChangeTracker.Clear();

                string filtroEstado = cmbEstado.SelectedItem?.ToString() ?? "Todos";
                string filtroCodigo = txtCodigo.Text.Trim();
                int filtroFuncionario = cmbFuncionario.SelectedValue is int id ? id : 0;

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

                if (filtroEstado == "En Custodia")
                    query = query.Where(x => x.FechaDevolucion == null);
                else if (filtroEstado == "Devueltos")
                    query = query.Where(x => x.FechaDevolucion != null);

                if (!string.IsNullOrWhiteSpace(filtroCodigo))
                    query = query.Where(x => x.CodigoBarras.Contains(filtroCodigo));

                if (filtroFuncionario > 0)
                {
                    var cedulaFunc = _context.Funcionarios
                        .Where(f => f.FuncionarioId == filtroFuncionario)
                        .Select(f => f.Cedula).FirstOrDefault();
                    query = query.Where(x => x.CedulaFuncionario == cedulaFunc);
                }

                var resultado = query
                    .OrderByDescending(x => x.FechaEntrega)
                    .ToList();

                dgvHistorial.DataSource = resultado;

                if (dgvHistorial.Columns["CustodiaID"] != null)
                    dgvHistorial.Columns["CustodiaID"].Visible = false;
                if (dgvHistorial.Columns["CodigoBarras"] != null)
                    dgvHistorial.Columns["CodigoBarras"].HeaderText = "Código";
                if (dgvHistorial.Columns["TipoLibro"] != null)
                    dgvHistorial.Columns["TipoLibro"].HeaderText = "Tipo";
                if (dgvHistorial.Columns["CedulaFuncionario"] != null)
                    dgvHistorial.Columns["CedulaFuncionario"].HeaderText = "Cédula";
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

                lblTotales.Text = $"Total de registros: {resultado.Count}";

                // Colorear
                foreach (DataGridViewRow row in dgvHistorial.Rows)
                {
                    string est = row.Cells["Estado"].Value?.ToString() ?? "";
                    row.DefaultCellStyle.BackColor = est == "En Custodia"
                        ? System.Drawing.Color.LightYellow
                        : System.Drawing.Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}\n\nDetalle: {ex.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            cmbFuncionario.SelectedIndex = 0;
            txtCodigo.Clear();
            CargarHistorial();
        }

        // Métodos vacíos
        private void lblEstado_Click(object sender, EventArgs e) { }
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblFuncionario_Click(object sender, EventArgs e) { }
        private void cmbFuncionario_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblCodigo_Click(object sender, EventArgs e) { }
        private void txtCodigo_TextChanged(object sender, EventArgs e) { }
        private void lblTotales_Click(object sender, EventArgs e) { }
        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}