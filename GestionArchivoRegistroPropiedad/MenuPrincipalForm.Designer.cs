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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipalForm));
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            mnuCerrarSesion = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            mnuMantenimiento = new ToolStripMenuItem();
            mnuGestionLibros = new ToolStripMenuItem();
            mnuAgregarLibro = new ToolStripMenuItem();
            mnuModificarLibro = new ToolStripMenuItem();
            eliminarLibroToolStripMenuItem = new ToolStripMenuItem();
            mnuGestionUsuarios = new ToolStripMenuItem();
            mnuGestionTipoLibro = new ToolStripMenuItem();
            mnuImprimirEtiquetas = new ToolStripMenuItem();
            operacionesToolStripMenuItem = new ToolStripMenuItem();
            mnuCustodia = new ToolStripMenuItem();
            registrarDevoluciónToolStripMenuItem = new ToolStripMenuItem();
            historialToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            mnuReportes = new ToolStripMenuItem();
            reporteDeCustodiasToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblUsuarioStatus = new ToolStripStatusLabel();
            lblVersion = new ToolStripStatusLabel();
            lblFechaHora = new ToolStripStatusLabel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            btnRegistrarPrestamo = new Button();
            button6 = new Button();
            timerReloj = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, mnuMantenimiento, mnuImprimirEtiquetas, operacionesToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(852, 24);
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
            // mnuMantenimiento
            // 
            mnuMantenimiento.DropDownItems.AddRange(new ToolStripItem[] { mnuGestionLibros, mnuGestionUsuarios, mnuGestionTipoLibro });
            mnuMantenimiento.Name = "mnuMantenimiento";
            mnuMantenimiento.Size = new Size(101, 20);
            mnuMantenimiento.Text = "Mantenimiento";
            // 
            // mnuGestionLibros
            // 
            mnuGestionLibros.DropDownItems.AddRange(new ToolStripItem[] { mnuAgregarLibro, mnuModificarLibro, eliminarLibroToolStripMenuItem });
            mnuGestionLibros.Name = "mnuGestionLibros";
            mnuGestionLibros.Size = new Size(180, 22);
            mnuGestionLibros.Text = "Gestión de Libros";
            // 
            // mnuAgregarLibro
            // 
            mnuAgregarLibro.Name = "mnuAgregarLibro";
            mnuAgregarLibro.Size = new Size(180, 22);
            mnuAgregarLibro.Text = "Agregar Libro";
            mnuAgregarLibro.Click += agregarLibroToolStripMenuItem_Click;
            // 
            // mnuModificarLibro
            // 
            mnuModificarLibro.Name = "mnuModificarLibro";
            mnuModificarLibro.Size = new Size(180, 22);
            mnuModificarLibro.Text = "Modificar Libro";
            mnuModificarLibro.Click += modificarLibroToolStripMenuItem_Click;
            // 
            // eliminarLibroToolStripMenuItem
            // 
            eliminarLibroToolStripMenuItem.Name = "eliminarLibroToolStripMenuItem";
            eliminarLibroToolStripMenuItem.Size = new Size(180, 22);
            eliminarLibroToolStripMenuItem.Text = "Eliminar Libro";
            eliminarLibroToolStripMenuItem.Click += eliminarLibroToolStripMenuItem_Click;
            // 
            // mnuGestionUsuarios
            // 
            mnuGestionUsuarios.Name = "mnuGestionUsuarios";
            mnuGestionUsuarios.Size = new Size(180, 22);
            mnuGestionUsuarios.Text = "Gestión de Usuarios";
            mnuGestionUsuarios.Click += mnuGestionUsuarios_Click_1;
            // 
            // mnuGestionTipoLibro
            // 
            mnuGestionTipoLibro.Name = "mnuGestionTipoLibro";
            mnuGestionTipoLibro.Size = new Size(180, 22);
            mnuGestionTipoLibro.Text = "Agregar Tipo Libro";
            mnuGestionTipoLibro.Click += agregarTipoLibroToolStripMenuItem_Click_1;
            // 
            // mnuImprimirEtiquetas
            // 
            mnuImprimirEtiquetas.Name = "mnuImprimirEtiquetas";
            mnuImprimirEtiquetas.Size = new Size(109, 20);
            mnuImprimirEtiquetas.Text = "Codigo de Barras";
            mnuImprimirEtiquetas.Click += codigoDeBarrasToolStripMenuItem_Click;
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
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuReportes, reporteDeCustodiasToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // mnuReportes
            // 
            mnuReportes.Name = "mnuReportes";
            mnuReportes.Size = new Size(186, 22);
            mnuReportes.Text = "Reporte de Libros";
            mnuReportes.Click += mnuReportes_Click_1;
            // 
            // reporteDeCustodiasToolStripMenuItem
            // 
            reporteDeCustodiasToolStripMenuItem.Name = "reporteDeCustodiasToolStripMenuItem";
            reporteDeCustodiasToolStripMenuItem.Size = new Size(186, 22);
            reporteDeCustodiasToolStripMenuItem.Text = "Reporte de Custodias";
            reporteDeCustodiasToolStripMenuItem.Click += reporteDeCustodiasToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblUsuarioStatus, lblVersion, lblFechaHora });
            statusStrip1.Location = new Point(0, 463);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(852, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // lblUsuarioStatus
            // 
            lblUsuarioStatus.Name = "lblUsuarioStatus";
            lblUsuarioStatus.Size = new Size(53, 17);
            lblUsuarioStatus.Text = "Usuario: ";
            lblUsuarioStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblUsuarioStatus.Click += lblUsuarioStatus_Click;
            // 
            // lblVersion
            // 
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(28, 17);
            lblVersion.Text = "v1.0";
            lblVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFechaHora
            // 
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(756, 17);
            lblFechaHora.Spring = true;
            lblFechaHora.Text = "...";
            lblFechaHora.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(186, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(272, 27);
            label1.Name = "label1";
            label1.Size = new Size(315, 25);
            label1.TabIndex = 10;
            label1.Text = "Registro de la Propiedad del Cantón";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(318, 52);
            label2.Name = "label2";
            label2.Size = new Size(231, 25);
            label2.TabIndex = 11;
            label2.Text = "Pedro Vicente Maldonado";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(335, 77);
            label3.Name = "label3";
            label3.Size = new Size(205, 25);
            label3.TabIndex = 13;
            label3.Text = "GESTIÓN DE ARCHIVO ";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Location = new Point(78, 112);
            button1.Name = "button1";
            button1.Size = new Size(165, 57);
            button1.TabIndex = 14;
            button1.Text = "AGREGAR LIBRO";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientActiveCaption;
            button2.Location = new Point(78, 207);
            button2.Name = "button2";
            button2.Size = new Size(165, 57);
            button2.TabIndex = 15;
            button2.Text = "MODIFICAR LIBRO";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GradientActiveCaption;
            button3.Location = new Point(344, 112);
            button3.Name = "button3";
            button3.Size = new Size(165, 57);
            button3.TabIndex = 16;
            button3.Text = "LIBROS";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.GradientActiveCaption;
            button4.Location = new Point(344, 207);
            button4.Name = "button4";
            button4.Size = new Size(165, 57);
            button4.TabIndex = 17;
            button4.Text = "USUARIOS";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // btnRegistrarPrestamo
            // 
            btnRegistrarPrestamo.BackColor = SystemColors.GradientActiveCaption;
            btnRegistrarPrestamo.Location = new Point(588, 112);
            btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            btnRegistrarPrestamo.Size = new Size(165, 57);
            btnRegistrarPrestamo.TabIndex = 18;
            btnRegistrarPrestamo.Text = "REGISTRAR PRESTAMO";
            btnRegistrarPrestamo.UseVisualStyleBackColor = false;
            btnRegistrarPrestamo.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.GradientActiveCaption;
            button6.Location = new Point(588, 207);
            button6.Name = "button6";
            button6.Size = new Size(165, 57);
            button6.TabIndex = 19;
            button6.Text = "REGISTRAR DEVOLUCIÓN";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // timerReloj
            // 
            timerReloj.Enabled = true;
            timerReloj.Interval = 1000;
            timerReloj.Tick += timerReloj_Tick;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(852, 485);
            Controls.Add(button6);
            Controls.Add(btnRegistrarPrestamo);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de la Propiedad del Cantón Pedro Vicente Maldonado | Gestión de Archivo ";
            Load += MenuPrincipalForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private ToolStripMenuItem mnuGestionUsuarios;
        private ToolStripMenuItem operacionesToolStripMenuItem;
        private ToolStripMenuItem mnuCustodia;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem mnuReportes;
        private ToolStripMenuItem reporteDeCustodiasToolStripMenuItem;
        private ToolStripMenuItem mnuAgregarLibro;
        private ToolStripMenuItem mnuModificarLibro;
        private ToolStripMenuItem eliminarLibroToolStripMenuItem;
        private ToolStripMenuItem registrarDevoluciónToolStripMenuItem;
        private ToolStripMenuItem historialToolStripMenuItem;
        private ToolStripMenuItem mnuGestionTipoLibro;
        private ToolStripMenuItem mnuImprimirEtiquetas;
        private ToolStripStatusLabel lblUsuarioStatus;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button btnRegistrarPrestamo;
        private Button button6;
        private ToolStripStatusLabel lblVersion;
        private ToolStripStatusLabel lblFechaHora;
        private System.Windows.Forms.Timer timerReloj;
    }
}