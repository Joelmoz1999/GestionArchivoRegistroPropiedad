namespace GestionArchivoRegistroPropiedad
{
    partial class MenuPrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            mnuCerrarSesion = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            mnuMantenimiento = new ToolStripMenuItem();
            mnuGestionLibros = new ToolStripMenuItem();
            mnuAgregarLibro = new ToolStripMenuItem();
            mnuModificarLibro = new ToolStripMenuItem();
            eliminarLibroToolStripMenuItem = new ToolStripMenuItem();
            mnuGestionFuncionarios = new ToolStripMenuItem();
            mnuGestionUsuarios = new ToolStripMenuItem();
            operacionesToolStripMenuItem = new ToolStripMenuItem();
            mnuCustodia = new ToolStripMenuItem();
            registrarDevoluciónToolStripMenuItem = new ToolStripMenuItem();
            historialToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            mnuReportes = new ToolStripMenuItem();
            reporteDeCustodiasToolStripMenuItem = new ToolStripMenuItem();
            reporteDeFuncionariosToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, mnuMantenimiento, operacionesToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(892, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuCerrarSesion, mnuSalir });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // mnuCerrarSesion
            // 
            mnuCerrarSesion.Name = "mnuCerrarSesion";
            mnuCerrarSesion.Size = new Size(143, 22);
            mnuCerrarSesion.Text = "Cerrar Sesión";
            mnuCerrarSesion.Click += mnuCerrarSesion_Click_1;
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(143, 22);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click_1;
            // 
            // mnuMantenimiento
            // 
            mnuMantenimiento.DropDownItems.AddRange(new ToolStripItem[] { mnuGestionLibros, mnuGestionFuncionarios, mnuGestionUsuarios });
            mnuMantenimiento.Name = "mnuMantenimiento";
            mnuMantenimiento.Size = new Size(101, 20);
            mnuMantenimiento.Text = "Mantenimiento";
            // 
            // mnuGestionLibros
            // 
            mnuGestionLibros.DropDownItems.AddRange(new ToolStripItem[] { mnuAgregarLibro, mnuModificarLibro, eliminarLibroToolStripMenuItem });
            mnuGestionLibros.Name = "mnuGestionLibros";
            mnuGestionLibros.Size = new Size(201, 22);
            mnuGestionLibros.Text = "Gestión de Libros";
            // 
            // mnuAgregarLibro
            // 
            mnuAgregarLibro.Name = "mnuAgregarLibro";
            mnuAgregarLibro.Size = new Size(155, 22);
            mnuAgregarLibro.Text = "Agregar Libro";
            mnuAgregarLibro.Click += agregarLibroToolStripMenuItem_Click;
            // 
            // mnuModificarLibro
            // 
            mnuModificarLibro.Name = "mnuModificarLibro";
            mnuModificarLibro.Size = new Size(155, 22);
            mnuModificarLibro.Text = "Modificar Libro";
            mnuModificarLibro.Click += modificarLibroToolStripMenuItem_Click;
            // 
            // eliminarLibroToolStripMenuItem
            // 
            eliminarLibroToolStripMenuItem.Name = "eliminarLibroToolStripMenuItem";
            eliminarLibroToolStripMenuItem.Size = new Size(155, 22);
            eliminarLibroToolStripMenuItem.Text = "Eliminar Libro";
            eliminarLibroToolStripMenuItem.Click += eliminarLibroToolStripMenuItem_Click;
            // 
            // mnuGestionFuncionarios
            // 
            mnuGestionFuncionarios.Name = "mnuGestionFuncionarios";
            mnuGestionFuncionarios.Size = new Size(201, 22);
            mnuGestionFuncionarios.Text = "Gestión de Funcionarios";
            mnuGestionFuncionarios.Click += mnuGestionFuncionarios_Click_1;
            // 
            // mnuGestionUsuarios
            // 
            mnuGestionUsuarios.Name = "mnuGestionUsuarios";
            mnuGestionUsuarios.Size = new Size(201, 22);
            mnuGestionUsuarios.Text = "Gestión de Usuarios";
            mnuGestionUsuarios.Click += mnuGestionUsuarios_Click_1;
            // 
            // operacionesToolStripMenuItem
            // 
            operacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuCustodia, registrarDevoluciónToolStripMenuItem, historialToolStripMenuItem });
            operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            operacionesToolStripMenuItem.Size = new Size(85, 20);
            operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // mnuCustodia
            // 
            mnuCustodia.Name = "mnuCustodia";
            mnuCustodia.Size = new Size(183, 22);
            mnuCustodia.Text = "Registrar Prestamo";
            mnuCustodia.Click += mnuCustodia_Click_1;
            // 
            // registrarDevoluciónToolStripMenuItem
            // 
            registrarDevoluciónToolStripMenuItem.Name = "registrarDevoluciónToolStripMenuItem";
            registrarDevoluciónToolStripMenuItem.Size = new Size(183, 22);
            registrarDevoluciónToolStripMenuItem.Text = "Registrar Devolución";
            registrarDevoluciónToolStripMenuItem.Click += registrarDevoluciónToolStripMenuItem_Click;
            // 
            // historialToolStripMenuItem
            // 
            historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            historialToolStripMenuItem.Size = new Size(183, 22);
            historialToolStripMenuItem.Text = "Historial";
            historialToolStripMenuItem.Click += historialToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuReportes, reporteDeCustodiasToolStripMenuItem, reporteDeFuncionariosToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // mnuReportes
            // 
            mnuReportes.Name = "mnuReportes";
            mnuReportes.Size = new Size(202, 22);
            mnuReportes.Text = "Reporte de Libros";
            mnuReportes.Click += mnuReportes_Click_1;
            // 
            // reporteDeCustodiasToolStripMenuItem
            // 
            reporteDeCustodiasToolStripMenuItem.Name = "reporteDeCustodiasToolStripMenuItem";
            reporteDeCustodiasToolStripMenuItem.Size = new Size(202, 22);
            reporteDeCustodiasToolStripMenuItem.Text = "Reporte de Custodias";
            reporteDeCustodiasToolStripMenuItem.Click += reporteDeCustodiasToolStripMenuItem_Click;
            // 
            // reporteDeFuncionariosToolStripMenuItem
            // 
            reporteDeFuncionariosToolStripMenuItem.Name = "reporteDeFuncionariosToolStripMenuItem";
            reporteDeFuncionariosToolStripMenuItem.Size = new Size(202, 22);
            reporteDeFuncionariosToolStripMenuItem.Text = "Reporte de Funcionarios";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 525);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(892, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 547);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Archivo - Registro de la Propiedad del Cantón Pedro Vicente Maldonado";
            Load += MenuPrincipalForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem mnuCerrarSesion;
        private ToolStripMenuItem mnuSalir;
        private ToolStripMenuItem mnuMantenimiento;
        private ToolStripMenuItem mnuGestionLibros;
        private ToolStripMenuItem mnuGestionFuncionarios;
        private ToolStripMenuItem mnuGestionUsuarios;
        private ToolStripMenuItem operacionesToolStripMenuItem;
        private ToolStripMenuItem mnuCustodia;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem mnuReportes;
        private ToolStripMenuItem reporteDeCustodiasToolStripMenuItem;
        private ToolStripMenuItem reporteDeFuncionariosToolStripMenuItem;
        private ToolStripMenuItem mnuAgregarLibro;
        private ToolStripMenuItem mnuModificarLibro;
        private ToolStripMenuItem eliminarLibroToolStripMenuItem;
        private ToolStripMenuItem registrarDevoluciónToolStripMenuItem;
        private ToolStripMenuItem historialToolStripMenuItem;
    }
}