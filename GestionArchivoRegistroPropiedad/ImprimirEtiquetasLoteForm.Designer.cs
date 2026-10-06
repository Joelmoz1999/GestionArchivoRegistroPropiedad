namespace GestionArchivoRegistroPropiedad
{
    partial class mnuImprimirEtiquetas
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
            lblFiltroTipo = new Label();
            lblFiltroCodigo = new Label();
            lblTotalSeleccionados = new Label();
            cmbFiltroTipo = new ComboBox();
            txtFiltroCodigo = new TextBox();
            btnBuscarCodigo = new Button();
            btnMostrarTodos = new Button();
            btnSeleccionarTodos = new Button();
            btnDeseleccionarTodos = new Button();
            dgvLibros = new DataGridView();
            btnImprimirSeleccionados = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // lblFiltroTipo
            // 
            lblFiltroTipo.AutoSize = true;
            lblFiltroTipo.Location = new Point(13, 43);
            lblFiltroTipo.Name = "lblFiltroTipo";
            lblFiltroTipo.Size = new Size(88, 15);
            lblFiltroTipo.TabIndex = 0;
            lblFiltroTipo.Text = "Filtrar por Tipo:";
            // 
            // lblFiltroCodigo
            // 
            lblFiltroCodigo.AutoSize = true;
            lblFiltroCodigo.Location = new Point(346, 46);
            lblFiltroCodigo.Name = "lblFiltroCodigo";
            lblFiltroCodigo.Size = new Size(87, 15);
            lblFiltroCodigo.TabIndex = 1;
            lblFiltroCodigo.Text = "Buscar Código:";
            // 
            // lblTotalSeleccionados
            // 
            lblTotalSeleccionados.AutoSize = true;
            lblTotalSeleccionados.Location = new Point(339, 352);
            lblTotalSeleccionados.Name = "lblTotalSeleccionados";
            lblTotalSeleccionados.Size = new Size(94, 15);
            lblTotalSeleccionados.TabIndex = 2;
            lblTotalSeleccionados.Text = "Seleccionados: 0";
            // 
            // cmbFiltroTipo
            // 
            cmbFiltroTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroTipo.FormattingEnabled = true;
            cmbFiltroTipo.Location = new Point(129, 40);
            cmbFiltroTipo.Name = "cmbFiltroTipo";
            cmbFiltroTipo.Size = new Size(121, 23);
            cmbFiltroTipo.TabIndex = 3;
            // 
            // txtFiltroCodigo
            // 
            txtFiltroCodigo.Location = new Point(461, 43);
            txtFiltroCodigo.Name = "txtFiltroCodigo";
            txtFiltroCodigo.Size = new Size(100, 23);
            txtFiltroCodigo.TabIndex = 4;
            // 
            // btnBuscarCodigo
            // 
            btnBuscarCodigo.Location = new Point(573, 31);
            btnBuscarCodigo.Name = "btnBuscarCodigo";
            btnBuscarCodigo.Size = new Size(98, 39);
            btnBuscarCodigo.TabIndex = 5;
            btnBuscarCodigo.Text = "🔍 Buscar";
            btnBuscarCodigo.UseVisualStyleBackColor = true;
            btnBuscarCodigo.Click += btnBuscarCodigo_Click;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Location = new Point(694, 34);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(94, 38);
            btnMostrarTodos.TabIndex = 6;
            btnMostrarTodos.Text = "Mostrar Todos";
            btnMostrarTodos.UseVisualStyleBackColor = true;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            // 
            // btnSeleccionarTodos
            // 
            btnSeleccionarTodos.Location = new Point(201, 102);
            btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            btnSeleccionarTodos.Size = new Size(119, 46);
            btnSeleccionarTodos.TabIndex = 7;
            btnSeleccionarTodos.Text = "✅ Seleccionar Todos";
            btnSeleccionarTodos.UseVisualStyleBackColor = true;
            btnSeleccionarTodos.Click += btnSeleccionarTodos_Click;
            // 
            // btnDeseleccionarTodos
            // 
            btnDeseleccionarTodos.Location = new Point(390, 102);
            btnDeseleccionarTodos.Name = "btnDeseleccionarTodos";
            btnDeseleccionarTodos.Size = new Size(142, 46);
            btnDeseleccionarTodos.TabIndex = 8;
            btnDeseleccionarTodos.Text = "❌ Deseleccionar Todos";
            btnDeseleccionarTodos.UseVisualStyleBackColor = true;
            btnDeseleccionarTodos.Click += btnDeseleccionarTodos_Click;
            // 
            // dgvLibros
            // 
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(-1, 183);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(800, 147);
            dgvLibros.TabIndex = 9;
            dgvLibros.CellContentClick += dgvLibros_CellContentClick;
            dgvLibros.AutoGenerateColumns = false;
            // 
            // btnImprimirSeleccionados
            // 
            btnImprimirSeleccionados.Location = new Point(317, 385);
            btnImprimirSeleccionados.Name = "btnImprimirSeleccionados";
            btnImprimirSeleccionados.Size = new Size(155, 39);
            btnImprimirSeleccionados.TabIndex = 10;
            btnImprimirSeleccionados.Text = "🖨️ Imprimir Seleccionados";
            btnImprimirSeleccionados.UseVisualStyleBackColor = true;
            btnImprimirSeleccionados.Click += btnImprimirSeleccionados_Click;
            // 
            // mnuImprimirEtiquetas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnImprimirSeleccionados);
            Controls.Add(dgvLibros);
            Controls.Add(btnDeseleccionarTodos);
            Controls.Add(btnSeleccionarTodos);
            Controls.Add(btnMostrarTodos);
            Controls.Add(btnBuscarCodigo);
            Controls.Add(txtFiltroCodigo);
            Controls.Add(cmbFiltroTipo);
            Controls.Add(lblTotalSeleccionados);
            Controls.Add(lblFiltroCodigo);
            Controls.Add(lblFiltroTipo);
            Name = "mnuImprimirEtiquetas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Codigo de Barras";
            Load += ImprimirEtiquetasLoteForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFiltroTipo;
        private Label lblFiltroCodigo;
        private Label lblTotalSeleccionados;
        private ComboBox cmbFiltroTipo;
        private TextBox txtFiltroCodigo;
        private Button btnBuscarCodigo;
        private Button btnMostrarTodos;
        private Button btnSeleccionarTodos;
        private Button btnDeseleccionarTodos;
        private DataGridView dgvLibros;
        private Button btnImprimirSeleccionados;
    }
}