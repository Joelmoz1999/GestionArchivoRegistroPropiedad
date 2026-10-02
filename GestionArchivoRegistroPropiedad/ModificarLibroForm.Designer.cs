namespace GestionArchivoRegistroPropiedad
{
    partial class ModificarLibroForm
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
            btnCancelarEdicion = new Button();
            btnActualizar = new Button();
            grpEdicion = new GroupBox();
            cmbEditTipo = new ComboBox();
            numEditTomo = new NumericUpDown();
            numEditAnio = new NumericUpDown();
            lblEditTomo = new Label();
            lblEditAnio = new Label();
            txtEditObservacion = new TextBox();
            lblEditObersacion = new Label();
            lblEditPartidaFin = new Label();
            numEditPartidaIni = new NumericUpDown();
            lblEditPartidaIni = new Label();
            lblEditTipo = new Label();
            numEditPartidaFin = new NumericUpDown();
            dgvLibros = new DataGridView();
            btnBuscarTodos = new Button();
            btnBuscar = new Button();
            txtBuscarCodigo = new TextBox();
            lblBuscar = new Label();
            grpEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEditTomo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEditAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEditPartidaIni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEditPartidaFin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // btnCancelarEdicion
            // 
            btnCancelarEdicion.Location = new Point(374, 378);
            btnCancelarEdicion.Name = "btnCancelarEdicion";
            btnCancelarEdicion.Size = new Size(96, 35);
            btnCancelarEdicion.TabIndex = 16;
            btnCancelarEdicion.Text = "Cancelar";
            btnCancelarEdicion.UseVisualStyleBackColor = true;
            btnCancelarEdicion.Click += btnCancelar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(202, 378);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(122, 33);
            btnActualizar.TabIndex = 15;
            btnActualizar.Text = "Actualizar Libro";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // grpEdicion
            // 
            grpEdicion.Controls.Add(cmbEditTipo);
            grpEdicion.Controls.Add(numEditTomo);
            grpEdicion.Controls.Add(numEditAnio);
            grpEdicion.Controls.Add(lblEditTomo);
            grpEdicion.Controls.Add(lblEditAnio);
            grpEdicion.Controls.Add(txtEditObservacion);
            grpEdicion.Controls.Add(lblEditObersacion);
            grpEdicion.Controls.Add(lblEditPartidaFin);
            grpEdicion.Controls.Add(numEditPartidaIni);
            grpEdicion.Controls.Add(lblEditPartidaIni);
            grpEdicion.Controls.Add(lblEditTipo);
            grpEdicion.Controls.Add(numEditPartidaFin);
            grpEdicion.Location = new Point(6, 228);
            grpEdicion.Name = "grpEdicion";
            grpEdicion.Size = new Size(789, 132);
            grpEdicion.TabIndex = 14;
            grpEdicion.TabStop = false;
            grpEdicion.Text = "Modificar Libro Seleccionado";
            // 
            // cmbEditTipo
            // 
            cmbEditTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditTipo.FormattingEnabled = true;
            cmbEditTipo.Items.AddRange(new object[] { "Propiedad", "Sentencias y Demandas", "Hipotecas", "Mercantil" });
            cmbEditTipo.Location = new Point(61, 32);
            cmbEditTipo.Name = "cmbEditTipo";
            cmbEditTipo.Size = new Size(121, 23);
            cmbEditTipo.TabIndex = 18;
            // 
            // numEditTomo
            // 
            numEditTomo.Location = new Point(630, 22);
            numEditTomo.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEditTomo.Name = "numEditTomo";
            numEditTomo.Size = new Size(120, 23);
            numEditTomo.TabIndex = 17;
            // 
            // numEditAnio
            // 
            numEditAnio.Location = new Point(350, 27);
            numEditAnio.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEditAnio.Name = "numEditAnio";
            numEditAnio.Size = new Size(120, 23);
            numEditAnio.TabIndex = 16;
            // 
            // lblEditTomo
            // 
            lblEditTomo.AutoSize = true;
            lblEditTomo.Location = new Point(583, 27);
            lblEditTomo.Name = "lblEditTomo";
            lblEditTomo.Size = new Size(41, 15);
            lblEditTomo.TabIndex = 15;
            lblEditTomo.Text = "Tomo:";
            // 
            // lblEditAnio
            // 
            lblEditAnio.AutoSize = true;
            lblEditAnio.Location = new Point(297, 30);
            lblEditAnio.Name = "lblEditAnio";
            lblEditAnio.Size = new Size(32, 15);
            lblEditAnio.TabIndex = 14;
            lblEditAnio.Text = "Año:";
            // 
            // txtEditObservacion
            // 
            txtEditObservacion.Location = new Point(95, 101);
            txtEditObservacion.Multiline = true;
            txtEditObservacion.Name = "txtEditObservacion";
            txtEditObservacion.Size = new Size(626, 23);
            txtEditObservacion.TabIndex = 13;
            // 
            // lblEditObersacion
            // 
            lblEditObersacion.AutoSize = true;
            lblEditObersacion.Location = new Point(18, 104);
            lblEditObersacion.Name = "lblEditObersacion";
            lblEditObersacion.Size = new Size(71, 15);
            lblEditObersacion.TabIndex = 12;
            lblEditObersacion.Text = "Obervacion:";
            // 
            // lblEditPartidaFin
            // 
            lblEditPartidaFin.AutoSize = true;
            lblEditPartidaFin.Location = new Point(395, 76);
            lblEditPartidaFin.Name = "lblEditPartidaFin";
            lblEditPartidaFin.Size = new Size(75, 15);
            lblEditPartidaFin.TabIndex = 10;
            lblEditPartidaFin.Text = "Partida Final:";
            // 
            // numEditPartidaIni
            // 
            numEditPartidaIni.Location = new Point(237, 72);
            numEditPartidaIni.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEditPartidaIni.Name = "numEditPartidaIni";
            numEditPartidaIni.Size = new Size(120, 23);
            numEditPartidaIni.TabIndex = 9;
            // 
            // lblEditPartidaIni
            // 
            lblEditPartidaIni.AutoSize = true;
            lblEditPartidaIni.Location = new Point(135, 80);
            lblEditPartidaIni.Name = "lblEditPartidaIni";
            lblEditPartidaIni.Size = new Size(81, 15);
            lblEditPartidaIni.TabIndex = 8;
            lblEditPartidaIni.Text = "Partida Inicial:";
            // 
            // lblEditTipo
            // 
            lblEditTipo.AutoSize = true;
            lblEditTipo.Location = new Point(8, 35);
            lblEditTipo.Name = "lblEditTipo";
            lblEditTipo.Size = new Size(34, 15);
            lblEditTipo.TabIndex = 1;
            lblEditTipo.Text = "Tipo:";
            // 
            // numEditPartidaFin
            // 
            numEditPartidaFin.Location = new Point(504, 74);
            numEditPartidaFin.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEditPartidaFin.Name = "numEditPartidaFin";
            numEditPartidaFin.Size = new Size(120, 23);
            numEditPartidaFin.TabIndex = 11;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(2, 91);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(796, 131);
            dgvLibros.TabIndex = 13;
            dgvLibros.CellContentClick += dgvLibros_CellContentClick;
            // 
            // btnBuscarTodos
            // 
            btnBuscarTodos.Location = new Point(628, 40);
            btnBuscarTodos.Name = "btnBuscarTodos";
            btnBuscarTodos.Size = new Size(99, 23);
            btnBuscarTodos.TabIndex = 12;
            btnBuscarTodos.Text = "Mostrar Todos";
            btnBuscarTodos.UseVisualStyleBackColor = true;
            btnBuscarTodos.Click += btnBuscarTodos_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(524, 40);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarCodigo
            // 
            txtBuscarCodigo.Location = new Point(217, 37);
            txtBuscarCodigo.Name = "txtBuscarCodigo";
            txtBuscarCodigo.Size = new Size(269, 23);
            txtBuscarCodigo.TabIndex = 10;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(39, 40);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(159, 15);
            lblBuscar.TabIndex = 9;
            lblBuscar.Text = "Buscar por Código de Barras:";
            // 
            // ModificarLibroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelarEdicion);
            Controls.Add(btnActualizar);
            Controls.Add(grpEdicion);
            Controls.Add(dgvLibros);
            Controls.Add(btnBuscarTodos);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarCodigo);
            Controls.Add(lblBuscar);
            Name = "ModificarLibroForm";
            Text = "ModificarLibroForm";
            Load += ModificarLibroForm_Load;
            grpEdicion.ResumeLayout(false);
            grpEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEditTomo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEditAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEditPartidaIni).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEditPartidaFin).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarEdicion;
        private Button btnActualizar;
        private GroupBox grpEdicion;
        private ComboBox cmbEditTipo;
        private NumericUpDown numEditTomo;
        private NumericUpDown numEditAnio;
        private Label lblEditTomo;
        private Label lblEditAnio;
        private TextBox txtEditObservacion;
        private Label lblEditObersacion;
        private Label lblEditPartidaFin;
        private NumericUpDown numEditPartidaIni;
        private Label lblEditPartidaIni;
        private Label lblEditTipo;
        private NumericUpDown numEditPartidaFin;
        private DataGridView dgvLibros;
        private Button btnBuscarTodos;
        private Button btnBuscar;
        private TextBox txtBuscarCodigo;
        private Label lblBuscar;
    }
}