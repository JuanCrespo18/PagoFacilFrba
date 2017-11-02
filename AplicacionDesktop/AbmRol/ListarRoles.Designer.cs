namespace PagoAgilFrba.AbmRol
{
    partial class ListarRoles
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdNuevoRol = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdModificarRol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.cmdMenu);
            this.panel1.Controls.Add(this.cmdNuevoRol);
            this.panel1.Controls.Add(this.cmdCancelar);
            this.panel1.Controls.Add(this.cmdModificarRol);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboRoles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 298);
            this.panel1.TabIndex = 0;
            // 
            // cmdNuevoRol
            // 
            this.cmdNuevoRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNuevoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNuevoRol.Location = new System.Drawing.Point(111, 160);
            this.cmdNuevoRol.Name = "cmdNuevoRol";
            this.cmdNuevoRol.Size = new System.Drawing.Size(122, 45);
            this.cmdNuevoRol.TabIndex = 32;
            this.cmdNuevoRol.Text = "Nuevo Rol";
            this.cmdNuevoRol.UseVisualStyleBackColor = true;
            this.cmdNuevoRol.Click += new System.EventHandler(this.cmdNuevoRol_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.Location = new System.Drawing.Point(47, 109);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(122, 45);
            this.cmdCancelar.TabIndex = 31;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            // 
            // cmdModificarRol
            // 
            this.cmdModificarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdModificarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModificarRol.Location = new System.Drawing.Point(175, 109);
            this.cmdModificarRol.Name = "cmdModificarRol";
            this.cmdModificarRol.Size = new System.Drawing.Size(122, 45);
            this.cmdModificarRol.TabIndex = 30;
            this.cmdModificarRol.Text = "Modificar";
            this.cmdModificarRol.UseVisualStyleBackColor = true;
            this.cmdModificarRol.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rol";
            // 
            // cboRoles
            // 
            this.cboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Location = new System.Drawing.Point(96, 42);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(177, 24);
            this.cboRoles.TabIndex = 5;
            this.cboRoles.SelectedIndexChanged += new System.EventHandler(this.cboRoles_SelectedIndexChanged);
            // 
            // cmdMenu
            // 
            this.cmdMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.Location = new System.Drawing.Point(221, 252);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(119, 34);
            this.cmdMenu.TabIndex = 33;
            this.cmdMenu.Text = "Menu Principal";
            this.cmdMenu.UseVisualStyleBackColor = true;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
            // 
            // AbmListadoRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 298);
            this.Controls.Add(this.panel1);
            this.Name = "AbmListadoRol";
            this.Text = "Roles";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdModificarRol;
        private System.Windows.Forms.Button cmdNuevoRol;
        private System.Windows.Forms.Button cmdMenu;
    }
}