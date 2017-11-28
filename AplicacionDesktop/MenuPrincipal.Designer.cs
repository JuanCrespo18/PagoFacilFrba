namespace PagoAgilFrba
{
    partial class MenuPrincipal
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
            this.cmdRoles = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdFacturas = new System.Windows.Forms.Button();
            this.cmdSucursales = new System.Windows.Forms.Button();
            this.cmdEmpresas = new System.Windows.Forms.Button();
            this.cmdClientes = new System.Windows.Forms.Button();
            this.cmdRegistroPago = new System.Windows.Forms.Button();
            this.cmdRendir = new System.Windows.Forms.Button();
            this.cmdDevoluciones = new System.Windows.Forms.Button();
            this.cmdLogout = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdRoles
            // 
            this.cmdRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRoles.Location = new System.Drawing.Point(20, 19);
            this.cmdRoles.Name = "cmdRoles";
            this.cmdRoles.Size = new System.Drawing.Size(150, 47);
            this.cmdRoles.TabIndex = 4;
            this.cmdRoles.Text = "ROLES";
            this.cmdRoles.UseVisualStyleBackColor = true;
            this.cmdRoles.Click += new System.EventHandler(this.cmdRoles_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmdFacturas);
            this.groupBox1.Controls.Add(this.cmdSucursales);
            this.groupBox1.Controls.Add(this.cmdEmpresas);
            this.groupBox1.Controls.Add(this.cmdClientes);
            this.groupBox1.Controls.Add(this.cmdRoles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 191);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EDICION";
            // 
            // button1
            // 
            this.button1.AccessibleName = "";
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(176, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 47);
            this.button1.TabIndex = 9;
            this.button1.Text = "ESTADISTICAS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdFacturas
            // 
            this.cmdFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFacturas.Location = new System.Drawing.Point(20, 125);
            this.cmdFacturas.Name = "cmdFacturas";
            this.cmdFacturas.Size = new System.Drawing.Size(150, 47);
            this.cmdFacturas.TabIndex = 8;
            this.cmdFacturas.Text = "FACTURAS";
            this.cmdFacturas.UseVisualStyleBackColor = true;
            this.cmdFacturas.Click += new System.EventHandler(this.cmdFacturas_Click);
            // 
            // cmdSucursales
            // 
            this.cmdSucursales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSucursales.Location = new System.Drawing.Point(176, 72);
            this.cmdSucursales.Name = "cmdSucursales";
            this.cmdSucursales.Size = new System.Drawing.Size(150, 47);
            this.cmdSucursales.TabIndex = 10;
            this.cmdSucursales.Text = "SUCURSALES";
            this.cmdSucursales.Click += new System.EventHandler(this.cmdSucursales_Click);
            // 
            // cmdEmpresas
            // 
            this.cmdEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmpresas.Location = new System.Drawing.Point(20, 72);
            this.cmdEmpresas.Name = "cmdEmpresas";
            this.cmdEmpresas.Size = new System.Drawing.Size(150, 47);
            this.cmdEmpresas.TabIndex = 11;
            this.cmdEmpresas.Text = "EMPRESAS";
            this.cmdEmpresas.Click += new System.EventHandler(this.cmdEmpresas_Click);
            // 
            // cmdClientes
            // 
            this.cmdClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClientes.Location = new System.Drawing.Point(176, 19);
            this.cmdClientes.Name = "cmdClientes";
            this.cmdClientes.Size = new System.Drawing.Size(150, 47);
            this.cmdClientes.TabIndex = 5;
            this.cmdClientes.Text = "CLIENTES";
            this.cmdClientes.UseVisualStyleBackColor = true;
            this.cmdClientes.Click += new System.EventHandler(this.cmdClientes_Click);
            // 
            // cmdRegistroPago
            // 
            this.cmdRegistroPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRegistroPago.Location = new System.Drawing.Point(20, 207);
            this.cmdRegistroPago.Name = "cmdRegistroPago";
            this.cmdRegistroPago.Size = new System.Drawing.Size(150, 47);
            this.cmdRegistroPago.TabIndex = 12;
            this.cmdRegistroPago.Text = "REGISTRAR PAGO";
            this.cmdRegistroPago.UseVisualStyleBackColor = true;
            this.cmdRegistroPago.Click += new System.EventHandler(this.cmdRegistroPago_Click);
            // 
            // cmdRendir
            // 
            this.cmdRendir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRendir.Location = new System.Drawing.Point(176, 207);
            this.cmdRendir.Name = "cmdRendir";
            this.cmdRendir.Size = new System.Drawing.Size(150, 47);
            this.cmdRendir.TabIndex = 13;
            this.cmdRendir.Text = "RENDIR FACTURAS";
            this.cmdRendir.UseVisualStyleBackColor = true;
            this.cmdRendir.Click += new System.EventHandler(this.cmdRendir_Click_1);
            // 
            // cmdDevoluciones
            // 
            this.cmdDevoluciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDevoluciones.Location = new System.Drawing.Point(20, 260);
            this.cmdDevoluciones.Name = "cmdDevoluciones";
            this.cmdDevoluciones.Size = new System.Drawing.Size(150, 47);
            this.cmdDevoluciones.TabIndex = 14;
            this.cmdDevoluciones.Text = "DEVOLUCIONES";
            this.cmdDevoluciones.UseVisualStyleBackColor = true;
            this.cmdDevoluciones.Click += new System.EventHandler(this.cmdDevoluciones_Click_1);
            // 
            // cmdLogout
            // 
            this.cmdLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLogout.Location = new System.Drawing.Point(176, 332);
            this.cmdLogout.Name = "cmdLogout";
            this.cmdLogout.Size = new System.Drawing.Size(150, 47);
            this.cmdLogout.TabIndex = 15;
            this.cmdLogout.Text = "Cerrar Sesión";
            this.cmdLogout.UseVisualStyleBackColor = true;
            this.cmdLogout.Click += new System.EventHandler(this.cmdLogout_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 391);
            this.Controls.Add(this.cmdLogout);
            this.Controls.Add(this.cmdDevoluciones);
            this.Controls.Add(this.cmdRendir);
            this.Controls.Add(this.cmdRegistroPago);
            this.Controls.Add(this.groupBox1);
            this.Name = "MenuPrincipal";
            this.Text = "Menu Principal";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdFacturas;
        private System.Windows.Forms.Button cmdSucursales;
        private System.Windows.Forms.Button cmdEmpresas;
        private System.Windows.Forms.Button cmdClientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdRegistroPago;
        private System.Windows.Forms.Button cmdRendir;
        private System.Windows.Forms.Button cmdDevoluciones;
        private System.Windows.Forms.Button cmdLogout;
    }
}