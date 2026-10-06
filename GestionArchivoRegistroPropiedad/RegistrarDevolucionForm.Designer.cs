namespace GestionArchivoRegistroPropiedad
{
    partial class RegistrarDevolucionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarDevolucionForm));
            txtObservaciones = new TextBox();
            txtBuscarCodigo = new TextBox();
            lblObservaciones = new Label();
            lblInfo = new Label();
            lblBuscar = new Label();
            btnRegistrar = new Button();
            btnBuscar = new Button();
            bntLimpiar = new Button();
            SuspendLayout();
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(304, 304);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(376, 23);
            txtObservaciones.TabIndex = 13;
            txtObservaciones.TextChanged += txtObservaciones_TextChanged;
            // 
            // txtBuscarCodigo
            // 
            txtBuscarCodigo.Location = new Point(304, 62);
            txtBuscarCodigo.Name = "txtBuscarCodigo";
            txtBuscarCodigo.Size = new Size(100, 23);
            txtBuscarCodigo.TabIndex = 12;
            txtBuscarCodigo.TextChanged += txtBuscarCodigo_TextChanged;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(120, 307);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(166, 15);
            lblObservaciones.TabIndex = 11;
            lblObservaciones.Text = "Observaciones de Devolución:";
            lblObservaciones.Click += lblObservaciones_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(316, 137);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 15);
            lblInfo.TabIndex = 10;
            lblInfo.Click += lblInfo_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(127, 65);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(159, 15);
            lblBuscar.TabIndex = 9;
            lblBuscar.Text = "Buscar por Código de Barras:";
            lblBuscar.Click += lblBuscar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Enabled = false;
            btnRegistrar.Location = new Point(268, 361);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(94, 31);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar Devolución";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrarDevolucion_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(473, 61);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // bntLimpiar
            // 
            bntLimpiar.Enabled = false;
            bntLimpiar.Location = new Point(406, 361);
            bntLimpiar.Name = "bntLimpiar";
            bntLimpiar.Size = new Size(94, 31);
            bntLimpiar.TabIndex = 14;
            bntLimpiar.Text = "Limpiar";
            bntLimpiar.UseVisualStyleBackColor = true;
            bntLimpiar.Click += btnLimpiar_Click;
            // 
            // RegistrarDevolucionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bntLimpiar);
            Controls.Add(txtObservaciones);
            Controls.Add(txtBuscarCodigo);
            Controls.Add(lblObservaciones);
            Controls.Add(lblInfo);
            Controls.Add(lblBuscar);
            Controls.Add(btnRegistrar);
            Controls.Add(btnBuscar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegistrarDevolucionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de la Propiedad del Cantón Pedro Vicente Maldonado | Registrar Devolucion";
            Load += RegistrarDevolucionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtObservaciones;
        private TextBox txtBuscarCodigo;
        private Label lblObservaciones;
        private Label lblInfo;
        private Label lblBuscar;
        private Button btnRegistrar;
        private Button btnBuscar;
        private Button bntLimpiar;
    }
}