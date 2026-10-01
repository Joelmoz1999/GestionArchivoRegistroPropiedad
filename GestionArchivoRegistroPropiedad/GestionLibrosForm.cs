using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace GestionArchivoRegistroPropiedad
{
    public partial class GestionLibrosForm : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private Libro? _libroSeleccionado = null;      // Libro que se está editando actualmente
        private Libro? _libroAEliminar = null;         // Libro que se va a eliminar
        private readonly string[] _tiposLibros = { "Propiedad", "Sentencias", "Protocolos", "Poderes", "Hipotecas", "Otros" };

        public GestionLibrosForm(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public GestionLibrosForm() { InitializeComponent(); }

        // ============================================================
        // EVENTO LOAD: Inicialización del formulario
        // ============================================================
        private void GestionLibrosForm_Load(object sender, EventArgs e)
        {
            // Validar que haya sesión activa
            if (SesionActual.UsuarioLogueado == null)
            {
                MessageBox.Show("No hay sesión activa. Cerrando módulo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Solo el Administrador puede eliminar libros
            if (!SesionActual.EsAdministrador)
            {
                tabEliminar.Parent = null; // Ocultar la pestaña de Eliminar si no es Admin
            }

            // Cargar los tipos de libros en los ComboBox
            cmbTipoLibro.Items.Clear();
            cmbTipoLibro.Items.AddRange(_tiposLibros);
            cmbTipoLibro.SelectedIndex = 0;

            cmbEditTipo.Items.Clear();
            cmbEditTipo.Items.AddRange(_tiposLibros);

            // Inicializar los NumericUpDown con valores por defecto
            numAnio.Value = DateTime.Now.Year;
            numTomo.Value = 1;
            numPartidaIni.Value = 1;
            numPartidaFin.Value = 1;

            numEditAnio.Value = DateTime.Now.Year;
            numEditTomo.Value = 1;
            numEditPartidaIni.Value = 1;
            numEditPartidaFin.Value = 1;

            // Deshabilitar botón de eliminar hasta que se busque un libro
            btnEliminarLibro.Enabled = false;
            lblInfoEliminar.Text = "";

            // Configurar la grilla
            ConfigurarDataGridView();

            // Cargar todos los libros al inicio (opcional)
            CargarTodosLosLibros();
        }

        // ============================================================
        // CONFIGURACIÓN DE LA GRILLA
        // ============================================================
        private void ConfigurarDataGridView()
        {
            dgvLibros.AutoGenerateColumns = true;
            dgvLibros.ReadOnly = true;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // CARGAR TODOS LOS LIBROS EN LA GRILLA (opcional)
        // ============================================================
        private void CargarTodosLosLibros()
        {
            try
            {
                // Limpiar el tracking del contexto para forzar una lectura fresca
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



        // ============================================================
        // PESTAÑA AGREGAR: Vista previa del código de barras
        // ============================================================
        private void btnGenerarVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                // Generar un código de barras de ejemplo con los datos actuales
                string codigoEjemplo = GenerarCodigoBarrasString(
                    cmbTipoLibro.SelectedItem?.ToString() ?? "PROP",
                    (int)numAnio.Value,
                    (int)numTomo.Value);

                txtCodigoBarras.Text = codigoEjemplo;
                picCodigoBarras.Image = GenerarImagenCodigoBarras(codigoEjemplo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar vista previa: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PESTAÑA AGREGAR: Guardar libro
        // ============================================================
        private void btnGuardarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (cmbTipoLibro.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de libro.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numPartidaFin.Value < numPartidaIni.Value)
                {
                    MessageBox.Show("La Partida Final no puede ser menor que la Partida Inicial.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = cmbTipoLibro.SelectedItem.ToString()!;
                int anio = (int)numAnio.Value;
                int tomo = (int)numTomo.Value;

                // Verificar que no exista ya un libro con ese Tipo + Año + Tomo
                bool existe = _context.Libros.Any(l =>
                    l.TipoLibro == tipo && l.Anio == anio && l.Tomo == tomo);

                if (existe)
                {
                    MessageBox.Show($"Ya existe un libro de tipo '{tipo}' del año {anio} con el tomo {tomo}.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generar el código de barras único
                string codigoBarras = GenerarCodigoBarrasUnico(tipo, anio, tomo);

                // Crear el nuevo libro
                var nuevoLibro = new Libro
                {
                    TipoLibro = tipo,
                    Anio = anio,
                    Tomo = tomo,
                    PartidaInicial = (int)numPartidaIni.Value,
                    PartidaFinal = (int)numPartidaFin.Value,
                    Observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim(),
                    CodigoBarras = codigoBarras,
                    Estado = "Disponible",
                    FechaRegistro = DateTime.Now
                };

                _context.Libros.Add(nuevoLibro);
                _context.SaveChanges();

                // Mostrar el código de barras generado
                txtCodigoBarras.Text = codigoBarras;
                picCodigoBarras.Image = GenerarImagenCodigoBarras(codigoBarras);

                MessageBox.Show($"¡Libro guardado correctamente!\n\nCódigo de Barras: {codigoBarras}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar la grilla
                CargarTodosLosLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PESTAÑA AGREGAR: Limpiar campos
        // ============================================================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbTipoLibro.SelectedIndex = 0;
            numAnio.Value = DateTime.Now.Year;
            numTomo.Value = 1;
            numPartidaIni.Value = 1;
            numPartidaFin.Value = 1;
            txtObservacion.Clear();
            txtCodigoBarras.Clear();
            picCodigoBarras.Image = null;
        }

        // ============================================================
        // GENERAR CÓDIGO DE BARRAS EN FORMATO TEXTO
        // Formato: TIPO-AAAA-TOMO-SECUENCIAL (Ej: PROP-2018-008-0001)
        // ============================================================
        private string GenerarCodigoBarrasString(string tipo, int anio, int tomo)
        {
            // Tomar las primeras 4 letras del tipo en mayúsculas
            string prefijoTipo = tipo.Length >= 4
                ? tipo.Substring(0, 4).ToUpper()
                : tipo.ToUpper().PadRight(4, 'X');

            // Contar cuántos libros existen ya con ese tipo+año+tomo
            int secuencial = _context.Libros.Count(l =>
                l.TipoLibro == tipo && l.Anio == anio && l.Tomo == tomo) + 1;

            return $"{prefijoTipo}-{anio}-{tomo:D3}-{secuencial:D4}";
        }

        // ============================================================
        // GENERAR CÓDIGO DE BARRAS ÚNICO (asegura que no se repita)
        // ============================================================
        private string GenerarCodigoBarrasUnico(string tipo, int anio, int tomo)
        {
            string codigo = GenerarCodigoBarrasString(tipo, anio, tomo);
            int intentos = 0;

            // Si por alguna razón ya existe ese código, incrementar el secuencial
            while (_context.Libros.Any(l => l.CodigoBarras == codigo) && intentos < 100)
            {
                intentos++;
                string prefijoTipo = tipo.Length >= 4
                    ? tipo.Substring(0, 4).ToUpper()
                    : tipo.ToUpper().PadRight(4, 'X');

                int totalExistentes = _context.Libros.Count(l =>
                    l.TipoLibro == tipo && l.Anio == anio && l.Tomo == tomo);

                codigo = $"{prefijoTipo}-{anio}-{tomo:D3}-{(totalExistentes + intentos + 1):D4}";
            }

            return codigo;
        }

        // ============================================================
        // GENERAR IMAGEN DEL CÓDIGO DE BARRAS CON ZXING
        // ============================================================
        private Image GenerarImagenCodigoBarras(string contenido)
        {
            var writer = new ZXing.Windows.Compatibility.BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = 100,
                    Width = 300,
                    Margin = 5,
                    PureBarcode = false
                },
                Renderer = new ZXing.Windows.Compatibility.BitmapRenderer()
            };

            return writer.Write(contenido);
        }





        // ============================================================
        // PESTAÑA BUSCAR: Buscar por código de barras
        // ============================================================
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
                var libro = _context.Libros.FirstOrDefault(l => l.CodigoBarras == codigo);

                if (libro == null)
                {
                    MessageBox.Show("No se encontró ningún libro con ese código de barras.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposEdicion();
                    return;
                }

                // Cargar los datos en la grilla (solo este libro)
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

                // Cargar los datos en los campos de edición
                CargarDatosEnCamposEdicion(libro);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PESTAÑA BUSCAR: Mostrar todos los libros
        // ============================================================
        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            txtBuscarCodigo.Clear();
            LimpiarCamposEdicion();
            CargarTodosLosLibros();
        }

        // ============================================================
        // CARGAR DATOS DEL LIBRO EN LOS CAMPOS DE EDICIÓN
        // ============================================================
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

        // ============================================================
        // LIMPIAR CAMPOS DE EDICIÓN
        // ============================================================
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

        // ============================================================
        // PESTAÑA BUSCAR: Actualizar libro
        // ============================================================
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
                var libroBD = _context.Libros.FirstOrDefault(l => l.LibroId == _libroSeleccionado.LibroId);

                if (libroBD == null)
                {
                    MessageBox.Show("El libro ya no existe en la base de datos.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar duplicado si se cambió el Tomo
                int nuevoTomo = (int)numEditTomo.Value;
                if (nuevoTomo != libroBD.Tomo)
                {
                    bool duplicado = _context.Libros.Any(l =>
                        l.LibroId != libroBD.LibroId &&
                        l.TipoLibro == libroBD.TipoLibro &&
                        l.Anio == libroBD.Anio &&
                        l.Tomo == nuevoTomo);

                    if (duplicado)
                    {
                        MessageBox.Show($"Ya existe otro libro de tipo '{libroBD.TipoLibro}' del año {libroBD.Anio} con el tomo {nuevoTomo}.",
                            "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Actualizar los campos permitidos
                libroBD.Anio = (int)numEditAnio.Value;
                libroBD.Tomo = nuevoTomo;
                libroBD.PartidaInicial = (int)numEditPartidaIni.Value;
                libroBD.PartidaFinal = (int)numEditPartidaFin.Value;
                libroBD.Observacion = string.IsNullOrWhiteSpace(txtEditObservacion.Text)
                    ? null
                    : txtEditObservacion.Text.Trim();

                _context.SaveChanges();

                MessageBox.Show("Libro actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTodosLosLibros();
                LimpiarCamposEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PESTAÑA BUSCAR: Cancelar edición
        // ============================================================
        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            LimpiarCamposEdicion();
            CargarTodosLosLibros();
        }





        // ============================================================
        // PESTAÑA ELIMINAR: Buscar libro para eliminar
        // ============================================================
        private void btnBuscarEliminar_Click_1(object sender, EventArgs e)
        {

            string codigo = txtEliminarCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese un código de barras.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var libro = _context.Libros.FirstOrDefault(l => l.CodigoBarras == codigo);

                if (libro == null)
                {
                    MessageBox.Show("No se encontró ningún libro con ese código.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _libroAEliminar = null;
                    btnEliminarLibro.Enabled = false;
                    lblInfoEliminar.Text = "";
                    return;
                }

                // Verificar que no esté en custodia actualmente
                bool enCustodia = _context.Custodias.Any(c =>
                    c.LibroId == libro.LibroId && c.FechaDevolucion == null);

                if (enCustodia)
                {
                    MessageBox.Show("Este libro está actualmente en custodia. Debe devolverse antes de poder eliminarlo.",
                        "En custodia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _libroAEliminar = null;
                    btnEliminarLibro.Enabled = false;
                    lblInfoEliminar.Text = "";
                    return;
                }

                _libroAEliminar = libro;
                btnEliminarLibro.Enabled = true;

                lblInfoEliminar.Text =
                    $"📖 Libro encontrado:\n" +
                    $"Código: {libro.CodigoBarras}\n" +
                    $"Tipo: {libro.TipoLibro}\n" +
                    $"Año: {libro.Anio}\n" +
                    $"Tomo: {libro.Tomo}\n" +
                    $"Partidas: {libro.PartidaInicial} - {libro.PartidaFinal}\n" +
                    $"Estado: {libro.Estado}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PESTAÑA ELIMINAR: Eliminar el libro
        // ============================================================
        private void btnEliminarLibro_Click_1(object sender, EventArgs e)
        {
            if (!SesionActual.EsAdministrador)
            {
                MessageBox.Show("Solo el Administrador puede eliminar libros.",
                    "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_libroAEliminar == null)
            {
                MessageBox.Show("Debe buscar un libro primero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"⚠️ ¿Está SEGURO de eliminar este libro?\n\n" +
                $"Código: {_libroAEliminar.CodigoBarras}\n" +
                $"Tipo: {_libroAEliminar.TipoLibro} | Año: {_libroAEliminar.Anio} | Tomo: {_libroAEliminar.Tomo}\n\n" +
                $"Esta acción NO se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var libroBD = _context.Libros.FirstOrDefault(l => l.LibroId == _libroAEliminar.LibroId);
                if (libroBD == null)
                {
                    MessageBox.Show("El libro ya no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _context.Libros.Remove(libroBD);
                _context.SaveChanges();

                MessageBox.Show("Libro eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar
                _libroAEliminar = null;
                txtEliminarCodigo.Clear();
                lblInfoEliminar.Text = "";
                btnEliminarLibro.Enabled = false;

                // Refrescar grilla
                CargarTodosLosLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


















        // ============================================================
        // MÉTODOS VACÍOS PARA EVENTOS ASIGNADOS POR EL DISEÑADOR
        // (Estos eventos no hacen nada, solo existen para evitar errores)
        // ============================================================

        // --- Pestaña Agregar ---
        private void cmbTipoLibro_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numAnio_ValueChanged(object sender, EventArgs e) { }
        private void numTomo_ValueChanged(object sender, EventArgs e) { }
        private void numPartidaIni_ValueChanged(object sender, EventArgs e) { }
        private void numPartidaFin_ValueChanged(object sender, EventArgs e) { }
        private void txtObservacion_TextChanged(object sender, EventArgs e) { }
        private void txtCodigoBarras_TextChanged(object sender, EventArgs e) { }
        private void picCodigoBarras_Click(object sender, EventArgs e) { }
        private void lblTipo_Click(object sender, EventArgs e) { }
        private void lblAnio_Click(object sender, EventArgs e) { }
        private void lblTomo_Click(object sender, EventArgs e) { }
        private void lblPartidaIni_Click(object sender, EventArgs e) { }
        private void lblPartidaFin_Click(object sender, EventArgs e) { }
        private void lblObservacion_Click(object sender, EventArgs e) { }
        private void lblCodigoBarras_Click(object sender, EventArgs e) { }

        // --- Pestaña Buscar ---
        private void txtBuscarCodigo_TextChanged(object sender, EventArgs e) { }
        private void lblBuscar_Click(object sender, EventArgs e) { }
        private void cmbEditTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numEditAnio_ValueChanged(object sender, EventArgs e) { }
        private void numEditTomo_ValueChanged(object sender, EventArgs e) { }
        private void numEditPartidaIni_ValueChanged(object sender, EventArgs e) { }
        private void numEditPartidaFin_ValueChanged(object sender, EventArgs e) { }
        private void txtEditObservacion_TextChanged(object sender, EventArgs e) { }
        private void lblEditTipo_Click(object sender, EventArgs e) { }
        private void lblEditAnio_Click(object sender, EventArgs e) { }
        private void lblEditTomo_Click(object sender, EventArgs e) { }
        private void lblEditPartidaIni_Click(object sender, EventArgs e) { }
        private void lblEditPartidaFin_Click(object sender, EventArgs e) { }
        private void lblEditObservacion_Click(object sender, EventArgs e) { }
        private void grpEdicion_Enter(object sender, EventArgs e) { }
        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // --- Pestaña Eliminar ---
        private void txtEliminarCodigo_TextChanged(object sender, EventArgs e) { }
        private void lblEliminarTitulo_Click(object sender, EventArgs e) { }
        private void lblEliminarCodigo_Click(object sender, EventArgs e) { }
        private void lblInfoEliminar_Click(object sender, EventArgs e) { }

        // --- TabControl ---
        private void tabControlLibros_SelectedIndexChanged(object sender, EventArgs e) { }

       

       
    }
}
