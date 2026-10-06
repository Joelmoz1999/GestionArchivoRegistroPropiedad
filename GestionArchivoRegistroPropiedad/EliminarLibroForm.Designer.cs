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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EliminarLibroForm));
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtCodigo = new TextBox();
            lblInfo = new Label();
            lblCodigo = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(296, 118);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(102, 33);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Libro";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(296, 89);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(102, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(78, 90);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(201, 23);
            txtCodigo.TabIndex = 7;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(78, 131);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 15);
            lblInfo.TabIndex = 6;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(78, 58);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(201, 15);
            lblCodigo.TabIndex = 5;
            lblCodigo.Text = "Código de Barras del libro a eliminar:";
            lblCodigo.Click += lblCodigo_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 25);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(138, 25);
            label2.Name = "label2";
            label2.Size = new Size(131, 21);
            label2.TabIndex = 75;
            label2.Text = "ELIMINAR LIBRO ";
            // 
            // EliminarLibroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 284);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEliminar);
            Controls.Add(btnBuscar);
            Controls.Add(txtCodigo);
            Controls.Add(lblInfo);
            Controls.Add(lblCodigo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EliminarLibroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RPPVM | Eliminar Libro";
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
        private Label label1;
        private Label label2;
    }
}