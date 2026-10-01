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
            mantenimientoToolStripMenuItem = new ToolStripMenuItem();
            mnuGestionLibros = new ToolStripMenuItem();
            mnuGestionFuncionarios = new ToolStripMenuItem();
            mnuGestionUsuarios = new ToolStripMenuItem();
            operacionesToolStripMenuItem = new ToolStripMenuItem();
            mnuCustodia = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            mnuReportes = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, mantenimientoToolStripMenuItem, operacionesToolStripMenuItem, reportesToolStripMenuItem });
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
            mnuCerrarSesion.Size = new Size(180, 22);
            mnuCerrarSesion.Text = "Cerrar Sesión";
            mnuCerrarSesion.Click += mnuCerrarSesion_Click_1;
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(180, 22);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click_1;
            // 
            // mantenimientoToolStripMenuItem
            // 
            mantenimientoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuGestionLibros, mnuGestionFuncionarios, mnuGestionUsuarios });
            mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            mantenimientoToolStripMenuItem.Size = new Size(101, 20);
            mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // mnuGestionLibros
            // 
            mnuGestionLibros.Name = "mnuGestionLibros";
            mnuGestionLibros.Size = new Size(201, 22);
            mnuGestionLibros.Text = "Gestión de Libros";
            mnuGestionLibros.Click += mnuGestionLibros_Click_1;
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
            operacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuCustodia });
            operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            operacionesToolStripMenuItem.Size = new Size(85, 20);
            operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // mnuCustodia
            // 
            mnuCustodia.Name = "mnuCustodia";
            mnuCustodia.Size = new Size(180, 22);
            mnuCustodia.Text = "Custodia de Libros";
            mnuCustodia.Click += mnuCustodia_Click_1;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuReportes });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // mnuReportes
            // 
            mnuReportes.Name = "mnuReportes";
            mnuReportes.Size = new Size(180, 22);
            mnuReportes.Text = "Reporte de Libros";
            mnuReportes.Click += mnuReportes_Click_1;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 525);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(892, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(324, 176);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 547);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalForm";
            Text = "MenuPrincipalForm";
            Load += MenuPrincipalForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private Label label1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem mnuCerrarSesion;
        private ToolStripMenuItem mnuSalir;
        private ToolStripMenuItem mantenimientoToolStripMenuItem;
        private ToolStripMenuItem mnuGestionLibros;
        private ToolStripMenuItem mnuGestionFuncionarios;
        private ToolStripMenuItem mnuGestionUsuarios;
        private ToolStripMenuItem operacionesToolStripMenuItem;
        private ToolStripMenuItem mnuCustodia;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem mnuReportes;
    }
}