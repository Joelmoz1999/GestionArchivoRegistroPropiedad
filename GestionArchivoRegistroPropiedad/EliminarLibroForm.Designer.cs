namespace GestionArchivoRegistroPropiedad
{
    partial class EliminarLibroForm
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
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtCodigo = new TextBox();
            lblInfo = new Label();
            lblCodigo = new Label();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(347, 332);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(102, 33);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Libro";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(677, 86);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(273, 86);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(365, 23);
            txtCodigo.TabIndex = 7;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(359, 180);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 15);
            lblInfo.TabIndex = 6;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(49, 86);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(201, 15);
            lblCodigo.TabIndex = 5;
            lblCodigo.Text = "Código de Barras del libro a eliminar:";
            // 
            // EliminarLibroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnBuscar);
            Controls.Add(txtCodigo);
            Controls.Add(lblInfo);
            Controls.Add(lblCodigo);
            Name = "EliminarLibroForm";
            Text = "EliminarLibroForm";
            Load += EliminarLibroForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtCodigo;
        private Label lblInfo;
        private Label lblCodigo;
    }
}