namespace GestionArchivoRegistroPropiedad
{
    partial class GestionLibrosForm
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
            tabControlLibros = new TabControl();
            tabAgregar = new TabPage();
            btnGenerarVistaPrevia = new Button();
            btnLimpiar = new Button();
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
            tabBuscar = new TabPage();
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
            tabEliminar = new TabPage();
            btnEliminarLibro = new Button();
            btnBuscarEliminar = new Button();
            txtEliminarCodigo = new TextBox();
            lblInfoEliminar = new Label();
            lblEliminarCodigo = new Label();
            tabControlLibros.SuspendLayout();
            tabAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCodigoBarras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPartidaFin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPartidaIni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTomo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
            tabBuscar.SuspendLayout();
            grpEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEditTomo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEditAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEditPartidaIni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEditPartidaFin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            tabEliminar.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlLibros
            // 
            tabControlLibros.Controls.Add(tabAgregar);
            tabControlLibros.Controls.Add(tabBuscar);
            tabControlLibros.Controls.Add(tabEliminar);
            tabControlLibros.Dock = DockStyle.Fill;
            tabControlLibros.Location = new Point(0, 0);
            tabControlLibros.Name = "tabControlLibros";
            tabControlLibros.SelectedIndex = 0;
            tabControlLibros.Size = new Size(800, 450);
            tabControlLibros.TabIndex = 0;
            // 
            // tabAgregar
            // 
            tabAgregar.Controls.Add(btnGenerarVistaPrevia);
            tabAgregar.Controls.Add(btnLimpiar);
            tabAgregar.Controls.Add(bntGuardarLibro);
            tabAgregar.Controls.Add(picCodigoBarras);
            tabAgregar.Controls.Add(txtCodigoBarras);
            tabAgregar.Controls.Add(txtObservacion);
            tabAgregar.Controls.Add(lblObservacion);
            tabAgregar.Controls.Add(lblCodigoBarras);
            tabAgregar.Controls.Add(numPartidaFin);
            tabAgregar.Controls.Add(lblPartidaFin);
            tabAgregar.Controls.Add(numPartidaIni);
            tabAgregar.Controls.Add(lblPartidaIni);
            tabAgregar.Controls.Add(numTomo);
            tabAgregar.Controls.Add(lblTomo);
            tabAgregar.Controls.Add(numAnio);
            tabAgregar.Controls.Add(lblAnio);
            tabAgregar.Controls.Add(cmbTipoLibro);
            tabAgregar.Controls.Add(lblTipo);
            tabAgregar.Location = new Point(4, 24);
            tabAgregar.Name = "tabAgregar";
            tabAgregar.Padding = new Padding(3);
            tabAgregar.Size = new Size(792, 422);
            tabAgregar.TabIndex = 0;
            tabAgregar.Text = "Agregar Libro";
            tabAgregar.UseVisualStyleBackColor = true;
            // 
            // btnGenerarVistaPrevia
            // 
            btnGenerarVistaPrevia.Location = new Point(490, 357);
            btnGenerarVistaPrevia.Name = "btnGenerarVistaPrevia";
            btnGenerarVistaPrevia.Size = new Size(95, 35);
            btnGenerarVistaPrevia.TabIndex = 53;
            btnGenerarVistaPrevia.Text = "Vista Previa Código";
            btnGenerarVistaPrevia.UseVisualStyleBackColor = true;
            btnGenerarVistaPrevia.Click += btnGenerarVistaPrevia_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(339, 357);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(89, 35);
            btnLimpiar.TabIndex = 52;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // bntGuardarLibro
            // 
            bntGuardarLibro.Location = new Point(186, 356);
            bntGuardarLibro.Name = "bntGuardarLibro";
            bntGuardarLibro.Size = new Size(99, 36);
            bntGuardarLibro.TabIndex = 51;
            bntGuardarLibro.Text = "Guardar Libro";
            bntGuardarLibro.UseVisualStyleBackColor = true;
            bntGuardarLibro.Click += btnGuardarLibro_Click;
            // 
            // picCodigoBarras
            // 
            picCodigoBarras.Location = new Point(192, 288);
            picCodigoBarras.Name = "picCodigoBarras";
            picCodigoBarras.Size = new Size(393, 50);
            picCodigoBarras.TabIndex = 50;
            picCodigoBarras.TabStop = false;
            picCodigoBarras.Click += picCodigoBarras_Click;
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(143, 244);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(213, 23);
            txtCodigoBarras.TabIndex = 49;
            txtCodigoBarras.TextChanged += txtCodigoBarras_TextChanged;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(123, 191);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(554, 23);
            txtObservacion.TabIndex = 48;
            txtObservacion.TextChanged += txtObservacion_TextChanged;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(37, 191);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(76, 15);
            lblObservacion.TabIndex = 47;
            lblObservacion.Text = "Observación:";
            lblObservacion.Click += lblObservacion_Click;
            // 
            // lblCodigoBarras
            // 
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.Location = new Point(37, 244);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(100, 15);
            lblCodigoBarras.TabIndex = 46;
            lblCodigoBarras.Text = "Codigo de Barras:";
            lblCodigoBarras.Click += lblCodigoBarras_Click;
            // 
            // numPartidaFin
            // 
            numPartidaFin.Location = new Point(544, 132);
            numPartidaFin.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numPartidaFin.Name = "numPartidaFin";
            numPartidaFin.Size = new Size(120, 23);
            numPartidaFin.TabIndex = 45;
            numPartidaFin.ValueChanged += numPartidaFin_ValueChanged;
            // 
            // lblPartidaFin
            // 
            lblPartidaFin.AutoSize = true;
            lblPartidaFin.Location = new Point(438, 132);
            lblPartidaFin.Name = "lblPartidaFin";
            lblPartidaFin.Size = new Size(75, 15);
            lblPartidaFin.TabIndex = 44;
            lblPartidaFin.Text = "Partida Final:";
            lblPartidaFin.Click += lblPartidaFin_Click;
            // 
            // numPartidaIni
            // 
            numPartidaIni.Location = new Point(165, 129);
            numPartidaIni.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numPartidaIni.Name = "numPartidaIni";
            numPartidaIni.Size = new Size(120, 23);
            numPartidaIni.TabIndex = 43;
            numPartidaIni.ValueChanged += numPartidaIni_ValueChanged;
            // 
            // lblPartidaIni
            // 
            lblPartidaIni.AutoSize = true;
            lblPartidaIni.Location = new Point(37, 132);
            lblPartidaIni.Name = "lblPartidaIni";
            lblPartidaIni.Size = new Size(81, 15);
            lblPartidaIni.TabIndex = 42;
            lblPartidaIni.Text = "Partida Inicial:";
            lblPartidaIni.Click += lblPartidaIni_Click;
            // 
            // numTomo
            // 
            numTomo.Location = new Point(596, 56);
            numTomo.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numTomo.Name = "numTomo";
            numTomo.Size = new Size(120, 23);
            numTomo.TabIndex = 41;
            numTomo.ValueChanged += numTomo_ValueChanged;
            // 
            // lblTomo
            // 
            lblTomo.AutoSize = true;
            lblTomo.Location = new Point(530, 61);
            lblTomo.Name = "lblTomo";
            lblTomo.Size = new Size(41, 15);
            lblTomo.TabIndex = 40;
            lblTomo.Text = "Tomo:";
            lblTomo.Click += lblTomo_Click;
            // 
            // numAnio
            // 
            numAnio.Location = new Point(339, 53);
            numAnio.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            numAnio.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            numAnio.Name = "numAnio";
            numAnio.Size = new Size(120, 23);
            numAnio.TabIndex = 39;
            numAnio.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            numAnio.ValueChanged += numAnio_ValueChanged;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(290, 61);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(32, 15);
            lblAnio.TabIndex = 38;
            lblAnio.Text = "Año:";
            lblAnio.Click += lblAnio_Click;
            // 
            // cmbTipoLibro
            // 
            cmbTipoLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoLibro.FormattingEnabled = true;
            cmbTipoLibro.Items.AddRange(new object[] { "Propiedad", "Sentencias y Demandas", "Hipotecas", "Mercantil" });
            cmbTipoLibro.Location = new Point(123, 53);
            cmbTipoLibro.Name = "cmbTipoLibro";
            cmbTipoLibro.Size = new Size(121, 23);
            cmbTipoLibro.TabIndex = 37;
            cmbTipoLibro.SelectedIndexChanged += cmbTipoLibro_SelectedIndexChanged;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(37, 56);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(80, 15);
            lblTipo.TabIndex = 36;
            lblTipo.Text = "Tipo de Libro:";
            lblTipo.Click += lblTipo_Click;
            // 
            // tabBuscar
            // 
            tabBuscar.Controls.Add(btnCancelarEdicion);
            tabBuscar.Controls.Add(btnActualizar);
            tabBuscar.Controls.Add(grpEdicion);
            tabBuscar.Controls.Add(dgvLibros);
            tabBuscar.Controls.Add(btnBuscarTodos);
            tabBuscar.Controls.Add(btnBuscar);
            tabBuscar.Controls.Add(txtBuscarCodigo);
            tabBuscar.Controls.Add(lblBuscar);
            tabBuscar.Location = new Point(4, 24);
            tabBuscar.Name = "tabBuscar";
            tabBuscar.Padding = new Padding(3);
            tabBuscar.Size = new Size(792, 422);
            tabBuscar.TabIndex = 1;
            tabBuscar.Text = "Buscar / Modificar";
            tabBuscar.UseVisualStyleBackColor = true;
            // 
            // btnCancelarEdicion
            // 
            btnCancelarEdicion.Location = new Point(368, 381);
            btnCancelarEdicion.Name = "btnCancelarEdicion";
            btnCancelarEdicion.Size = new Size(96, 35);
            btnCancelarEdicion.TabIndex = 8;
            btnCancelarEdicion.Text = "Cancelar";
            btnCancelarEdicion.UseVisualStyleBackColor = true;
            btnCancelarEdicion.Click += btnCancelarEdicion_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(196, 381);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(122, 33);
            btnActualizar.TabIndex = 7;
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
            grpEdicion.Location = new Point(0, 231);
            grpEdicion.Name = "grpEdicion";
            grpEdicion.Size = new Size(789, 132);
            grpEdicion.TabIndex = 6;
            grpEdicion.TabStop = false;
            grpEdicion.Text = "Modificar Libro Seleccionado";
            grpEdicion.Enter += grpEdicion_Enter;
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
            cmbEditTipo.SelectedIndexChanged += cmbEditTipo_SelectedIndexChanged;
            // 
            // numEditTomo
            // 
            numEditTomo.Location = new Point(630, 22);
            numEditTomo.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEditTomo.Name = "numEditTomo";
            numEditTomo.Size = new Size(120, 23);
            numEditTomo.TabIndex = 17;
            numEditTomo.ValueChanged += numEditTomo_ValueChanged;
            // 
            // numEditAnio
            // 
            numEditAnio.Location = new Point(350, 27);
            numEditAnio.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEditAnio.Name = "numEditAnio";
            numEditAnio.Size = new Size(120, 23);
            numEditAnio.TabIndex = 16;
            numEditAnio.ValueChanged += numEditAnio_ValueChanged;
            // 
            // lblEditTomo
            // 
            lblEditTomo.AutoSize = true;
            lblEditTomo.Location = new Point(583, 27);
            lblEditTomo.Name = "lblEditTomo";
            lblEditTomo.Size = new Size(41, 15);
            lblEditTomo.TabIndex = 15;
            lblEditTomo.Text = "Tomo:";
            lblEditTomo.Click += lblEditTomo_Click;
            // 
            // lblEditAnio
            // 
            lblEditAnio.AutoSize = true;
            lblEditAnio.Location = new Point(297, 30);
            lblEditAnio.Name = "lblEditAnio";
            lblEditAnio.Size = new Size(32, 15);
            lblEditAnio.TabIndex = 14;
            lblEditAnio.Text = "Año:";
            lblEditAnio.Click += lblEditAnio_Click;
            // 
            // txtEditObservacion
            // 
            txtEditObservacion.Location = new Point(95, 101);
            txtEditObservacion.Multiline = true;
            txtEditObservacion.Name = "txtEditObservacion";
            txtEditObservacion.Size = new Size(626, 23);
            txtEditObservacion.TabIndex = 13;
            txtEditObservacion.TextChanged += txtEditObservacion_TextChanged;
            // 
            // lblEditObersacion
            // 
            lblEditObersacion.AutoSize = true;
            lblEditObersacion.Location = new Point(18, 104);
            lblEditObersacion.Name = "lblEditObersacion";
            lblEditObersacion.Size = new Size(71, 15);
            lblEditObersacion.TabIndex = 12;
            lblEditObersacion.Text = "Obervacion:";
            lblEditObersacion.Click += lblEditObservacion_Click;
            // 
            // lblEditPartidaFin
            // 
            lblEditPartidaFin.AutoSize = true;
            lblEditPartidaFin.Location = new Point(395, 76);
            lblEditPartidaFin.Name = "lblEditPartidaFin";
            lblEditPartidaFin.Size = new Size(75, 15);
            lblEditPartidaFin.TabIndex = 10;
            lblEditPartidaFin.Text = "Partida Final:";
            lblEditPartidaFin.Click += lblEditPartidaFin_Click;
            // 
            // numEditPartidaIni
            // 
            numEditPartidaIni.Location = new Point(237, 72);
            numEditPartidaIni.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEditPartidaIni.Name = "numEditPartidaIni";
            numEditPartidaIni.Size = new Size(120, 23);
            numEditPartidaIni.TabIndex = 9;
            numEditPartidaIni.ValueChanged += numEditPartidaIni_ValueChanged;
            // 
            // lblEditPartidaIni
            // 
            lblEditPartidaIni.AutoSize = true;
            lblEditPartidaIni.Location = new Point(135, 80);
            lblEditPartidaIni.Name = "lblEditPartidaIni";
            lblEditPartidaIni.Size = new Size(81, 15);
            lblEditPartidaIni.TabIndex = 8;
            lblEditPartidaIni.Text = "Partida Inicial:";
            lblEditPartidaIni.Click += lblEditPartidaIni_Click;
            // 
            // lblEditTipo
            // 
            lblEditTipo.AutoSize = true;
            lblEditTipo.Location = new Point(8, 35);
            lblEditTipo.Name = "lblEditTipo";
            lblEditTipo.Size = new Size(34, 15);
            lblEditTipo.TabIndex = 1;
            lblEditTipo.Text = "Tipo:";
            lblEditTipo.Click += lblEditTipo_Click;
            // 
            // numEditPartidaFin
            // 
            numEditPartidaFin.Location = new Point(504, 74);
            numEditPartidaFin.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEditPartidaFin.Name = "numEditPartidaFin";
            numEditPartidaFin.Size = new Size(120, 23);
            numEditPartidaFin.TabIndex = 11;
            numEditPartidaFin.ValueChanged += numEditPartidaFin_ValueChanged;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(-4, 94);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(796, 131);
            dgvLibros.TabIndex = 5;
            dgvLibros.CellContentClick += dgvLibros_CellContentClick;
            // 
            // btnBuscarTodos
            // 
            btnBuscarTodos.Location = new Point(622, 43);
            btnBuscarTodos.Name = "btnBuscarTodos";
            btnBuscarTodos.Size = new Size(99, 23);
            btnBuscarTodos.TabIndex = 4;
            btnBuscarTodos.Text = "Mostrar Todos";
            btnBuscarTodos.UseVisualStyleBackColor = true;
            btnBuscarTodos.Click += btnBuscarTodos_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(518, 43);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarCodigo
            // 
            txtBuscarCodigo.Location = new Point(211, 40);
            txtBuscarCodigo.Name = "txtBuscarCodigo";
            txtBuscarCodigo.Size = new Size(269, 23);
            txtBuscarCodigo.TabIndex = 2;
            txtBuscarCodigo.TextChanged += txtBuscarCodigo_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(33, 43);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(159, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar por Código de Barras:";
            lblBuscar.Click += lblBuscar_Click;
            // 
            // tabEliminar
            // 
            tabEliminar.Controls.Add(btnEliminarLibro);
            tabEliminar.Controls.Add(btnBuscarEliminar);
            tabEliminar.Controls.Add(txtEliminarCodigo);
            tabEliminar.Controls.Add(lblInfoEliminar);
            tabEliminar.Controls.Add(lblEliminarCodigo);
            tabEliminar.Location = new Point(4, 24);
            tabEliminar.Name = "tabEliminar";
            tabEliminar.Padding = new Padding(3);
            tabEliminar.Size = new Size(792, 422);
            tabEliminar.TabIndex = 2;
            tabEliminar.Text = "Eliminar Libro";
            tabEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEliminarLibro
            // 
            btnEliminarLibro.BackColor = Color.IndianRed;
            btnEliminarLibro.Location = new Point(351, 347);
            btnEliminarLibro.Name = "btnEliminarLibro";
            btnEliminarLibro.Size = new Size(102, 33);
            btnEliminarLibro.TabIndex = 4;
            btnEliminarLibro.Text = "Eliminar Libro";
            btnEliminarLibro.UseVisualStyleBackColor = false;
            btnEliminarLibro.Click += btnEliminarLibro_Click_1;
            // 
            // btnBuscarEliminar
            // 
            btnBuscarEliminar.Location = new Point(681, 101);
            btnBuscarEliminar.Name = "btnBuscarEliminar";
            btnBuscarEliminar.Size = new Size(75, 23);
            btnBuscarEliminar.TabIndex = 3;
            btnBuscarEliminar.Text = "Buscar";
            btnBuscarEliminar.UseVisualStyleBackColor = true;
            btnBuscarEliminar.Click += btnBuscarEliminar_Click_1;
            // 
            // txtEliminarCodigo
            // 
            txtEliminarCodigo.Location = new Point(277, 101);
            txtEliminarCodigo.Name = "txtEliminarCodigo";
            txtEliminarCodigo.Size = new Size(365, 23);
            txtEliminarCodigo.TabIndex = 2;
            // 
            // lblInfoEliminar
            // 
            lblInfoEliminar.AutoSize = true;
            lblInfoEliminar.Location = new Point(363, 195);
            lblInfoEliminar.Name = "lblInfoEliminar";
            lblInfoEliminar.Size = new Size(0, 15);
            lblInfoEliminar.TabIndex = 1;
            // 
            // lblEliminarCodigo
            // 
            lblEliminarCodigo.AutoSize = true;
            lblEliminarCodigo.Location = new Point(53, 101);
            lblEliminarCodigo.Name = "lblEliminarCodigo";
            lblEliminarCodigo.Size = new Size(201, 15);
            lblEliminarCodigo.TabIndex = 0;
            lblEliminarCodigo.Text = "Código de Barras del libro a eliminar:";
            // 
            // GestionLibrosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlLibros);
            Name = "GestionLibrosForm";
            Text = "Mantenimiento Libros";
            tabControlLibros.ResumeLayout(false);
            tabAgregar.ResumeLayout(false);
            tabAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCodigoBarras).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPartidaFin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPartidaIni).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTomo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
            tabBuscar.ResumeLayout(false);
            tabBuscar.PerformLayout();
            grpEdicion.ResumeLayout(false);
            grpEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEditTomo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEditAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEditPartidaIni).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEditPartidaFin).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            tabEliminar.ResumeLayout(false);
            tabEliminar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlLibros;
        private TabPage tabAgregar;
        private TabPage tabBuscar;
        private TabPage tabEliminar;
        private Button btnGenerarVistaPrevia;
        private Button btnLimpiar;
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
        private Button btnBuscar;
        private TextBox txtBuscarCodigo;
        private Label lblEditTipo;
        private Label lblBuscar;
        private GroupBox grpEdicion;
        private DataGridView dgvLibros;
        private Button btnBuscarTodos;
        private Label lblEditPartidaIni;
        private TextBox txtEditObservacion;
        private Label lblEditObersacion;
        private Label lblEditPartidaFin;
        private NumericUpDown numEditPartidaIni;
        private NumericUpDown numEditPartidaFin;
        private Button btnCancelarEdicion;
        private Button btnActualizar;
        private NumericUpDown numEditTomo;
        private NumericUpDown numEditAnio;
        private Label lblEditTomo;
        private Label lblEditAnio;
        private ComboBox cmbEditTipo;
        private Button btnBuscarEliminar;
        private TextBox txtEliminarCodigo;
        private Label lblInfoEliminar;
        private Label lblEliminarCodigo;
        private Button btnEliminarLibro;
    }
}