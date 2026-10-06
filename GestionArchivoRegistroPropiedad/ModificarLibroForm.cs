using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class ModificarLibroForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private Libro? _libroSeleccionado = null;

        public ModificarLibroForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public ModificarLibroForm() { InitializeComponent(); }

        private void ModificarLibroForm_Load(object sender, EventArgs e)
        {
            dgvLibros.AutoGenerateColumns = true;
            dgvLibros.ReadOnly = true;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargar tipos desde la base de datos
            cmbEditTipo.Items.Clear();
            cmbEditTipo.Items.AddRange(TiposLibrosHelper.ObtenerTiposActivos(_context).ToArray());

            numEditAnio.Minimum = 1900;
            numEditAnio.Maximum = 2100;
            numEditTomo.Minimum = 1;
            numEditTomo.Maximum = 9999;
            numEditPartidaIni.Minimum = 1;
            numEditPartidaIni.Maximum = 9999999;
            numEditPartidaFin.Minimum = 1;
            numEditPartidaFin.Maximum = 9999999;

            CargarTodosLosLibros();


        
            if (!SesionActual.EsAdministrador)
            {
                MessageBox.Show("Solo el Administrador puede modificar libros.",
                    "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

          
        

        }

        private void CargarTodosLosLibros()
        {
            try
            {
                _context.ChangeTracker.Clear();

                var libros = _context.Libros
                    .AsNoTracking()
                    .Select(l => new
                    {
                        l.LibroId,
                        l.CodigoBarras,
                        l.TipoLibro,
                        l.Anio,
                        l.Tomo,
                        l.PartidaInicial,
                        l.PartidaFinal,
                        l.Estado,
                        Observacion = l.Observacion ?? ""
                    })
                    .OrderByDescending(l => l.Anio)
                    .ThenBy(l => l.TipoLibro)
                    .ToList();

                dgvLibros.DataSource = libros;

                if (dgvLibros.Columns["LibroID"] != null)
                    dgvLibros.Columns["LibroID"].Visible = false;
                if (dgvLibros.Columns["CodigoBarras"] != null)
                    dgvLibros.Columns["CodigoBarras"].HeaderText = "Código de Barras";
                if (dgvLibros.Columns["TipoLibro"] != null)
                    dgvLibros.Columns["TipoLibro"].HeaderText = "Tipo";
                if (dgvLibros.Columns["PartidaInicial"] != null)
                    dgvLibros.Columns["PartidaInicial"].HeaderText = "P. Inicial";
                if (dgvLibros.Columns["PartidaFinal"] != null)
                    dgvLibros.Columns["PartidaFinal"].HeaderText = "P. Final";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnCamposEdicion(Libro libro)
        {
            _libroSeleccionado = libro;

            cmbEditTipo.SelectedItem = libro.TipoLibro;
            numEditAnio.Value = libro.Anio;
            numEditTomo.Value = libro.Tomo;
            numEditPartidaIni.Value = libro.PartidaInicial;
            numEditPartidaFin.Value = libro.PartidaFinal;
            txtEditObservacion.Text = libro.Observacion ?? "";
        }

        private void LimpiarCamposEdicion()
        {
            _libroSeleccionado = null;
            cmbEditTipo.SelectedIndex = -1;
            numEditAnio.Value = DateTime.Now.Year;
            numEditTomo.Value = 1;
            numEditPartidaIni.Value = 1;
            numEditPartidaFin.Value = 1;
            txtEditObservacion.Clear();
        }







        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_libroSeleccionado == null)
            {
                MessageBox.Show("Debe buscar y seleccionar un libro primero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numEditPartidaFin.Value < numEditPartidaIni.Value)
            {
                MessageBox.Show("La Partida Final no puede ser menor que la Partida Inicial.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _context.ChangeTracker.Clear();

                var libroBD = _context.Libros
                    .FirstOrDefault(l => l.LibroId == _libroSeleccionado.LibroId);

                if (libroBD == null)
                {
                    MessageBox.Show("El libro ya no existe en la base de datos.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int nuevoAnio = (int)numEditAnio.Value;
                int nuevoTomo = (int)numEditTomo.Value;

                if (nuevoAnio != libroBD.Anio || nuevoTomo != libroBD.Tomo)
                {
                    bool duplicado = _context.Libros.Any(l =>
                        l.LibroId != libroBD.LibroId &&
                        l.TipoLibro == libroBD.TipoLibro &&
                        l.Anio == nuevoAnio &&
                        l.Tomo == nuevoTomo);

                    if (duplicado)
                    {
                        MessageBox.Show($"Ya existe otro libro de tipo '{libroBD.TipoLibro}' del año {nuevoAnio} con el tomo {nuevoTomo}.",
                            "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                bool regenerarCodigo = (nuevoAnio != libroBD.Anio) || (nuevoTomo != libroBD.Tomo);
                string codigoAnterior = libroBD.CodigoBarras;

                libroBD.Anio = nuevoAnio;
                libroBD.Tomo = nuevoTomo;
                libroBD.PartidaInicial = (int)numEditPartidaIni.Value;
                libroBD.PartidaFinal = (int)numEditPartidaFin.Value;
                libroBD.Observacion = string.IsNullOrWhiteSpace(txtEditObservacion.Text)
                    ? null : txtEditObservacion.Text.Trim();

                if (regenerarCodigo)
                {
                    libroBD.CodigoBarras = GenerarCodigoBarrasUnico(libroBD.TipoLibro, nuevoAnio, nuevoTomo);
                }

                _context.SaveChanges();

                string mensaje = "Libro actualizado correctamente.";
                if (regenerarCodigo)
                    mensaje += $"\n\n⚠️ El código de barras cambió:\nAntes: {codigoAnterior}\nAhora: {libroBD.CodigoBarras}";

                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTodosLosLibros();
                LimpiarCamposEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCamposEdicion();
            CargarTodosLosLibros();
        }

        private string GenerarCodigoBarrasUnico(string tipo, int anio, int tomo)
        {
            string prefijoTipo = tipo.Length >= 4
                ? tipo.Substring(0, 4).ToUpper()
                : tipo.ToUpper().PadRight(4, 'X');

            int totalExistentes = _context.Libros.Count(l =>
                l.TipoLibro == tipo && l.Anio == anio && l.Tomo == tomo);

            string codigo = $"{prefijoTipo}-{anio}-{tomo:D3}-{(totalExistentes + 1):D4}";

            int intentos = 0;
            while (_context.Libros.Any(l => l.CodigoBarras == codigo) && intentos < 100)
            {
                intentos++;
                codigo = $"{prefijoTipo}-{anio}-{tomo:D3}-{(totalExistentes + intentos + 1):D4}";
            }

            return codigo;
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            txtBuscarCodigo.Clear();
            LimpiarCamposEdicion();
            CargarTodosLosLibros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscarCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese un código de barras para buscar.", "Validación",
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
                    MessageBox.Show("No se encontró ningún libro con ese código de barras.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposEdicion();
                    return;
                }

                var resultado = new[]
                {
                    new
                    {
                        libro.LibroId,
                        libro.CodigoBarras,
                        libro.TipoLibro,
                        libro.Anio,
                        libro.Tomo,
                        libro.PartidaInicial,
                        libro.PartidaFinal,
                        libro.Estado,
                        Observacion = libro.Observacion ?? ""
                    }
                }.ToList();

                dgvLibros.DataSource = resultado;
                if (dgvLibros.Columns["LibroID"] != null)
                    dgvLibros.Columns["LibroID"].Visible = false;

                CargarDatosEnCamposEdicion(libro);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos vacíos para eventos huérfanos
        private void lblBuscar_Click(object sender, EventArgs e) { }
        private void txtBuscarCodigo_TextChanged(object sender, EventArgs e) { }
        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void grpEdicion_Enter(object sender, EventArgs e) { }
        private void lblEditTipo_Click(object sender, EventArgs e) { }
        private void cmbEditTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblEditAnio_Click(object sender, EventArgs e) { }
        private void numEditAnio_ValueChanged(object sender, EventArgs e) { }
        private void lblEditTomo_Click(object sender, EventArgs e) { }
        private void numEditTomo_ValueChanged(object sender, EventArgs e) { }
        private void lblEditPartidaIni_Click(object sender, EventArgs e) { }
        private void numEditPartidaIni_ValueChanged(object sender, EventArgs e) { }
        private void lblEditPartidaFin_Click(object sender, EventArgs e) { }
        private void numEditPartidaFin_ValueChanged(object sender, EventArgs e) { }
        private void lblEditObservacion_Click(object sender, EventArgs e) { }
        private void txtEditObservacion_TextChanged(object sender, EventArgs e) { }

        private void grpEdicion_Enter_1(object sender, EventArgs e)
        {

        }
    }
}