namespace GestionArchivoRegistroPropiedad
{
    partial class ReporteCustodiasForm
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
            lblEstado = new Label();
            lblFuncionario = new Label();
            lblDesde = new Label();
            lblHasta = new Label();
            lblTotales = new Label();
            cmbEstado = new ComboBox();
            cmbFuncionario = new ComboBox();
            chkUsarFechas = new CheckBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnGenerar = new Button();
            btnExportarPDF = new Button();
            dgvReporte = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(41, 64);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Estado:";
            // 
            // lblFuncionario
            // 
            lblFuncionario.AutoSize = true;
            lblFuncionario.Location = new Point(357, 69);
            lblFuncionario.Name = "lblFuncionario";
            lblFuncionario.Size = new Size(73, 15);
            lblFuncionario.TabIndex = 1;
            lblFuncionario.Text = "Funcionario:";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(44, 156);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 2;
            lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(387, 156);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 3;
            lblHasta.Text = "Hasta:";
            // 
            // lblTotales
            // 
            lblTotales.AutoSize = true;
            lblTotales.Location = new Point(333, 378);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(45, 15);
            lblTotales.TabIndex = 4;
            lblTotales.Text = "Total: 0";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Todos", "En Custodia", "Devueltos" });
            cmbEstado.Location = new Point(137, 64);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 5;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(436, 66);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(121, 23);
            cmbFuncionario.TabIndex = 6;
            cmbFuncionario.SelectedIndexChanged += cmbFuncionario_SelectedIndexChanged;
            // 
            // chkUsarFechas
            // 
            chkUsarFechas.AutoSize = true;
            chkUsarFechas.Location = new Point(51, 116);
            chkUsarFechas.Name = "chkUsarFechas";
            chkUsarFechas.Size = new Size(164, 19);
            chkUsarFechas.TabIndex = 7;
            chkUsarFechas.Text = "Filtrar por rango de fechas";
            chkUsarFechas.UseVisualStyleBackColor = true;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(120, 150);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(222, 23);
            dtpDesde.TabIndex = 8;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(463, 150);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(244, 23);
            dtpHasta.TabIndex = 9;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(239, 396);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(103, 31);
            btnGenerar.TabIndex = 10;
            btnGenerar.Text = "Generar Reporte";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Location = new Point(358, 396);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(142, 31);
            btnExportarPDF.TabIndex = 11;
            btnExportarPDF.Text = "Exportar a PDF";
            btnExportarPDF.UseVisualStyleBackColor = true;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(0, 179);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(797, 196);
            dgvReporte.TabIndex = 12;
            dgvReporte.CellContentClick += dgvReporte_CellContentClick;
            // 
            // ReporteCustodiasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvReporte);
            Controls.Add(btnExportarPDF);
            Controls.Add(btnGenerar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(chkUsarFechas);
            Controls.Add(cmbFuncionario);
            Controls.Add(cmbEstado);
            Controls.Add(lblTotales);
            Controls.Add(lblHasta);
            Controls.Add(lblDesde);
            Controls.Add(lblFuncionario);
            Controls.Add(lblEstado);
            Name = "ReporteCustodiasForm";
            Text = "ReporteCustodiasForm";
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEstado;
        private Label lblFuncionario;
        private Label lblDesde;
        private Label lblHasta;
        private Label lblTotales;
        private ComboBox cmbEstado;
        private ComboBox cmbFuncionario;
        private CheckBox chkUsarFechas;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnGenerar;
        private Button btnExportarPDF;
        private DataGridView dgvReporte;
    }
}