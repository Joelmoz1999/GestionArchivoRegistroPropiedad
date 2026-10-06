using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    public partial class mnuGestionTipoLibro : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;
        private List<TiposLibro> _tipos = new();

        public mnuGestionTipoLibro(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public mnuGestionTipoLibro() { InitializeComponent(); }

        // ============================================================
        // EVENTO LOAD
        // ============================================================
        private void GestionTiposLibrosForm_Load_1(object sender, EventArgs e)
        {
            if (SesionActual.UsuarioLogueado == null || !SesionActual.EsAdministrador)
            {
                MessageBox.Show("Solo el Administrador puede gestionar tipos de libros.",
                    "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            CargarTipos();



            if (!SesionActual.EsAdministrador)
            {
                MessageBox.Show("Solo el Administrador puede modificar tipos de libros.",
                    "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

        }

        // ============================================================
        // CARGAR TIPOS EN EL LISTBOX
        // ============================================================
        private void CargarTipos()
        {
            try
            {
                _context.ChangeTracker.Clear();

                _tipos = _context.TiposLibros
                    .AsNoTracking()
                    .OrderBy(t => t.Nombre)
                    .ToList();

                lstTipoLibro.Items.Clear();

                foreach (var tipo in _tipos)
                {
                    bool activo = tipo.Activo ?? false;
                    string prefijo = activo ? "✓ " : "✗ ";
                    string sufijo = activo ? "" : " (inactivo)";

                    lstTipoLibro.Items.Add($"{prefijo}{tipo.Nombre}{sufijo}");
                }

                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ACTUALIZAR ESTADO DE BOTONES
        // ============================================================
        private void ActualizarBotones()
        {
            bool haySeleccion = lstTipoLibro.SelectedIndex >= 0;

            btnEditar.Enabled = haySeleccion;

            if (haySeleccion)
            {
                var tipo = _tipos[lstTipoLibro.SelectedIndex];
                bool activo = tipo.Activo ?? false;

                btnEliminar.Enabled = activo;
                btnReactivar.Enabled = !activo;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnReactivar.Enabled = false;
            }
        }

        private void lstTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        // ============================================================
        // AGREGAR NUEVO TIPO
        // ============================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoTipo.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Escriba el nombre del nuevo tipo de libro.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevoTipo.Focus();
                return;
            }

            if (nombre.Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevoTipo.Focus();
                return;
            }

            try
            {
                _context.ChangeTracker.Clear();

                // Verificar que no exista (case-insensitive)
                bool existe = _context.TiposLibros
                    .Any(t => t.Nombre.ToLower() == nombre.ToLower());

                if (existe)
                {
                    MessageBox.Show($"Ya existe un tipo con el nombre '{nombre}'.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNuevoTipo.SelectAll();
                    txtNuevoTipo.Focus();
                    return;
                }

                // Normalizar nombre: primera letra mayúscula
                string nombreNormalizado = char.ToUpper(nombre[0]) + nombre.Substring(1).ToLower();

                var nuevoTipo = new TiposLibro
                {
                    Nombre = nombreNormalizado,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                };

                _context.TiposLibros.Add(nuevoTipo);
                _context.SaveChanges();

                MessageBox.Show($"Tipo '{nombreNormalizado}' agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNuevoTipo.Clear();
                txtNuevoTipo.Focus();
                CargarTipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNuevoTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnAgregar_Click(sender, e);
            }
        }

        // ============================================================
        // EDITAR TIPO
        // ============================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lstTipoLibro.SelectedIndex < 0) return;

            var tipo = _tipos[lstTipoLibro.SelectedIndex];

            // Pedir el nuevo nombre con un InputBox
            string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                $"Editar el tipo '{tipo.Nombre}'.\n\nEscriba el nuevo nombre:",
                "Editar Tipo de Libro",
                tipo.Nombre);

            if (string.IsNullOrWhiteSpace(nuevoNombre))
                return; // Canceló

            nuevoNombre = nuevoNombre.Trim();

            if (nuevoNombre.Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si no cambió, no hacer nada
            if (nuevoNombre.ToLower() == tipo.Nombre.ToLower())
                return;

            try
            {
                _context.ChangeTracker.Clear();

                // Verificar que no exista otro con ese nombre
                bool existe = _context.TiposLibros
                    .Any(t => t.Nombre.ToLower() == nuevoNombre.ToLower() &&
                              t.TipoLibroId != tipo.TipoLibroId);

                if (existe)
                {
                    MessageBox.Show($"Ya existe otro tipo con el nombre '{nuevoNombre}'.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ¿Está en uso?
                bool enUso = _context.Libros.Any(l => l.TipoLibro == tipo.Nombre);

                if (enUso)
                {
                    var confirmar = MessageBox.Show(
                        $"Este tipo está siendo usado por uno o más libros.\n\n" +
                        $"Si lo renombra, TODOS los libros que usan '{tipo.Nombre}' pasarán a usar '{nuevoNombre}'.\n\n" +
                        $"¿Desea continuar?",
                        "Tipo en uso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmar != DialogResult.Yes) return;

                    // Actualizar todos los libros que usan este tipo
                    var libros = _context.Libros.Where(l => l.TipoLibro == tipo.Nombre).ToList();
                    foreach (var libro in libros)
                        libro.TipoLibro = nuevoNombre;
                }

                // Normalizar nombre
                string nombreNormalizado = char.ToUpper(nuevoNombre[0]) + nuevoNombre.Substring(1).ToLower();

                // Actualizar el tipo
                var tipoBD = _context.TiposLibros.FirstOrDefault(t => t.TipoLibroId == tipo.TipoLibroId);
                if (tipoBD != null)
                {
                    tipoBD.Nombre = nombreNormalizado;
                }

                _context.SaveChanges();

                MessageBox.Show($"Tipo renombrado a '{nombreNormalizado}' correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ELIMINAR O DESACTIVAR
        // ============================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstTipoLibro.SelectedIndex < 0) return;

            var tipo = _tipos[lstTipoLibro.SelectedIndex];

            try
            {
                _context.ChangeTracker.Clear();

                // ¿Está en uso?
                bool enUso = _context.Libros.Any(l => l.TipoLibro == tipo.Nombre);

                if (enUso)
                {
                    // Desactivar con confirmación
                    var confirmar = MessageBox.Show(
                        $"El tipo '{tipo.Nombre}' está siendo usado por uno o más libros.\n\n" +
                        $"No se puede eliminar, pero puede DESACTIVARLO.\n" +
                        $"Un tipo desactivado ya no aparecerá al crear nuevos libros, " +
                        $"pero los libros existentes siguen funcionando.\n\n" +
                        $"¿Desea desactivarlo?",
                        "Tipo en uso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmar != DialogResult.Yes) return;

                    var tipoBD = _context.TiposLibros.FirstOrDefault(t => t.TipoLibroId == tipo.TipoLibroId);
                    if (tipoBD != null)
                    {
                        tipoBD.Activo = false;
                        _context.SaveChanges();

                        MessageBox.Show($"Tipo '{tipo.Nombre}' desactivado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarTipos();
                    }
                }
                else
                {
                    // Eliminar con confirmación
                    var confirmar = MessageBox.Show(
                        $"¿Está SEGURO de eliminar el tipo '{tipo.Nombre}'?\n\n" +
                        $"Esta acción NO se puede deshacer.",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmar != DialogResult.Yes) return;

                    var tipoBD = _context.TiposLibros.FirstOrDefault(t => t.TipoLibroId == tipo.TipoLibroId);
                    if (tipoBD != null)
                    {
                        _context.TiposLibros.Remove(tipoBD);
                        _context.SaveChanges();

                        MessageBox.Show($"Tipo '{tipo.Nombre}' eliminado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarTipos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // ============================================================
        // REACTIVAR
        // ============================================================
        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (lstTipoLibro.SelectedIndex < 0) return;

            var tipo = _tipos[lstTipoLibro.SelectedIndex];

            var confirmar = MessageBox.Show(
                $"¿Desea reactivar el tipo '{tipo.Nombre}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                _context.ChangeTracker.Clear();

                var tipoBD = _context.TiposLibros.FirstOrDefault(t => t.TipoLibroId == tipo.TipoLibroId);
                if (tipoBD != null)
                {
                    tipoBD.Activo = true;
                    _context.SaveChanges();

                    MessageBox.Show($"Tipo '{tipo.Nombre}' reactivado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarTipos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reactivar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        // ============================================================
        // CERRAR
        // ============================================================
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ============================================================
        // MÉTODOS VACÍOS PARA EVENTOS HUÉRFANOS
        // ============================================================
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void lblAgregar_Click(object sender, EventArgs e) { }
        private void txtNuevoTipo_TextChanged(object sender, EventArgs e) { }
        private void lblExistentes_Click(object sender, EventArgs e) { }

       
    }
}