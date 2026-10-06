namespace GestionArchivoRegistroPropiedad
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lblUsuario = new Label();
            lblContraseña = new Label();
            lblMensaje = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(89, 148);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(69, 186);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(70, 15);
            lblContraseña.TabIndex = 1;
            lblContraseña.Text = "Contraseña:";
            lblContraseña.Click += lblContraseña_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(305, 378);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 15);
            lblMensaje.TabIndex = 2;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(145, 145);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(128, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(145, 183);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(128, 23);
            txtContrasena.TabIndex = 4;
            // 
            // btnIngresar
            // 
            btnIngresar.Anchor = AnchorStyles.None;
            btnIngresar.Location = new Point(154, 222);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(91, 32);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Iniciar Sesión";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 78);
            label1.Name = "label1";
            label1.Size = new Size(315, 25);
            label1.TabIndex = 7;
            label1.Text = "Registro de la Propiedad del Cantón";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(58, 103);
            label2.Name = "label2";
            label2.Size = new Size(231, 25);
            label2.TabIndex = 8;
            label2.Text = "Pedro Vicente Maldonado";
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(84, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(353, 276);
            Controls.Add(pictureBox1);
            Controls.Add(btnIngresar);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(lblMensaje);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(label1);
            Controls.Add(label2);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RPPVM | Iniciar Sesión";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private Label lblContraseña;
        private Label lblMensaje;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}