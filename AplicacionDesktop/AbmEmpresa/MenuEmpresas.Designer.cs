namespace PagoAgilFrba.AbmEmpresa
{
    partial class MenuEmpresas
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
            this.btnMenuPral = new System.Windows.Forms.Button();
            this.btnBuscarEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMenuPral
            // 
            this.btnMenuPral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnMenuPral.Location = new System.Drawing.Point(143, 143);
            this.btnMenuPral.Name = "btnMenuPral";
            this.btnMenuPral.Size = new System.Drawing.Size(124, 42);
            this.btnMenuPral.TabIndex = 5;
            this.btnMenuPral.Text = "Menu Principal";
            this.btnMenuPral.UseVisualStyleBackColor = true;
            this.btnMenuPral.Click += new System.EventHandler(this.btnMenuPral_Click);
            // 
            // btnBuscarEditar
            // 
            this.btnBuscarEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnBuscarEditar.Location = new System.Drawing.Point(69, 84);
            this.btnBuscarEditar.Name = "btnBuscarEditar";
            this.btnBuscarEditar.Size = new System.Drawing.Size(134, 30);
            this.btnBuscarEditar.TabIndex = 4;
            this.btnBuscarEditar.Text = "Buscar / Editar";
            this.btnBuscarEditar.UseVisualStyleBackColor = true;
            this.btnBuscarEditar.Click += new System.EventHandler(this.btnBuscarEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnAgregar.Location = new System.Drawing.Point(69, 25);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(134, 30);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // MenuEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 198);
            this.Controls.Add(this.btnMenuPral);
            this.Controls.Add(this.btnBuscarEditar);
            this.Controls.Add(this.btnAgregar);
            this.Name = "MenuEmpresas";
            this.Text = "MenuEmpresas";
            this.Load += new System.EventHandler(this.MenuEmpresas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMenuPral;
        private System.Windows.Forms.Button btnBuscarEditar;
        private System.Windows.Forms.Button btnAgregar;
    }
}