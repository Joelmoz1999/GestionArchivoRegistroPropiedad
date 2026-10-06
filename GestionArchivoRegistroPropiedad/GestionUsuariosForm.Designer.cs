namespace GestionArchivoRegistroPropiedad
{
    partial class GestionUsuariosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionUsuariosForm));
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnMostrarTodos = new Button();
            btnNuevoUsuario = new Button();
            dgvUsuarios = new DataGridView();
            grpDatos = new GroupBox();
            chkActivo = new CheckBox();
            txtConfirmar = new TextBox();
            lblConfirmar = new Label();
            txtContrasena = new TextBox();
            lblContrasena = new Label();
            cmbRol = new ComboBox();
            lblRol = new Label();
            txtNombreUsuario = new TextBox();
            lblNombreUsuario = new Label();
            txtNombreCompleto = new TextBox();
            lblNombreCompleto = new Label();
            grpAcciones = new GroupBox();
            btnReactivar = new Button();
            btnDesactivar = new Button();
            btnCambiarContrasena = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            grpDatos.SuspendLayout();
            grpAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(37, 32);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(139, 33);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 23);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(291, 33);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Location = new Point(424, 33);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(75, 23);
            btnMostrarTodos.TabIndex = 3;
            btnMostrarTodos.Text = "Mostrar Todos";
            btnMostrarTodos.UseVisualStyleBackColor = true;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            // 
            // btnNuevoUsuario
            // 
            btnNuevoUsuario.BackColor = Color.LightGreen;
            btnNuevoUsuario.Location = new Point(560, 33);
            btnNuevoUsuario.Name = "btnNuevoUsuario";
            btnNuevoUsuario.Size = new Size(155, 23);
            btnNuevoUsuario.TabIndex = 4;
            btnNuevoUsuario.Text = "➕ Nuevo Usuario";
            btnNuevoUsuario.UseVisualStyleBackColor = false;
            btnNuevoUsuario.Click += btnNuevoUsuario_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(108, 83);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(525, 150);
            dgvUsuarios.TabIndex = 5;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(chkActivo);
            grpDatos.Controls.Add(txtConfirmar);
            grpDatos.Controls.Add(lblConfirmar);
            grpDatos.Controls.Add(txtContrasena);
            grpDatos.Controls.Add(lblContrasena);
            grpDatos.Controls.Add(cmbRol);
            grpDatos.Controls.Add(lblRol);
            grpDatos.Controls.Add(txtNombreUsuario);
            grpDatos.Controls.Add(lblNombreUsuario);
            grpDatos.Controls.Add(txtNombreCompleto);
            grpDatos.Controls.Add(lblNombreCompleto);
            grpDatos.Location = new Point(21, 251);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(384, 187);
            grpDatos.TabIndex = 6;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del Usuario";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(324, 142);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 11;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtConfirmar
            // 
            txtConfirmar.Location = new Point(134, 161);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(100, 23);
            txtConfirmar.TabIndex = 10;
            // 
            // lblConfirmar
            // 
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(11, 164);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(64, 15);
            lblConfirmar.TabIndex = 9;
            lblConfirmar.Text = "Confirmar:";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(134, 124);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(100, 23);
            txtContrasena.TabIndex = 8;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(11, 127);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(70, 15);
            lblContrasena.TabIndex = 7;
            lblContrasena.Text = "Contraseña:";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "EncargadoArchivo" });
            cmbRol.Location = new Point(134, 83);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(100, 23);
            cmbRol.TabIndex = 6;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(11, 91);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(27, 15);
            lblRol.TabIndex = 5;
            lblRol.Text = "Rol:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(134, 54);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 4;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(11, 59);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(50, 15);
            lblNombreUsuario.TabIndex = 3;
            lblNombreUsuario.Text = "Usuario:";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(134, 22);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(100, 23);
            txtNombreCompleto.TabIndex = 2;
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Location = new Point(6, 30);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(110, 15);
            lblNombreCompleto.TabIndex = 1;
            lblNombreCompleto.Text = "Nombre Completo:";
            // 
            // grpAcciones
            // 
            grpAcciones.Controls.Add(btnReactivar);
            grpAcciones.Controls.Add(btnDesactivar);
            grpAcciones.Controls.Add(btnCambiarContrasena);
            grpAcciones.Controls.Add(btnCancelar);
            grpAcciones.Controls.Add(btnGuardar);
            grpAcciones.Location = new Point(402, 257);
            grpAcciones.Name = "grpAcciones";
            grpAcciones.Size = new Size(397, 194);
            grpAcciones.TabIndex = 7;
            grpAcciones.TabStop = false;
            grpAcciones.Text = "Acciones";
            // 
            // btnReactivar
            // 
            btnReactivar.BackColor = Color.LightGreen;
            btnReactivar.Location = new Point(206, 53);
            btnReactivar.Name = "btnReactivar";
            btnReactivar.Size = new Size(107, 41);
            btnReactivar.TabIndex = 8;
            btnReactivar.Text = "✅ Reactivar";
            btnReactivar.UseVisualStyleBackColor = false;
            btnReactivar.Click += btnReactivar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.BackColor = Color.Peru;
            btnDesactivar.Location = new Point(206, 114);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(107, 41);
            btnDesactivar.TabIndex = 7;
            btnDesactivar.Text = "🚫 Desactivar";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnCambiarContrasena
            // 
            btnCambiarContrasena.Location = new Point(61, 132);
            btnCambiarContrasena.Name = "btnCambiarContrasena";
            btnCambiarContrasena.Size = new Size(107, 41);
            btnCambiarContrasena.TabIndex = 6;
            btnCambiarContrasena.Text = "🔑 Cambiar Contraseña";
            btnCambiarContrasena.UseVisualStyleBackColor = true;
            btnCambiarContrasena.Click += btnCambiarContrasena_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(62, 75);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(106, 34);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "❌ Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.LightGreen;
            btnGuardar.Location = new Point(63, 25);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 34);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // GestionUsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpAcciones);
            Controls.Add(grpDatos);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnNuevoUsuario);
            Controls.Add(btnMostrarTodos);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GestionUsuariosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion Usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpAcciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnMostrarTodos;
        private Button btnNuevoUsuario;
        private DataGridView dgvUsuarios;
        private GroupBox grpDatos;
        private Label lblNombreCompleto;
        private CheckBox chkActivo;
        private TextBox txtConfirmar;
        private Label lblConfirmar;
        private TextBox txtContrasena;
        private Label lblContrasena;
        private ComboBox cmbRol;
        private Label lblRol;
        private TextBox txtNombreUsuario;
        private Label lblNombreUsuario;
        private TextBox txtNombreCompleto;
        private GroupBox grpAcciones;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnCambiarContrasena;
        private Button btnReactivar;
        private Button btnDesactivar;
    }
}