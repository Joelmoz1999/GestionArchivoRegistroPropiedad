namespace GestionArchivoRegistroPropiedad
{
    partial class GestionFuncionariosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionFuncionariosForm));
            tabControlFuncionarios = new TabControl();
            tabAgregar = new TabPage();
            btnLimpiarFuncionario = new Button();
            btnGuardarFuncionario = new Button();
            txtCargo = new TextBox();
            txtCedula = new TextBox();
            txtApellidos = new TextBox();
            txtNombres = new TextBox();
            lblMensajeAgregar = new Label();
            lblCargo = new Label();
            lblCedula = new Label();
            lblApellidos = new Label();
            lblNombres = new Label();
            tabBuscar = new TabPage();
            dgvFuncionarios = new DataGridView();
            txtBuscarFuncionario = new TextBox();
            lblBuscarFuncionario = new Label();
            btnCancelarEdicionFuncionario = new Button();
            btnActualizarFuncionario = new Button();
            btnMostrarTodosFuncionarios = new Button();
            btnBuscarFuncionario = new Button();
            grpEdicionFuncionario = new GroupBox();
            chkEditActivo = new CheckBox();
            txtEditCargo = new TextBox();
            txtEditCedula = new TextBox();
            lblEditNombres = new Label();
            txtEditApellidos = new TextBox();
            lblEditCargo = new Label();
            txtEditNombres = new TextBox();
            lblEditCedula = new Label();
            lblEditApellidos = new Label();
            tabEliminar = new TabPage();
            btnReactivarFuncionario = new Button();
            btnEliminarFuncionario = new Button();
            btnBuscarEliminarFunc = new Button();
            txtEliminarCedulaFunc = new TextBox();
            lblInfoEliminarFunc = new Label();
            lblEliminarCedula = new Label();
            lblEliminarTituloFunc = new Label();
            tabControlFuncionarios.SuspendLayout();
            tabAgregar.SuspendLayout();
            tabBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).BeginInit();
            grpEdicionFuncionario.SuspendLayout();
            tabEliminar.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlFuncionarios
            // 
            tabControlFuncionarios.Controls.Add(tabAgregar);
            tabControlFuncionarios.Controls.Add(tabBuscar);
            tabControlFuncionarios.Controls.Add(tabEliminar);
            tabControlFuncionarios.Dock = DockStyle.Fill;
            tabControlFuncionarios.Location = new Point(0, 0);
            tabControlFuncionarios.Name = "tabControlFuncionarios";
            tabControlFuncionarios.SelectedIndex = 0;
            tabControlFuncionarios.Size = new Size(800, 450);
            tabControlFuncionarios.TabIndex = 0;
            // 
            // tabAgregar
            // 
            tabAgregar.Controls.Add(btnLimpiarFuncionario);
            tabAgregar.Controls.Add(btnGuardarFuncionario);
            tabAgregar.Controls.Add(txtCargo);
            tabAgregar.Controls.Add(txtCedula);
            tabAgregar.Controls.Add(txtApellidos);
            tabAgregar.Controls.Add(txtNombres);
            tabAgregar.Controls.Add(lblMensajeAgregar);
            tabAgregar.Controls.Add(lblCargo);
            tabAgregar.Controls.Add(lblCedula);
            tabAgregar.Controls.Add(lblApellidos);
            tabAgregar.Controls.Add(lblNombres);
            tabAgregar.Location = new Point(4, 24);
            tabAgregar.Name = "tabAgregar";
            tabAgregar.Padding = new Padding(3);
            tabAgregar.Size = new Size(792, 422);
            tabAgregar.TabIndex = 0;
            tabAgregar.Text = "Agregar Funcionario";
            tabAgregar.UseVisualStyleBackColor = true;
            tabAgregar.Click += tabAgregar_Click;
            // 
            // btnLimpiarFuncionario
            // 
            btnLimpiarFuncionario.Location = new Point(391, 352);
            btnLimpiarFuncionario.Name = "btnLimpiarFuncionario";
            btnLimpiarFuncionario.Size = new Size(100, 40);
            btnLimpiarFuncionario.TabIndex = 10;
            btnLimpiarFuncionario.Text = "Limpiar";
            btnLimpiarFuncionario.UseVisualStyleBackColor = true;
            btnLimpiarFuncionario.Click += btnLimpiarFuncionario_Click;
            // 
            // btnGuardarFuncionario
            // 
            btnGuardarFuncionario.Location = new Point(231, 352);
            btnGuardarFuncionario.Name = "btnGuardarFuncionario";
            btnGuardarFuncionario.Size = new Size(118, 40);
            btnGuardarFuncionario.TabIndex = 9;
            btnGuardarFuncionario.Text = "Guardar Funcionario";
            btnGuardarFuncionario.UseVisualStyleBackColor = true;
            btnGuardarFuncionario.Click += btnGuardarFuncionario_Click;
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(535, 175);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(219, 23);
            txtCargo.TabIndex = 8;
            txtCargo.TextChanged += txtCargo_TextChanged;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(535, 121);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(219, 23);
            txtCedula.TabIndex = 7;
            txtCedula.TextChanged += txtCedula_TextChanged;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(147, 167);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(224, 23);
            txtApellidos.TabIndex = 6;
            txtApellidos.TextChanged += textBox2_TextChanged;
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(147, 117);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(224, 23);
            txtNombres.TabIndex = 5;
            txtNombres.TextChanged += txtNombres_TextChanged;
            // 
            // lblMensajeAgregar
            // 
            lblMensajeAgregar.AutoSize = true;
            lblMensajeAgregar.ForeColor = Color.IndianRed;
            lblMensajeAgregar.Location = new Point(220, 290);
            lblMensajeAgregar.Name = "lblMensajeAgregar";
            lblMensajeAgregar.Size = new Size(0, 15);
            lblMensajeAgregar.TabIndex = 4;
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Location = new Point(449, 183);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(42, 15);
            lblCargo.TabIndex = 3;
            lblCargo.Text = "Cargo:";
            lblCargo.Click += lblCargo_Click;
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(449, 121);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(44, 15);
            lblCedula.TabIndex = 2;
            lblCedula.Text = "Cedula";
            lblCedula.Click += lblCedula_Click;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(48, 175);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(59, 15);
            lblApellidos.TabIndex = 1;
            lblApellidos.Text = "Apellidos:";
            lblApellidos.Click += lblApellidos_Click;
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(45, 117);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(62, 15);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombres: ";
            // 
            // tabBuscar
            // 
            tabBuscar.Controls.Add(dgvFuncionarios);
            tabBuscar.Controls.Add(txtBuscarFuncionario);
            tabBuscar.Controls.Add(lblBuscarFuncionario);
            tabBuscar.Controls.Add(btnCancelarEdicionFuncionario);
            tabBuscar.Controls.Add(btnActualizarFuncionario);
            tabBuscar.Controls.Add(btnMostrarTodosFuncionarios);
            tabBuscar.Controls.Add(btnBuscarFuncionario);
            tabBuscar.Controls.Add(grpEdicionFuncionario);
            tabBuscar.Location = new Point(4, 24);
            tabBuscar.Name = "tabBuscar";
            tabBuscar.Padding = new Padding(3);
            tabBuscar.Size = new Size(792, 422);
            tabBuscar.TabIndex = 1;
            tabBuscar.Text = "Buscar / Modificar";
            tabBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvFuncionarios
            // 
            dgvFuncionarios.AllowUserToAddRows = false;
            dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFuncionarios.Location = new Point(3, 90);
            dgvFuncionarios.MultiSelect = false;
            dgvFuncionarios.Name = "dgvFuncionarios";
            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuncionarios.Size = new Size(789, 129);
            dgvFuncionarios.TabIndex = 12;
            dgvFuncionarios.CellContentClick += dgvFuncionarios_CellContentClick;
            // 
            // txtBuscarFuncionario
            // 
            txtBuscarFuncionario.Location = new Point(259, 61);
            txtBuscarFuncionario.Name = "txtBuscarFuncionario";
            txtBuscarFuncionario.Size = new Size(176, 23);
            txtBuscarFuncionario.TabIndex = 9;
            txtBuscarFuncionario.TextChanged += txtBuscarFuncionario_TextChanged;
            // 
            // lblBuscarFuncionario
            // 
            lblBuscarFuncionario.AutoSize = true;
            lblBuscarFuncionario.Location = new Point(57, 61);
            lblBuscarFuncionario.Name = "lblBuscarFuncionario";
            lblBuscarFuncionario.Size = new Size(168, 15);
            lblBuscarFuncionario.TabIndex = 4;
            lblBuscarFuncionario.Text = "Buscar por Cédula o Apellidos:";
            lblBuscarFuncionario.Click += lblBuscarFuncionario_Click;
            // 
            // btnCancelarEdicionFuncionario
            // 
            btnCancelarEdicionFuncionario.Location = new Point(411, 374);
            btnCancelarEdicionFuncionario.Name = "btnCancelarEdicionFuncionario";
            btnCancelarEdicionFuncionario.Size = new Size(86, 40);
            btnCancelarEdicionFuncionario.TabIndex = 3;
            btnCancelarEdicionFuncionario.Text = "Cancelar";
            btnCancelarEdicionFuncionario.UseVisualStyleBackColor = true;
            btnCancelarEdicionFuncionario.Click += btnCancelarEdicionFuncionario_Click;
            // 
            // btnActualizarFuncionario
            // 
            btnActualizarFuncionario.Location = new Point(280, 374);
            btnActualizarFuncionario.Name = "btnActualizarFuncionario";
            btnActualizarFuncionario.Size = new Size(90, 40);
            btnActualizarFuncionario.TabIndex = 2;
            btnActualizarFuncionario.Text = "Actualizar";
            btnActualizarFuncionario.UseVisualStyleBackColor = true;
            btnActualizarFuncionario.Click += btnActualizarFuncionario_Click;
            // 
            // btnMostrarTodosFuncionarios
            // 
            btnMostrarTodosFuncionarios.Location = new Point(632, 61);
            btnMostrarTodosFuncionarios.Name = "btnMostrarTodosFuncionarios";
            btnMostrarTodosFuncionarios.Size = new Size(109, 23);
            btnMostrarTodosFuncionarios.TabIndex = 1;
            btnMostrarTodosFuncionarios.Text = "Mostrar Todos";
            btnMostrarTodosFuncionarios.UseVisualStyleBackColor = true;
            btnMostrarTodosFuncionarios.Click += btnMostrarTodosFuncionarios_Click;
            // 
            // btnBuscarFuncionario
            // 
            btnBuscarFuncionario.Location = new Point(480, 61);
            btnBuscarFuncionario.Name = "btnBuscarFuncionario";
            btnBuscarFuncionario.Size = new Size(113, 23);
            btnBuscarFuncionario.TabIndex = 0;
            btnBuscarFuncionario.Text = "Buscar";
            btnBuscarFuncionario.UseVisualStyleBackColor = true;
            btnBuscarFuncionario.Click += btnBuscarFuncionario_Click;
            // 
            // grpEdicionFuncionario
            // 
            grpEdicionFuncionario.Controls.Add(chkEditActivo);
            grpEdicionFuncionario.Controls.Add(txtEditCargo);
            grpEdicionFuncionario.Controls.Add(txtEditCedula);
            grpEdicionFuncionario.Controls.Add(lblEditNombres);
            grpEdicionFuncionario.Controls.Add(txtEditApellidos);
            grpEdicionFuncionario.Controls.Add(lblEditCargo);
            grpEdicionFuncionario.Controls.Add(txtEditNombres);
            grpEdicionFuncionario.Controls.Add(lblEditCedula);
            grpEdicionFuncionario.Controls.Add(lblEditApellidos);
            grpEdicionFuncionario.Location = new Point(-4, 216);
            grpEdicionFuncionario.Name = "grpEdicionFuncionario";
            grpEdicionFuncionario.Size = new Size(796, 152);
            grpEdicionFuncionario.TabIndex = 13;
            grpEdicionFuncionario.TabStop = false;
            grpEdicionFuncionario.Text = "Modificar Funcionario";
            grpEdicionFuncionario.Enter += grpEdicionFuncionario_Enter;
            // 
            // chkEditActivo
            // 
            chkEditActivo.AutoSize = true;
            chkEditActivo.Location = new Point(690, 67);
            chkEditActivo.Name = "chkEditActivo";
            chkEditActivo.Size = new Size(60, 19);
            chkEditActivo.TabIndex = 14;
            chkEditActivo.Text = "Activo";
            chkEditActivo.UseVisualStyleBackColor = true;
            chkEditActivo.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // txtEditCargo
            // 
            txtEditCargo.Location = new Point(522, 78);
            txtEditCargo.Name = "txtEditCargo";
            txtEditCargo.Size = new Size(100, 23);
            txtEditCargo.TabIndex = 13;
            txtEditCargo.TextChanged += txtEditCargo_TextChanged;
            // 
            // txtEditCedula
            // 
            txtEditCedula.Location = new Point(187, 81);
            txtEditCedula.Name = "txtEditCedula";
            txtEditCedula.ReadOnly = true;
            txtEditCedula.Size = new Size(100, 23);
            txtEditCedula.TabIndex = 12;
            txtEditCedula.TextChanged += txtEditCedula_TextChanged;
            // 
            // lblEditNombres
            // 
            lblEditNombres.AutoSize = true;
            lblEditNombres.Location = new Point(84, 33);
            lblEditNombres.Name = "lblEditNombres";
            lblEditNombres.Size = new Size(59, 15);
            lblEditNombres.TabIndex = 5;
            lblEditNombres.Text = "Nombres:";
            lblEditNombres.Click += lblEditNombres_Click;
            // 
            // txtEditApellidos
            // 
            txtEditApellidos.Location = new Point(522, 38);
            txtEditApellidos.Name = "txtEditApellidos";
            txtEditApellidos.Size = new Size(100, 23);
            txtEditApellidos.TabIndex = 11;
            txtEditApellidos.TextChanged += txtEditApellidos_TextChanged;
            // 
            // lblEditCargo
            // 
            lblEditCargo.AutoSize = true;
            lblEditCargo.Location = new Point(415, 81);
            lblEditCargo.Name = "lblEditCargo";
            lblEditCargo.Size = new Size(42, 15);
            lblEditCargo.TabIndex = 8;
            lblEditCargo.Text = "Cargo:";
            lblEditCargo.Click += lblEditCargo_Click;
            // 
            // txtEditNombres
            // 
            txtEditNombres.Location = new Point(187, 33);
            txtEditNombres.Name = "txtEditNombres";
            txtEditNombres.Size = new Size(100, 23);
            txtEditNombres.TabIndex = 10;
            txtEditNombres.TextChanged += textBox3_TextChanged;
            // 
            // lblEditCedula
            // 
            lblEditCedula.AutoSize = true;
            lblEditCedula.Location = new Point(84, 89);
            lblEditCedula.Name = "lblEditCedula";
            lblEditCedula.Size = new Size(47, 15);
            lblEditCedula.TabIndex = 7;
            lblEditCedula.Text = "Cedula:";
            lblEditCedula.Click += lblEditCedula_Click;
            // 
            // lblEditApellidos
            // 
            lblEditApellidos.AutoSize = true;
            lblEditApellidos.Location = new Point(415, 41);
            lblEditApellidos.Name = "lblEditApellidos";
            lblEditApellidos.Size = new Size(59, 15);
            lblEditApellidos.TabIndex = 6;
            lblEditApellidos.Text = "Apellidos:";
            lblEditApellidos.Click += lblEditApellidos_Click;
            // 
            // tabEliminar
            // 
            tabEliminar.Controls.Add(btnReactivarFuncionario);
            tabEliminar.Controls.Add(btnEliminarFuncionario);
            tabEliminar.Controls.Add(btnBuscarEliminarFunc);
            tabEliminar.Controls.Add(txtEliminarCedulaFunc);
            tabEliminar.Controls.Add(lblInfoEliminarFunc);
            tabEliminar.Controls.Add(lblEliminarCedula);
            tabEliminar.Controls.Add(lblEliminarTituloFunc);
            tabEliminar.Location = new Point(4, 24);
            tabEliminar.Name = "tabEliminar";
            tabEliminar.Padding = new Padding(3);
            tabEliminar.Size = new Size(792, 422);
            tabEliminar.TabIndex = 2;
            tabEliminar.Text = "Eliminar Funcionario";
            tabEliminar.UseVisualStyleBackColor = true;
            tabEliminar.Click += tabEliminar_Click;
            // 
            // btnReactivarFuncionario
            // 
            btnReactivarFuncionario.Location = new Point(377, 347);
            btnReactivarFuncionario.Name = "btnReactivarFuncionario";
            btnReactivarFuncionario.Size = new Size(118, 44);
            btnReactivarFuncionario.TabIndex = 6;
            btnReactivarFuncionario.Text = "REACTIVAR";
            btnReactivarFuncionario.UseVisualStyleBackColor = true;
            btnReactivarFuncionario.Click += btnReactivarFuncionario_Click;
            // 
            // btnEliminarFuncionario
            // 
            btnEliminarFuncionario.Location = new Point(226, 347);
            btnEliminarFuncionario.Name = "btnEliminarFuncionario";
            btnEliminarFuncionario.Size = new Size(113, 44);
            btnEliminarFuncionario.TabIndex = 5;
            btnEliminarFuncionario.Text = "DESACTIVAR FUNCIONARIO";
            btnEliminarFuncionario.UseVisualStyleBackColor = true;
            btnEliminarFuncionario.Click += btnEliminarFuncionario_Click;
            // 
            // btnBuscarEliminarFunc
            // 
            btnBuscarEliminarFunc.Location = new Point(601, 161);
            btnBuscarEliminarFunc.Name = "btnBuscarEliminarFunc";
            btnBuscarEliminarFunc.Size = new Size(75, 23);
            btnBuscarEliminarFunc.TabIndex = 4;
            btnBuscarEliminarFunc.Text = "Buscar";
            btnBuscarEliminarFunc.UseVisualStyleBackColor = true;
            btnBuscarEliminarFunc.Click += btnBuscarEliminarFunc_Click;
            // 
            // txtEliminarCedulaFunc
            // 
            txtEliminarCedulaFunc.Location = new Point(297, 156);
            txtEliminarCedulaFunc.Name = "txtEliminarCedulaFunc";
            txtEliminarCedulaFunc.Size = new Size(100, 23);
            txtEliminarCedulaFunc.TabIndex = 3;
            txtEliminarCedulaFunc.TextChanged += txtEliminarCedulaFunc_TextChanged;
            // 
            // lblInfoEliminarFunc
            // 
            lblInfoEliminarFunc.AutoSize = true;
            lblInfoEliminarFunc.Location = new Point(339, 227);
            lblInfoEliminarFunc.Name = "lblInfoEliminarFunc";
            lblInfoEliminarFunc.Size = new Size(0, 15);
            lblInfoEliminarFunc.TabIndex = 2;
            // 
            // lblEliminarCedula
            // 
            lblEliminarCedula.AutoSize = true;
            lblEliminarCedula.Location = new Point(103, 158);
            lblEliminarCedula.Name = "lblEliminarCedula";
            lblEliminarCedula.Size = new Size(130, 15);
            lblEliminarCedula.TabIndex = 1;
            lblEliminarCedula.Text = "Cédula del funcionario:";
            lblEliminarCedula.Click += lblEliminarCedula_Click;
            // 
            // lblEliminarTituloFunc
            // 
            lblEliminarTituloFunc.AutoSize = true;
            lblEliminarTituloFunc.Location = new Point(339, 84);
            lblEliminarTituloFunc.Name = "lblEliminarTituloFunc";
            lblEliminarTituloFunc.Size = new Size(0, 15);
            lblEliminarTituloFunc.TabIndex = 0;
            // 
            // GestionFuncionariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlFuncionarios);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GestionFuncionariosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion Funcionarios";
            tabControlFuncionarios.ResumeLayout(false);
            tabAgregar.ResumeLayout(false);
            tabAgregar.PerformLayout();
            tabBuscar.ResumeLayout(false);
            tabBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFuncionarios).EndInit();
            grpEdicionFuncionario.ResumeLayout(false);
            grpEdicionFuncionario.PerformLayout();
            tabEliminar.ResumeLayout(false);
            tabEliminar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlFuncionarios;
        private TabPage tabAgregar;
        private Button btnLimpiarFuncionario;
        private Button btnGuardarFuncionario;
        private TextBox txtCargo;
        private TextBox txtCedula;
        private TextBox txtApellidos;
        private TextBox txtNombres;
        private Label lblMensajeAgregar;
        private Label lblCargo;
        private Label lblCedula;
        private Label lblApellidos;
        private Label lblNombres;
        private TabPage tabBuscar;
        private TabPage tabEliminar;
        private Label lblEditCargo;
        private Label lblEditCedula;
        private Label lblEditApellidos;
        private Label lblEditNombres;
        private Label lblBuscarFuncionario;
        private Button btnCancelarEdicionFuncionario;
        private Button btnActualizarFuncionario;
        private Button btnMostrarTodosFuncionarios;
        private Button btnBuscarFuncionario;
        private TextBox txtEditApellidos;
        private TextBox txtEditNombres;
        private TextBox txtBuscarFuncionario;
        private DataGridView dgvFuncionarios;
        private GroupBox grpEdicionFuncionario;
        private TextBox txtEditCedula;
        private CheckBox chkEditActivo;
        private TextBox txtEditCargo;
        private Label lblInfoEliminarFunc;
        private Label lblEliminarCedula;
        private Label lblEliminarTituloFunc;
        private Button btnBuscarEliminarFunc;
        private TextBox txtEliminarCedulaFunc;
        private Button btnReactivarFuncionario;
        private Button btnEliminarFuncionario;
    }
}