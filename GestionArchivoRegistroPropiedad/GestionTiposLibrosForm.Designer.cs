namespace GestionArchivoRegistroPropiedad
{
    partial class mnuGestionTipoLibro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mnuGestionTipoLibro));
            lblTitulo = new Label();
            lblAgregar = new Label();
            lblExistentes = new Label();
            txtNuevoTipo = new TextBox();
            btnAgregar = new Button();
            lstTipoLibro = new ListBox();
            btnEliminar = new Button();
            btnReactivar = new Button();
            btnCerrar = new Button();
            btnEditar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(145, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(165, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE TIPOS DE LIBROS";
            // 
            // lblAgregar
            // 
            lblAgregar.AutoSize = true;
            lblAgregar.Location = new Point(61, 78);
            lblAgregar.Name = "lblAgregar";
            lblAgregar.Size = new Size(127, 15);
            lblAgregar.TabIndex = 1;
            lblAgregar.Text = "➕ Agregar nuevo tipo:";
            // 
            // lblExistentes
            // 
            lblExistentes.AutoSize = true;
            lblExistentes.Location = new Point(74, 135);
            lblExistentes.Name = "lblExistentes";
            lblExistentes.Size = new Size(108, 15);
            lblExistentes.TabIndex = 2;
            lblExistentes.Text = "📋 Tipos existentes:";
            // 
            // txtNuevoTipo
            // 
            txtNuevoTipo.Location = new Point(194, 75);
            txtNuevoTipo.Name = "txtNuevoTipo";
            txtNuevoTipo.Size = new Size(148, 23);
            txtNuevoTipo.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(348, 75);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lstTipoLibro
            // 
            lstTipoLibro.FormattingEnabled = true;
            lstTipoLibro.Location = new Point(74, 135);
            lstTipoLibro.Name = "lstTipoLibro";
            lstTipoLibro.Size = new Size(349, 124);
            lstTipoLibro.TabIndex = 5;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(145, 292);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnReactivar
            // 
            btnReactivar.Location = new Point(281, 292);
            btnReactivar.Name = "btnReactivar";
            btnReactivar.Size = new Size(142, 23);
            btnReactivar.TabIndex = 7;
            btnReactivar.Text = "♻️ Reactivar";
            btnReactivar.UseVisualStyleBackColor = true;
            btnReactivar.Click += btnReactivar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(145, 339);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(130, 23);
            btnCerrar.TabIndex = 8;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Enabled = false;
            btnEditar.Location = new Point(9, 292);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(130, 23);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "✏️ Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // mnuGestionTipoLibro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 389);
            Controls.Add(btnEditar);
            Controls.Add(btnCerrar);
            Controls.Add(btnReactivar);
            Controls.Add(btnEliminar);
            Controls.Add(lstTipoLibro);
            Controls.Add(btnAgregar);
            Controls.Add(txtNuevoTipo);
            Controls.Add(lblExistentes);
            Controls.Add(lblAgregar);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "mnuGestionTipoLibro";
            Text = "Registro de la Propiedad del Cantón Pedro Vicente Maldonado | Gestion Tipos de Libros";
            Load += GestionTiposLibrosForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblAgregar;
        private Label lblExistentes;
        private TextBox txtNuevoTipo;
        private Button btnAgregar;
        private ListBox lstTipoLibro;
        private Button btnEliminar;
        private Button btnReactivar;
        private Button btnCerrar;
        private Button btnEditar;
    }
}