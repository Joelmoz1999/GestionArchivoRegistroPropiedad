namespace GestionArchivoRegistroPropiedad
{
    partial class HistorialCustodiasForm
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
            dgvHistorial = new DataGridView();
            btnLimpiarFiltros = new Button();
            btnFiltrar = new Button();
            txtCodigo = new TextBox();
            cmbFuncionario = new ComboBox();
            cmbEstado = new ComboBox();
            lblTotales = new Label();
            lblCodigo = new Label();
            lblFuncionario = new Label();
            lblEstado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(-5, 103);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(1051, 248);
            dgvHistorial.TabIndex = 21;
            dgvHistorial.CellContentClick += dgvHistorial_CellContentClick;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(578, 406);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(118, 45);
            btnLimpiarFiltros.TabIndex = 19;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(393, 406);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(109, 45);
            btnFiltrar.TabIndex = 18;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(791, 57);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(136, 23);
            txtCodigo.TabIndex = 17;
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(423, 59);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(121, 23);
            cmbFuncionario.TabIndex = 16;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Todos", "En Custodia", "Devueltos" });
            cmbEstado.Location = new Point(88, 59);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(139, 23);
            cmbEstado.TabIndex = 15;
            // 
            // lblTotales
            // 
            lblTotales.AutoSize = true;
            lblTotales.Location = new Point(478, 354);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(109, 15);
            lblTotales.TabIndex = 14;
            lblTotales.Text = "Total de registros: 0";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(655, 65);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(100, 15);
            lblCodigo.TabIndex = 13;
            lblCodigo.Text = "Código de Barras:";
            // 
            // lblFuncionario
            // 
            lblFuncionario.AutoSize = true;
            lblFuncionario.Location = new Point(344, 65);
            lblFuncionario.Name = "lblFuncionario";
            lblFuncionario.Size = new Size(73, 15);
            lblFuncionario.TabIndex = 12;
            lblFuncionario.Text = "Funcionario:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(37, 68);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 11;
            lblEstado.Text = "Estado:";
            // 
            // HistorialCustodiasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 509);
            Controls.Add(dgvHistorial);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(btnFiltrar);
            Controls.Add(txtCodigo);
            Controls.Add(cmbFuncionario);
            Controls.Add(cmbEstado);
            Controls.Add(lblTotales);
            Controls.Add(lblCodigo);
            Controls.Add(lblFuncionario);
            Controls.Add(lblEstado);
            Name = "HistorialCustodiasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial Custodias";
            Load += HistorialCustodiasForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHistorial;
        private Button btnExportarHistorial;
        private Button btnLimpiarFiltros;
        private Button btnFiltrar;
        private TextBox txtCodigo;
        private ComboBox cmbFuncionario;
        private ComboBox cmbEstado;
        private Label lblTotales;
        private Label lblCodigo;
        private Label lblFuncionario;
        private Label lblEstado;
    }
}