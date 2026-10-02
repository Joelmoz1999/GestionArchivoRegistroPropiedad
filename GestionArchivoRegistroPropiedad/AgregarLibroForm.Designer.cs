namespace GestionArchivoRegistroPropiedad
{
    partial class AgregarLibroForm
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
            btnGenerarVistaPrevia = new Button();
            btnLimpiarEtiqueta = new Button();
            bntGuardarLibro = new Button();
            picCodigoBarras = new PictureBox();
            txtCodigoBarras = new TextBox();
            txtObservacion = new TextBox();
            lblObservacion = new Label();
            lblCodigoBarras = new Label();
            numPartidaFin = new NumericUpDown();
            lblPartidaFin = new Label();
            numPartidaIni = new NumericUpDown();
            lblPartidaIni = new Label();
            numTomo = new NumericUpDown();
            lblTomo = new Label();
            numAnio = new NumericUpDown();
            lblAnio = new Label();
            cmbTipoLibro = new ComboBox();
            lblTipo = new Label();
            btnImprimirEtiqueta = new Button();
            ((System.ComponentModel.ISupportInitialize)picCodigoBarras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPartidaFin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPartidaIni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTomo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
            SuspendLayout();
            // 
            // btnGenerarVistaPrevia
            // 
            btnGenerarVistaPrevia.Location = new Point(593, 401);
            btnGenerarVistaPrevia.Name = "btnGenerarVistaPrevia";
            btnGenerarVistaPrevia.Size = new Size(95, 35);
            btnGenerarVistaPrevia.TabIndex = 71;
            btnGenerarVistaPrevia.Text = "Vista Previa Código";
            btnGenerarVistaPrevia.UseVisualStyleBackColor = true;
            btnGenerarVistaPrevia.Click += btnGenerarVistaPrevia_Click;
            // 
            // btnLimpiarEtiqueta
            // 
            btnLimpiarEtiqueta.Location = new Point(462, 402);
            btnLimpiarEtiqueta.Name = "btnLimpiarEtiqueta";
            btnLimpiarEtiqueta.Size = new Size(89, 35);
            btnLimpiarEtiqueta.TabIndex = 70;
            btnLimpiarEtiqueta.Text = "Limpiar";
            btnLimpiarEtiqueta.UseVisualStyleBackColor = true;
            btnLimpiarEtiqueta.Click += btnLimpiar_Click;
            // 
            // bntGuardarLibro
            // 
            bntGuardarLibro.Location = new Point(157, 401);
            bntGuardarLibro.Name = "bntGuardarLibro";
            bntGuardarLibro.Size = new Size(99, 36);
            bntGuardarLibro.TabIndex = 69;
            bntGuardarLibro.Text = "Guardar Libro";
            bntGuardarLibro.UseVisualStyleBackColor = true;
            bntGuardarLibro.Click += bntGuardarLibro_Click;
            // 
            // picCodigoBarras
            // 
            picCodigoBarras.Location = new Point(220, 323);
            picCodigoBarras.Name = "picCodigoBarras";
            picCodigoBarras.Size = new Size(393, 50);
            picCodigoBarras.TabIndex = 68;
            picCodigoBarras.TabStop = false;
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(167, 247);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(213, 23);
            txtCodigoBarras.TabIndex = 67;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(147, 194);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(554, 23);
            txtObservacion.TabIndex = 66;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(61, 194);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(76, 15);
            lblObservacion.TabIndex = 65;
            lblObservacion.Text = "Observación:";
            // 
            // lblCodigoBarras
            // 
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.Location = new Point(61, 247);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(100, 15);
            lblCodigoBarras.TabIndex = 64;
            lblCodigoBarras.Text = "Codigo de Barras:";
            // 
            // numPartidaFin
            // 
            numPartidaFin.Location = new Point(568, 135);
            numPartidaFin.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numPartidaFin.Name = "numPartidaFin";
            numPartidaFin.Size = new Size(120, 23);
            numPartidaFin.TabIndex = 63;
            // 
            // lblPartidaFin
            // 
            lblPartidaFin.AutoSize = true;
            lblPartidaFin.Location = new Point(462, 135);
            lblPartidaFin.Name = "lblPartidaFin";
            lblPartidaFin.Size = new Size(75, 15);
            lblPartidaFin.TabIndex = 62;
            lblPartidaFin.Text = "Partida Final:";
            // 
            // numPartidaIni
            // 
            numPartidaIni.Location = new Point(189, 132);
            numPartidaIni.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numPartidaIni.Name = "numPartidaIni";
            numPartidaIni.Size = new Size(120, 23);
            numPartidaIni.TabIndex = 61;
            // 
            // lblPartidaIni
            // 
            lblPartidaIni.AutoSize = true;
            lblPartidaIni.Location = new Point(61, 135);
            lblPartidaIni.Name = "lblPartidaIni";
            lblPartidaIni.Size = new Size(81, 15);
            lblPartidaIni.TabIndex = 60;
            lblPartidaIni.Text = "Partida Inicial:";
            // 
            // numTomo
            // 
            numTomo.Location = new Point(620, 59);
            numTomo.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numTomo.Name = "numTomo";
            numTomo.Size = new Size(120, 23);
            numTomo.TabIndex = 59;
            // 
            // lblTomo
            // 
            lblTomo.AutoSize = true;
            lblTomo.Location = new Point(554, 64);
            lblTomo.Name = "lblTomo";
            lblTomo.Size = new Size(41, 15);
            lblTomo.TabIndex = 58;
            lblTomo.Text = "Tomo:";
            // 
            // numAnio
            // 
            numAnio.Location = new Point(363, 56);
            numAnio.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            numAnio.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            numAnio.Name = "numAnio";
            numAnio.Size = new Size(120, 23);
            numAnio.TabIndex = 57;
            numAnio.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(314, 64);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(32, 15);
            lblAnio.TabIndex = 56;
            lblAnio.Text = "Año:";
            // 
            // cmbTipoLibro
            // 
            cmbTipoLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoLibro.FormattingEnabled = true;
            cmbTipoLibro.Items.AddRange(new object[] { "Propiedad", "Sentencias y Demandas", "Hipotecas", "Mercantil" });
            cmbTipoLibro.Location = new Point(147, 56);
            cmbTipoLibro.Name = "cmbTipoLibro";
            cmbTipoLibro.Size = new Size(121, 23);
            cmbTipoLibro.TabIndex = 55;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(61, 59);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(80, 15);
            lblTipo.TabIndex = 54;
            lblTipo.Text = "Tipo de Libro:";
            // 
            // btnImprimirEtiqueta
            // 
            btnImprimirEtiqueta.Enabled = false;
            btnImprimirEtiqueta.Location = new Point(297, 401);
            btnImprimirEtiqueta.Name = "btnImprimirEtiqueta";
            btnImprimirEtiqueta.Size = new Size(95, 35);
            btnImprimirEtiqueta.TabIndex = 73;
            btnImprimirEtiqueta.Text = "Imprimir";
            btnImprimirEtiqueta.UseVisualStyleBackColor = true;
            btnImprimirEtiqueta.Click += button1_Click;
            // 
            // AgregarLibroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnImprimirEtiqueta);
            Controls.Add(btnGenerarVistaPrevia);
            Controls.Add(btnLimpiarEtiqueta);
            Controls.Add(bntGuardarLibro);
            Controls.Add(picCodigoBarras);
            Controls.Add(txtCodigoBarras);
            Controls.Add(txtObservacion);
            Controls.Add(lblObservacion);
            Controls.Add(lblCodigoBarras);
            Controls.Add(numPartidaFin);
            Controls.Add(lblPartidaFin);
            Controls.Add(numPartidaIni);
            Controls.Add(lblPartidaIni);
            Controls.Add(numTomo);
            Controls.Add(lblTomo);
            Controls.Add(numAnio);
            Controls.Add(lblAnio);
            Controls.Add(cmbTipoLibro);
            Controls.Add(lblTipo);
            Name = "AgregarLibroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Libro";
            Load += AgregarLibroForm_Load;
            ((System.ComponentModel.ISupportInitialize)picCodigoBarras).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPartidaFin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPartidaIni).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTomo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenerarVistaPrevia;
        private Button btnLimpiarEtiqueta;
        private Button bntGuardarLibro;
        private PictureBox picCodigoBarras;
        private TextBox txtCodigoBarras;
        private TextBox txtObservacion;
        private Label lblObservacion;
        private Label lblCodigoBarras;
        private NumericUpDown numPartidaFin;
        private Label lblPartidaFin;
        private NumericUpDown numPartidaIni;
        private Label lblPartidaIni;
        private NumericUpDown numTomo;
        private Label lblTomo;
        private NumericUpDown numAnio;
        private Label lblAnio;
        private ComboBox cmbTipoLibro;
        private Label lblTipo;
        private Button btnImprimirEtiqueta;
    }
}