namespace GestionArchivoRegistroPropiedad
{
    partial class RegistrarPrestamoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarPrestamoForm));
            splitContainer1 = new SplitContainer();
            dgvLibrosDisponibles = new DataGridView();
            btnFiltrar = new Button();
            cmbFiltrarTipo = new ComboBox();
            lblFiltrarTipo = new Label();
            btnLimpiarPrestamo = new Button();
            btnRegistrarPrestamo = new Button();
            txtObservaciones = new TextBox();
            dtpFechaPrestamo = new DateTimePicker();
            cmbFuncionario = new ComboBox();
            lblObservaciones = new Label();
            lblFechaPrestamo = new Label();
            lblFuncionario = new Label();
            lblInfoLibro = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibrosDisponibles).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(dgvLibrosDisponibles);
            splitContainer1.Panel1.Controls.Add(btnFiltrar);
            splitContainer1.Panel1.Controls.Add(cmbFiltrarTipo);
            splitContainer1.Panel1.Controls.Add(lblFiltrarTipo);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(btnLimpiarPrestamo);
            splitContainer1.Panel2.Controls.Add(btnRegistrarPrestamo);
            splitContainer1.Panel2.Controls.Add(txtObservaciones);
            splitContainer1.Panel2.Controls.Add(dtpFechaPrestamo);
            splitContainer1.Panel2.Controls.Add(cmbFuncionario);
            splitContainer1.Panel2.Controls.Add(lblObservaciones);
            splitContainer1.Panel2.Controls.Add(lblFechaPrestamo);
            splitContainer1.Panel2.Controls.Add(lblFuncionario);
            splitContainer1.Panel2.Controls.Add(lblInfoLibro);
            splitContainer1.Size = new Size(1011, 536);
            splitContainer1.SplitterDistance = 611;
            splitContainer1.TabIndex = 0;
            // 
            // dgvLibrosDisponibles
            // 
            dgvLibrosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibrosDisponibles.Location = new Point(0, 149);
            dgvLibrosDisponibles.Name = "dgvLibrosDisponibles";
            dgvLibrosDisponibles.ReadOnly = true;
            dgvLibrosDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibrosDisponibles.Size = new Size(608, 387);
            dgvLibrosDisponibles.TabIndex = 7;
            dgvLibrosDisponibles.CellContentClick += dgvLibrosDisponibles_CellContentClick;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(365, 87);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(86, 31);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // cmbFiltrarTipo
            // 
            cmbFiltrarTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltrarTipo.FormattingEnabled = true;
            cmbFiltrarTipo.Location = new Point(165, 92);
            cmbFiltrarTipo.Name = "cmbFiltrarTipo";
            cmbFiltrarTipo.Size = new Size(178, 23);
            cmbFiltrarTipo.TabIndex = 5;
            // 
            // lblFiltrarTipo
            // 
            lblFiltrarTipo.AutoSize = true;
            lblFiltrarTipo.Location = new Point(46, 95);
            lblFiltrarTipo.Name = "lblFiltrarTipo";
            lblFiltrarTipo.Size = new Size(88, 15);
            lblFiltrarTipo.TabIndex = 4;
            lblFiltrarTipo.Text = "Filtrar por Tipo:";
            // 
            // btnLimpiarPrestamo
            // 
            btnLimpiarPrestamo.Location = new Point(247, 348);
            btnLimpiarPrestamo.Name = "btnLimpiarPrestamo";
            btnLimpiarPrestamo.Size = new Size(79, 45);
            btnLimpiarPrestamo.TabIndex = 19;
            btnLimpiarPrestamo.Text = "Limpiar";
            btnLimpiarPrestamo.UseVisualStyleBackColor = true;
            btnLimpiarPrestamo.Click += btnLimpiar_Click;
            // 
            // btnRegistrarPrestamo
            // 
            btnRegistrarPrestamo.BackColor = Color.YellowGreen;
            btnRegistrarPrestamo.Enabled = false;
            btnRegistrarPrestamo.Location = new Point(99, 348);
            btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            btnRegistrarPrestamo.Size = new Size(100, 45);
            btnRegistrarPrestamo.TabIndex = 18;
            btnRegistrarPrestamo.Text = "Registrar Préstamo";
            btnRegistrarPrestamo.UseVisualStyleBackColor = false;
            btnRegistrarPrestamo.Click += btnRegistrarPrestamo_Click;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(130, 293);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(238, 23);
            txtObservaciones.TabIndex = 17;
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Location = new Point(128, 235);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(229, 23);
            dtpFechaPrestamo.TabIndex = 16;
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(130, 176);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(121, 23);
            cmbFuncionario.TabIndex = 15;
            cmbFuncionario.SelectedIndexChanged += cmbFuncionario_SelectedIndexChanged_1;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(35, 296);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(87, 15);
            lblObservaciones.TabIndex = 14;
            lblObservaciones.Text = "Observaciones:";
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Location = new Point(12, 241);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(110, 15);
            lblFechaPrestamo.TabIndex = 13;
            lblFechaPrestamo.Text = "Fecha de Préstamo:";
            // 
            // lblFuncionario
            // 
            lblFuncionario.AutoSize = true;
            lblFuncionario.Location = new Point(49, 176);
            lblFuncionario.Name = "lblFuncionario";
            lblFuncionario.Size = new Size(73, 15);
            lblFuncionario.TabIndex = 12;
            lblFuncionario.Text = "Funcionario:";
            // 
            // lblInfoLibro
            // 
            lblInfoLibro.AutoSize = true;
            lblInfoLibro.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoLibro.Location = new Point(109, 123);
            lblInfoLibro.Name = "lblInfoLibro";
            lblInfoLibro.Size = new Size(142, 15);
            lblInfoLibro.TabIndex = 11;
            lblInfoLibro.Text = "📖 Sin libro seleccionado\"";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(118, 64);
            label1.Name = "label1";
            label1.Size = new Size(177, 21);
            label1.TabIndex = 75;
            label1.Text = "REGISTRAR PRESTAMO ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(227, 42);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 76;
            label2.Text = "BUSCAR LIBRO";
            label2.Click += label2_Click;
            // 
            // RegistrarPrestamoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 536);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegistrarPrestamoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de la Propiedad del Cantón Pedro Vicente Maldonado | Registrar Prestamo";
            Load += RegistrarPrestamoForm_Load_1;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLibrosDisponibles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvLibrosDisponibles;
        private Button btnFiltrar;
        private ComboBox cmbFiltrarTipo;
        private Label lblFiltrarTipo;
        private Button btnLimpiarPrestamo;
        private Button btnRegistrarPrestamo;
        private TextBox txtObservaciones;
        private DateTimePicker dtpFechaPrestamo;
        private ComboBox cmbFuncionario;
        private Label lblObservaciones;
        private Label lblFechaPrestamo;
        private Label lblFuncionario;
        private Label lblInfoLibro;
        private Label label1;
        private Label label2;
    }
}