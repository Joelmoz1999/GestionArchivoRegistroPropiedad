namespace GestionArchivoRegistroPropiedad
{
    partial class GestionCustodiaForm
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
            tabControlCustodia = new TabControl();
            tabPrestamo = new TabPage();
            splitContainer1 = new SplitContainer();
            dgvLibrosDisponibles = new DataGridView();
            btnFiltrarLibros = new Button();
            cmbFiltrarTipo = new ComboBox();
            lblFiltrarTipo = new Label();
            btnLimpiarPrestamo = new Button();
            btnRegistrarPrestamo = new Button();
            txtObservacionesPrestamo = new TextBox();
            dtpFechaPrestamo = new DateTimePicker();
            cmbFuncionario = new ComboBox();
            lblObservacionesPrestamo = new Label();
            lblFechaPrestamo = new Label();
            lblFuncionario = new Label();
            lblCodigoSeleccionado = new Label();
            lblInfoLibro = new Label();
            tabDevolucion = new TabPage();
            txtObservacionesDevolucion = new TextBox();
            txtBuscarDevolucion = new TextBox();
            lblObservacionesDevolucion = new Label();
            lblInfoDevolucion = new Label();
            lblBuscarDevolucion = new Label();
            btnRegistrarDevolucion = new Button();
            btnBuscarDevolucion = new Button();
            tabHistorial = new TabPage();
            dgvHistorial = new DataGridView();
            btnExportarHistorial = new Button();
            btnLimpiarFiltrosHistorial = new Button();
            btnFiltrarHistorial = new Button();
            txtFiltrarCodigoHistorial = new TextBox();
            cmbFiltrarFuncionario = new ComboBox();
            cmbEstadoHistorial = new ComboBox();
            lblTotalHistorial = new Label();
            lblFiltrarCodigoHistorial = new Label();
            lblFiltrarFuncionario = new Label();
            lblEstadoHistorial = new Label();
            tabControlCustodia.SuspendLayout();
            tabPrestamo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibrosDisponibles).BeginInit();
            tabDevolucion.SuspendLayout();
            tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // tabControlCustodia
            // 
            tabControlCustodia.Controls.Add(tabPrestamo);
            tabControlCustodia.Controls.Add(tabDevolucion);
            tabControlCustodia.Controls.Add(tabHistorial);
            tabControlCustodia.Dock = DockStyle.Fill;
            tabControlCustodia.Location = new Point(0, 0);
            tabControlCustodia.Name = "tabControlCustodia";
            tabControlCustodia.SelectedIndex = 0;
            tabControlCustodia.Size = new Size(1055, 547);
            tabControlCustodia.TabIndex = 0;
            // 
            // tabPrestamo
            // 
            tabPrestamo.Controls.Add(splitContainer1);
            tabPrestamo.Location = new Point(4, 24);
            tabPrestamo.Name = "tabPrestamo";
            tabPrestamo.Padding = new Padding(3);
            tabPrestamo.Size = new Size(1047, 519);
            tabPrestamo.TabIndex = 0;
            tabPrestamo.Text = "Registrar Préstamo";
            tabPrestamo.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvLibrosDisponibles);
            splitContainer1.Panel1.Controls.Add(btnFiltrarLibros);
            splitContainer1.Panel1.Controls.Add(cmbFiltrarTipo);
            splitContainer1.Panel1.Controls.Add(lblFiltrarTipo);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnLimpiarPrestamo);
            splitContainer1.Panel2.Controls.Add(btnRegistrarPrestamo);
            splitContainer1.Panel2.Controls.Add(txtObservacionesPrestamo);
            splitContainer1.Panel2.Controls.Add(dtpFechaPrestamo);
            splitContainer1.Panel2.Controls.Add(cmbFuncionario);
            splitContainer1.Panel2.Controls.Add(lblObservacionesPrestamo);
            splitContainer1.Panel2.Controls.Add(lblFechaPrestamo);
            splitContainer1.Panel2.Controls.Add(lblFuncionario);
            splitContainer1.Panel2.Controls.Add(lblCodigoSeleccionado);
            splitContainer1.Panel2.Controls.Add(lblInfoLibro);
            splitContainer1.Size = new Size(1041, 513);
            splitContainer1.SplitterDistance = 491;
            splitContainer1.TabIndex = 0;
            // 
            // dgvLibrosDisponibles
            // 
            dgvLibrosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibrosDisponibles.Location = new Point(-3, 121);
            dgvLibrosDisponibles.Name = "dgvLibrosDisponibles";
            dgvLibrosDisponibles.ReadOnly = true;
            dgvLibrosDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibrosDisponibles.Size = new Size(491, 387);
            dgvLibrosDisponibles.TabIndex = 3;
            dgvLibrosDisponibles.SelectionChanged += dgvLibrosDisponibles_SelectionChanged;
            // 
            // btnFiltrarLibros
            // 
            btnFiltrarLibros.Location = new Point(281, 61);
            btnFiltrarLibros.Name = "btnFiltrarLibros";
            btnFiltrarLibros.Size = new Size(86, 31);
            btnFiltrarLibros.TabIndex = 2;
            btnFiltrarLibros.Text = "Filtrar";
            btnFiltrarLibros.UseVisualStyleBackColor = true;
            btnFiltrarLibros.Click += btnFiltrarLibros_Click;
            // 
            // cmbFiltrarTipo
            // 
            cmbFiltrarTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltrarTipo.FormattingEnabled = true;
            cmbFiltrarTipo.Location = new Point(97, 66);
            cmbFiltrarTipo.Name = "cmbFiltrarTipo";
            cmbFiltrarTipo.Size = new Size(178, 23);
            cmbFiltrarTipo.TabIndex = 1;
            // 
            // lblFiltrarTipo
            // 
            lblFiltrarTipo.AutoSize = true;
            lblFiltrarTipo.Location = new Point(3, 66);
            lblFiltrarTipo.Name = "lblFiltrarTipo";
            lblFiltrarTipo.Size = new Size(88, 15);
            lblFiltrarTipo.TabIndex = 0;
            lblFiltrarTipo.Text = "Filtrar por Tipo:";
            // 
            // btnLimpiarPrestamo
            // 
            btnLimpiarPrestamo.Location = new Point(331, 354);
            btnLimpiarPrestamo.Name = "btnLimpiarPrestamo";
            btnLimpiarPrestamo.Size = new Size(93, 47);
            btnLimpiarPrestamo.TabIndex = 10;
            btnLimpiarPrestamo.Text = "Limpiar";
            btnLimpiarPrestamo.UseVisualStyleBackColor = true;
            btnLimpiarPrestamo.Click += btnLimpiarPrestamo_Click;
            // 
            // btnRegistrarPrestamo
            // 
            btnRegistrarPrestamo.BackColor = Color.YellowGreen;
            btnRegistrarPrestamo.Enabled = false;
            btnRegistrarPrestamo.Location = new Point(179, 354);
            btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            btnRegistrarPrestamo.Size = new Size(99, 47);
            btnRegistrarPrestamo.TabIndex = 9;
            btnRegistrarPrestamo.Text = "Registrar Préstamo";
            btnRegistrarPrestamo.UseVisualStyleBackColor = false;
            btnRegistrarPrestamo.Click += btnRegistrarPrestamo_Click;
            // 
            // txtObservacionesPrestamo
            // 
            txtObservacionesPrestamo.Location = new Point(226, 275);
            txtObservacionesPrestamo.Multiline = true;
            txtObservacionesPrestamo.Name = "txtObservacionesPrestamo";
            txtObservacionesPrestamo.Size = new Size(277, 23);
            txtObservacionesPrestamo.TabIndex = 8;
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Location = new Point(226, 214);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(229, 23);
            dtpFechaPrestamo.TabIndex = 7;
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(226, 155);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(121, 23);
            cmbFuncionario.TabIndex = 6;
            // 
            // lblObservacionesPrestamo
            // 
            lblObservacionesPrestamo.AutoSize = true;
            lblObservacionesPrestamo.Location = new Point(122, 275);
            lblObservacionesPrestamo.Name = "lblObservacionesPrestamo";
            lblObservacionesPrestamo.Size = new Size(87, 15);
            lblObservacionesPrestamo.TabIndex = 5;
            lblObservacionesPrestamo.Text = "Observaciones:";
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Location = new Point(110, 220);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(110, 15);
            lblFechaPrestamo.TabIndex = 4;
            lblFechaPrestamo.Text = "Fecha de Préstamo:";
            // 
            // lblFuncionario
            // 
            lblFuncionario.AutoSize = true;
            lblFuncionario.Location = new Point(136, 155);
            lblFuncionario.Name = "lblFuncionario";
            lblFuncionario.Size = new Size(73, 15);
            lblFuncionario.TabIndex = 3;
            lblFuncionario.Text = "Funcionario:";
            // 
            // lblCodigoSeleccionado
            // 
            lblCodigoSeleccionado.AutoSize = true;
            lblCodigoSeleccionado.Location = new Point(39, 66);
            lblCodigoSeleccionado.Name = "lblCodigoSeleccionado";
            lblCodigoSeleccionado.Size = new Size(0, 15);
            lblCodigoSeleccionado.TabIndex = 2;
            // 
            // lblInfoLibro
            // 
            lblInfoLibro.AutoSize = true;
            lblInfoLibro.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoLibro.Location = new Point(217, 94);
            lblInfoLibro.Name = "lblInfoLibro";
            lblInfoLibro.Size = new Size(142, 15);
            lblInfoLibro.TabIndex = 1;
            lblInfoLibro.Text = "📖 Sin libro seleccionado\"";
            // 
            // tabDevolucion
            // 
            tabDevolucion.Controls.Add(txtObservacionesDevolucion);
            tabDevolucion.Controls.Add(txtBuscarDevolucion);
            tabDevolucion.Controls.Add(lblObservacionesDevolucion);
            tabDevolucion.Controls.Add(lblInfoDevolucion);
            tabDevolucion.Controls.Add(lblBuscarDevolucion);
            tabDevolucion.Controls.Add(btnRegistrarDevolucion);
            tabDevolucion.Controls.Add(btnBuscarDevolucion);
            tabDevolucion.Location = new Point(4, 24);
            tabDevolucion.Name = "tabDevolucion";
            tabDevolucion.Padding = new Padding(3);
            tabDevolucion.Size = new Size(1047, 519);
            tabDevolucion.TabIndex = 1;
            tabDevolucion.Text = "Registrar Devolución";
            tabDevolucion.UseVisualStyleBackColor = true;
            // 
            // txtObservacionesDevolucion
            // 
            txtObservacionesDevolucion.Location = new Point(320, 307);
            txtObservacionesDevolucion.Multiline = true;
            txtObservacionesDevolucion.Name = "txtObservacionesDevolucion";
            txtObservacionesDevolucion.Size = new Size(376, 23);
            txtObservacionesDevolucion.TabIndex = 6;
            // 
            // txtBuscarDevolucion
            // 
            txtBuscarDevolucion.Location = new Point(320, 65);
            txtBuscarDevolucion.Name = "txtBuscarDevolucion";
            txtBuscarDevolucion.Size = new Size(100, 23);
            txtBuscarDevolucion.TabIndex = 5;
            // 
            // lblObservacionesDevolucion
            // 
            lblObservacionesDevolucion.AutoSize = true;
            lblObservacionesDevolucion.Location = new Point(136, 310);
            lblObservacionesDevolucion.Name = "lblObservacionesDevolucion";
            lblObservacionesDevolucion.Size = new Size(166, 15);
            lblObservacionesDevolucion.TabIndex = 4;
            lblObservacionesDevolucion.Text = "Observaciones de Devolución:";
            // 
            // lblInfoDevolucion
            // 
            lblInfoDevolucion.AutoSize = true;
            lblInfoDevolucion.Location = new Point(332, 140);
            lblInfoDevolucion.Name = "lblInfoDevolucion";
            lblInfoDevolucion.Size = new Size(0, 15);
            lblInfoDevolucion.TabIndex = 3;
            // 
            // lblBuscarDevolucion
            // 
            lblBuscarDevolucion.AutoSize = true;
            lblBuscarDevolucion.Location = new Point(143, 68);
            lblBuscarDevolucion.Name = "lblBuscarDevolucion";
            lblBuscarDevolucion.Size = new Size(159, 15);
            lblBuscarDevolucion.TabIndex = 2;
            lblBuscarDevolucion.Text = "Buscar por Código de Barras:";
            // 
            // btnRegistrarDevolucion
            // 
            btnRegistrarDevolucion.Enabled = false;
            btnRegistrarDevolucion.Location = new Point(358, 361);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Size = new Size(94, 31);
            btnRegistrarDevolucion.TabIndex = 1;
            btnRegistrarDevolucion.Text = "Registrar Devolución";
            btnRegistrarDevolucion.UseVisualStyleBackColor = true;
            btnRegistrarDevolucion.Click += btnRegistrarDevolucion_Click;
            // 
            // btnBuscarDevolucion
            // 
            btnBuscarDevolucion.Location = new Point(489, 64);
            btnBuscarDevolucion.Name = "btnBuscarDevolucion";
            btnBuscarDevolucion.Size = new Size(75, 23);
            btnBuscarDevolucion.TabIndex = 0;
            btnBuscarDevolucion.Text = "Buscar";
            btnBuscarDevolucion.UseVisualStyleBackColor = true;
            btnBuscarDevolucion.Click += btnBuscarDevolucion_Click;
            // 
            // tabHistorial
            // 
            tabHistorial.Controls.Add(dgvHistorial);
            tabHistorial.Controls.Add(btnExportarHistorial);
            tabHistorial.Controls.Add(btnLimpiarFiltrosHistorial);
            tabHistorial.Controls.Add(btnFiltrarHistorial);
            tabHistorial.Controls.Add(txtFiltrarCodigoHistorial);
            tabHistorial.Controls.Add(cmbFiltrarFuncionario);
            tabHistorial.Controls.Add(cmbEstadoHistorial);
            tabHistorial.Controls.Add(lblTotalHistorial);
            tabHistorial.Controls.Add(lblFiltrarCodigoHistorial);
            tabHistorial.Controls.Add(lblFiltrarFuncionario);
            tabHistorial.Controls.Add(lblEstadoHistorial);
            tabHistorial.Location = new Point(4, 24);
            tabHistorial.Name = "tabHistorial";
            tabHistorial.Padding = new Padding(3);
            tabHistorial.Size = new Size(1047, 519);
            tabHistorial.TabIndex = 2;
            tabHistorial.Text = "Historial de Custodias";
            tabHistorial.UseVisualStyleBackColor = true;
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(0, 97);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(1051, 248);
            dgvHistorial.TabIndex = 10;
            // 
            // btnExportarHistorial
            // 
            btnExportarHistorial.Location = new Point(633, 400);
            btnExportarHistorial.Name = "btnExportarHistorial";
            btnExportarHistorial.Size = new Size(102, 45);
            btnExportarHistorial.TabIndex = 9;
            btnExportarHistorial.Text = "Exportar a Excel";
            btnExportarHistorial.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarFiltrosHistorial
            // 
            btnLimpiarFiltrosHistorial.Location = new Point(474, 400);
            btnLimpiarFiltrosHistorial.Name = "btnLimpiarFiltrosHistorial";
            btnLimpiarFiltrosHistorial.Size = new Size(118, 45);
            btnLimpiarFiltrosHistorial.TabIndex = 8;
            btnLimpiarFiltrosHistorial.Text = "Limpiar Filtros";
            btnLimpiarFiltrosHistorial.UseVisualStyleBackColor = true;
            btnLimpiarFiltrosHistorial.Click += btnLimpiarFiltrosHistorial_Click;
            // 
            // btnFiltrarHistorial
            // 
            btnFiltrarHistorial.Location = new Point(338, 400);
            btnFiltrarHistorial.Name = "btnFiltrarHistorial";
            btnFiltrarHistorial.Size = new Size(109, 45);
            btnFiltrarHistorial.TabIndex = 7;
            btnFiltrarHistorial.Text = "Filtrar";
            btnFiltrarHistorial.UseVisualStyleBackColor = true;
            btnFiltrarHistorial.Click += btnFiltrarHistorial_Click;
            // 
            // txtFiltrarCodigoHistorial
            // 
            txtFiltrarCodigoHistorial.Location = new Point(796, 51);
            txtFiltrarCodigoHistorial.Name = "txtFiltrarCodigoHistorial";
            txtFiltrarCodigoHistorial.Size = new Size(136, 23);
            txtFiltrarCodigoHistorial.TabIndex = 6;
            // 
            // cmbFiltrarFuncionario
            // 
            cmbFiltrarFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltrarFuncionario.FormattingEnabled = true;
            cmbFiltrarFuncionario.Location = new Point(428, 53);
            cmbFiltrarFuncionario.Name = "cmbFiltrarFuncionario";
            cmbFiltrarFuncionario.Size = new Size(121, 23);
            cmbFiltrarFuncionario.TabIndex = 5;
            // 
            // cmbEstadoHistorial
            // 
            cmbEstadoHistorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoHistorial.FormattingEnabled = true;
            cmbEstadoHistorial.Items.AddRange(new object[] { "Todos", "En Custodia", "Devueltos" });
            cmbEstadoHistorial.Location = new Point(93, 53);
            cmbEstadoHistorial.Name = "cmbEstadoHistorial";
            cmbEstadoHistorial.Size = new Size(139, 23);
            cmbEstadoHistorial.TabIndex = 4;
            // 
            // lblTotalHistorial
            // 
            lblTotalHistorial.AutoSize = true;
            lblTotalHistorial.Location = new Point(483, 348);
            lblTotalHistorial.Name = "lblTotalHistorial";
            lblTotalHistorial.Size = new Size(109, 15);
            lblTotalHistorial.TabIndex = 3;
            lblTotalHistorial.Text = "Total de registros: 0";
            lblTotalHistorial.Click += lblTotalHistorial_Click;
            // 
            // lblFiltrarCodigoHistorial
            // 
            lblFiltrarCodigoHistorial.AutoSize = true;
            lblFiltrarCodigoHistorial.Location = new Point(660, 59);
            lblFiltrarCodigoHistorial.Name = "lblFiltrarCodigoHistorial";
            lblFiltrarCodigoHistorial.Size = new Size(100, 15);
            lblFiltrarCodigoHistorial.TabIndex = 2;
            lblFiltrarCodigoHistorial.Text = "Código de Barras:";
            // 
            // lblFiltrarFuncionario
            // 
            lblFiltrarFuncionario.AutoSize = true;
            lblFiltrarFuncionario.Location = new Point(349, 59);
            lblFiltrarFuncionario.Name = "lblFiltrarFuncionario";
            lblFiltrarFuncionario.Size = new Size(73, 15);
            lblFiltrarFuncionario.TabIndex = 1;
            lblFiltrarFuncionario.Text = "Funcionario:";
            // 
            // lblEstadoHistorial
            // 
            lblEstadoHistorial.AutoSize = true;
            lblEstadoHistorial.Location = new Point(42, 62);
            lblEstadoHistorial.Name = "lblEstadoHistorial";
            lblEstadoHistorial.Size = new Size(45, 15);
            lblEstadoHistorial.TabIndex = 0;
            lblEstadoHistorial.Text = "Estado:";
            // 
            // GestionCustodiaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 547);
            Controls.Add(tabControlCustodia);
            Name = "GestionCustodiaForm";
            Text = "GestionCustodiaForm";
            Load += GestionCustodiaForm_Load;
            tabControlCustodia.ResumeLayout(false);
            tabPrestamo.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLibrosDisponibles).EndInit();
            tabDevolucion.ResumeLayout(false);
            tabDevolucion.PerformLayout();
            tabHistorial.ResumeLayout(false);
            tabHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlCustodia;
        private TabPage tabPrestamo;
        private TabPage tabDevolucion;
        private SplitContainer splitContainer1;
        private DataGridView dgvLibrosDisponibles;
        private Button btnFiltrarLibros;
        private ComboBox cmbFiltrarTipo;
        private Label lblFiltrarTipo;
        private Label lblObservacionesPrestamo;
        private Label lblFechaPrestamo;
        private Label lblFuncionario;
        private Label lblCodigoSeleccionado;
        private Label lblInfoLibro;
        private ComboBox cmbFuncionario;
        private DateTimePicker dtpFechaPrestamo;
        private Button btnLimpiarPrestamo;
        private Button btnRegistrarPrestamo;
        private TextBox txtObservacionesPrestamo;
        private TextBox txtObservacionesDevolucion;
        private TextBox txtBuscarDevolucion;
        private Label lblObservacionesDevolucion;
        private Label lblInfoDevolucion;
        private Label lblBuscarDevolucion;
        private Button btnRegistrarDevolucion;
        private Button btnBuscarDevolucion;
        private TabPage tabHistorial;
        private TextBox txtFiltrarCodigoHistorial;
        private ComboBox cmbFiltrarFuncionario;
        private ComboBox cmbEstadoHistorial;
        private Label lblTotalHistorial;
        private Label lblFiltrarCodigoHistorial;
        private Label lblFiltrarFuncionario;
        private Label lblEstadoHistorial;
        private DataGridView dgvHistorial;
        private Button btnExportarHistorial;
        private Button btnLimpiarFiltrosHistorial;
        private Button btnFiltrarHistorial;
    }
}