namespace GestionArchivoRegistroPropiedad
{
    partial class ReporteLibrosForm
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
            lblTipo = new Label();
            lblHasta = new Label();
            lblDesde = new Label();
            lblTotales = new Label();
            cmbTipo = new ComboBox();
            chkUsarFechas = new CheckBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnGenerar = new Button();
            btnExportarPDF = new Button();
            btnImprimir = new Button();
            dgvReporte = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(42, 62);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(80, 15);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de Libro:";
            lblTipo.Click += lblTipo_Click;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(418, 109);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 1;
            lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(43, 107);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 2;
            lblDesde.Text = "Desde:";
            // 
            // lblTotales
            // 
            lblTotales.AutoSize = true;
            lblTotales.Location = new Point(295, 383);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(77, 15);
            lblTotales.TabIndex = 3;
            lblTotales.Text = "Total: 0 libros";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Propiedad", "Sentencias", "Protocolos", "Poderes", "Hipotecas", "Otros" });
            cmbTipo.Location = new Point(149, 62);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(121, 23);
            cmbTipo.TabIndex = 4;
            // 
            // chkUsarFechas
            // 
            chkUsarFechas.AutoSize = true;
            chkUsarFechas.Location = new Point(331, 64);
            chkUsarFechas.Name = "chkUsarFechas";
            chkUsarFechas.Size = new Size(164, 19);
            chkUsarFechas.TabIndex = 5;
            chkUsarFechas.Text = "Filtrar por rango de fechas";
            chkUsarFechas.UseVisualStyleBackColor = true;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(109, 101);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(200, 23);
            dtpDesde.TabIndex = 6;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(501, 103);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(200, 23);
            dtpHasta.TabIndex = 7;
            dtpHasta.ValueChanged += dtpHasta_ValueChanged;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = SystemColors.ActiveCaption;
            btnGenerar.Location = new Point(195, 415);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(75, 23);
            btnGenerar.TabIndex = 8;
            btnGenerar.Text = "Generar Reporte";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Location = new Point(313, 415);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(75, 23);
            btnExportarPDF.TabIndex = 9;
            btnExportarPDF.Text = "Exportar a PDF";
            btnExportarPDF.UseVisualStyleBackColor = true;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(437, 415);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(-2, 156);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.Size = new Size(802, 209);
            dgvReporte.TabIndex = 11;
            dgvReporte.CellContentClick += dgvReporte_CellContentClick;
            // 
            // ReporteLibrosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvReporte);
            Controls.Add(btnImprimir);
            Controls.Add(btnExportarPDF);
            Controls.Add(btnGenerar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(chkUsarFechas);
            Controls.Add(cmbTipo);
            Controls.Add(lblTotales);
            Controls.Add(lblDesde);
            Controls.Add(lblHasta);
            Controls.Add(lblTipo);
            Name = "ReporteLibrosForm";
            Text = "ReporteLibrosForm";
            Load += ReporteLibrosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipo;
        private Label lblHasta;
        private Label lblDesde;
        private Label lblTotales;
        private ComboBox cmbTipo;
        private CheckBox chkUsarFechas;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnGenerar;
        private Button btnExportarPDF;
        private Button btnImprimir;
        private DataGridView dgvReporte;
    }
}