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
            this.cmdFacturas = new System.Windows.Forms.Button();
            this.cmdSucursales = new System.Windows.Forms.Button();
            this.cmdEmpresas = new System.Windows.Forms.Button();
            this.cmdClientes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdPagarFacturas = new System.Windows.Forms.Button();
            this.cmdRendir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdRoles
            // 
            this.cmdRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRoles.Location = new System.Drawing.Point(12, 19);
            this.cmdRoles.Name = "cmdRoles";
            this.cmdRoles.Size = new System.Drawing.Size(150, 47);
            this.cmdRoles.TabIndex = 4;
            this.cmdRoles.Text = "ROLES";
            this.cmdRoles.UseVisualStyleBackColor = true;
            this.cmdRoles.Click += new System.EventHandler(this.cmdRoles_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdFacturas);
            this.groupBox1.Controls.Add(this.cmdSucursales);
            this.groupBox1.Controls.Add(this.cmdEmpresas);
            this.groupBox1.Controls.Add(this.cmdClientes);
            this.groupBox1.Controls.Add(this.cmdRoles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 191);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EDICION";
            // 
            // cmdFacturas
            // 
            this.cmdFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFacturas.Location = new System.Drawing.Point(93, 125);
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
            this.cmdSucursales.Location = new System.Drawing.Point(168, 72);
            this.cmdSucursales.Name = "cmdSucursales";
            this.cmdSucursales.Size = new System.Drawing.Size(150, 47);
            this.cmdSucursales.TabIndex = 7;
            this.cmdSucursales.Text = "SUCURSALES";
            this.cmdSucursales.UseVisualStyleBackColor = true;
            // 
            // cmdEmpresas
            // 
            this.cmdEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmpresas.Location = new System.Drawing.Point(12, 72);
            this.cmdEmpresas.Name = "cmdEmpresas";
            this.cmdEmpresas.Size = new System.Drawing.Size(150, 47);
            this.cmdEmpresas.TabIndex = 6;
            this.cmdEmpresas.Text = "EMPRESAS";
            this.cmdEmpresas.UseVisualStyleBackColor = true;
            // 
            // cmdClientes
            // 
            this.cmdClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClientes.Location = new System.Drawing.Point(168, 19);
            this.cmdClientes.Name = "cmdClientes";
            this.cmdClientes.Size = new System.Drawing.Size(150, 47);
            this.cmdClientes.TabIndex = 5;
            this.cmdClientes.Text = "CLIENTES";
            this.cmdClientes.UseVisualStyleBackColor = true;
            this.cmdClientes.Click += new System.EventHandler(this.cmdClientes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdRendir);
            this.groupBox2.Controls.Add(this.cmdPagarFacturas);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 194);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NEGOCIO";
            // 
            // cmdPagarFacturas
            // 
            this.cmdPagarFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPagarFacturas.Location = new System.Drawing.Point(12, 19);
            this.cmdPagarFacturas.Name = "cmdPagarFacturas";
            this.cmdPagarFacturas.Size = new System.Drawing.Size(150, 47);
            this.cmdPagarFacturas.TabIndex = 9;
            this.cmdPagarFacturas.Text = "PAGAR FACTURAS";
            this.cmdPagarFacturas.UseVisualStyleBackColor = true;
            this.cmdPagarFacturas.Click += new System.EventHandler(this.cmdPagarFacturas_Click);
            // 
            // cmdRendir
            // 
            this.cmdRendir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRendir.Location = new System.Drawing.Point(168, 19);
            this.cmdRendir.Name = "cmdRendir";
            this.cmdRendir.Size = new System.Drawing.Size(150, 47);
            this.cmdRendir.TabIndex = 10;
            this.cmdRendir.Text = "RENDIR FACTURAS";
            this.cmdRendir.UseVisualStyleBackColor = true;
            this.cmdRendir.Click += new System.EventHandler(this.cmdRendir_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 391);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MenuPrincipal";
            this.Text = "Menu Principal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdFacturas;
        private System.Windows.Forms.Button cmdSucursales;
        private System.Windows.Forms.Button cmdEmpresas;
        private System.Windows.Forms.Button cmdClientes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdPagarFacturas;
        private System.Windows.Forms.Button cmdRendir;
    }
}