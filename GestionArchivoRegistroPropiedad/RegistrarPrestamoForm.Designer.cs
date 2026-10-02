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
            splitContainer1.Panel1.Controls.Add(dgvLibrosDisponibles);
            splitContainer1.Panel1.Controls.Add(btnFiltrar);
            splitContainer1.Panel1.Controls.Add(cmbFiltrarTipo);
            splitContainer1.Panel1.Controls.Add(lblFiltrarTipo);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
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
            splitContainer1.SplitterDistance = 481;
            splitContainer1.TabIndex = 0;
            // 
            // dgvLibrosDisponibles
            // 
            dgvLibrosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibrosDisponibles.Location = new Point(0, 149);
            dgvLibrosDisponibles.Name = "dgvLibrosDisponibles";
            dgvLibrosDisponibles.ReadOnly = true;
            dgvLibrosDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibrosDisponibles.Size = new Size(478, 387);
            dgvLibrosDisponibles.TabIndex = 7;
            dgvLibrosDisponibles.CellContentClick += dgvLibrosDisponibles_CellContentClick;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(357, 44);
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
            cmbFiltrarTipo.Location = new Point(157, 49);
            cmbFiltrarTipo.Name = "cmbFiltrarTipo";
            cmbFiltrarTipo.Size = new Size(178, 23);
            cmbFiltrarTipo.TabIndex = 5;
            // 
            // lblFiltrarTipo
            // 
            lblFiltrarTipo.AutoSize = true;
            lblFiltrarTipo.Location = new Point(38, 52);
            lblFiltrarTipo.Name = "lblFiltrarTipo";
            lblFiltrarTipo.Size = new Size(88, 15);
            lblFiltrarTipo.TabIndex = 4;
            lblFiltrarTipo.Text = "Filtrar por Tipo:";
            // 
            // btnLimpiarPrestamo
            // 
            btnLimpiarPrestamo.Location = new Point(288, 375);
            btnLimpiarPrestamo.Name = "btnLimpiarPrestamo";
            btnLimpiarPrestamo.Size = new Size(93, 47);
            btnLimpiarPrestamo.TabIndex = 19;
            btnLimpiarPrestamo.Text = "Limpiar";
            btnLimpiarPrestamo.UseVisualStyleBackColor = true;
            btnLimpiarPrestamo.Click += btnLimpiar_Click;
            // 
            // btnRegistrarPrestamo
            // 
            btnRegistrarPrestamo.BackColor = Color.YellowGreen;
            btnRegistrarPrestamo.Enabled = false;
            btnRegistrarPrestamo.Location = new Point(136, 375);
            btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            btnRegistrarPrestamo.Size = new Size(99, 47);
            btnRegistrarPrestamo.TabIndex = 18;
            btnRegistrarPrestamo.Text = "Registrar Préstamo";
            btnRegistrarPrestamo.UseVisualStyleBackColor = false;
            btnRegistrarPrestamo.Click += btnRegistrarPrestamo_Click;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(183, 296);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(277, 23);
            txtObservaciones.TabIndex = 17;
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Location = new Point(183, 235);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(229, 23);
            dtpFechaPrestamo.TabIndex = 16;
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(183, 176);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(121, 23);
            cmbFuncionario.TabIndex = 15;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(79, 296);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(87, 15);
            lblObservaciones.TabIndex = 14;
            lblObservaciones.Text = "Observaciones:";
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Location = new Point(67, 241);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(110, 15);
            lblFechaPrestamo.TabIndex = 13;
            lblFechaPrestamo.Text = "Fecha de Préstamo:";
            // 
            // lblFuncionario
            // 
            lblFuncionario.AutoSize = true;
            lblFuncionario.Location = new Point(93, 176);
            lblFuncionario.Name = "lblFuncionario";
            lblFuncionario.Size = new Size(73, 15);
            lblFuncionario.TabIndex = 12;
            lblFuncionario.Text = "Funcionario:";
            // 
            // lblInfoLibro
            // 
            lblInfoLibro.AutoSize = true;
            lblInfoLibro.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoLibro.Location = new Point(174, 115);
            lblInfoLibro.Name = "lblInfoLibro";
            lblInfoLibro.Size = new Size(142, 15);
            lblInfoLibro.TabIndex = 11;
            lblInfoLibro.Text = "📖 Sin libro seleccionado\"";
            // 
            // RegistrarPrestamoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 536);
            Controls.Add(splitContainer1);
            Name = "RegistrarPrestamoForm";
            Text = "RegistrarPrestamoForm";
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
    }
}