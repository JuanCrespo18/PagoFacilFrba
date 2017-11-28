namespace PagoAgilFrba.Login
{
    partial class ElegirSucursalYRol
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
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cboSucursales = new System.Windows.Forms.ComboBox();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(136, 169);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(90, 41);
            this.cmdAceptar.TabIndex = 14;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cboSucursales
            // 
            this.cboSucursales.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursales.FormattingEnabled = true;
            this.cboSucursales.Items.AddRange(new object[] {
            "Porcentaje de facturas cobradas por empresa",
            "Empresas con mayor monto rendido",
            "Clientes con mas pagos",
            "Clientes con mayor porcentaje de facturas pagadas (clientes cumplidores)"});
            this.cboSucursales.Location = new System.Drawing.Point(127, 114);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Size = new System.Drawing.Size(193, 24);
            this.cboSucursales.TabIndex = 13;
            // 
            // cboRoles
            // 
            this.cboRoles.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Items.AddRange(new object[] {
            "Porcentaje de facturas cobradas por empresa",
            "Empresas con mayor monto rendido",
            "Clientes con mas pagos",
            "Clientes con mayor porcentaje de facturas pagadas (clientes cumplidores)"});
            this.cboRoles.Location = new System.Drawing.Point(127, 43);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(193, 24);
            this.cboRoles.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Elegir Sucursal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Elegir Rol";
            // 
            // ElegirSucursalYRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 261);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cboSucursales);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ElegirSucursalYRol";
            this.Text = "ElegirSucursalYRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.ComboBox cboSucursales;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}