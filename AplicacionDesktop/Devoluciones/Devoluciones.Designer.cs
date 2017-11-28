namespace PagoAgilFrba.Devoluciones
{
    partial class Devoluciones
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdDevolver = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdLimpiarFacturas = new System.Windows.Forms.Button();
            this.cmdQuitar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbRendicion = new System.Windows.Forms.RadioButton();
            this.rdbPago = new System.Windows.Forms.RadioButton();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdMenu);
            this.groupBox1.Controls.Add(this.cmdDevolver);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturas";
            // 
            // cmdDevolver
            // 
            this.cmdDevolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDevolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDevolver.Location = new System.Drawing.Point(246, 362);
            this.cmdDevolver.Name = "cmdDevolver";
            this.cmdDevolver.Size = new System.Drawing.Size(156, 53);
            this.cmdDevolver.TabIndex = 33;
            this.cmdDevolver.Text = "Devolver";
            this.cmdDevolver.UseVisualStyleBackColor = true;
            this.cmdDevolver.Click += new System.EventHandler(this.cmdDevolver_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdLimpiarFacturas);
            this.groupBox3.Controls.Add(this.cmdQuitar);
            this.groupBox3.Controls.Add(this.cmdAgregar);
            this.groupBox3.Controls.Add(this.dgvFacturas);
            this.groupBox3.Location = new System.Drawing.Point(6, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(621, 244);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ingrese facturas a devolver";
            // 
            // cmdLimpiarFacturas
            // 
            this.cmdLimpiarFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLimpiarFacturas.Location = new System.Drawing.Point(12, 203);
            this.cmdLimpiarFacturas.Name = "cmdLimpiarFacturas";
            this.cmdLimpiarFacturas.Size = new System.Drawing.Size(107, 28);
            this.cmdLimpiarFacturas.TabIndex = 38;
            this.cmdLimpiarFacturas.Text = "Limpiar";
            this.cmdLimpiarFacturas.UseVisualStyleBackColor = true;
            this.cmdLimpiarFacturas.Click += new System.EventHandler(this.cmdLimpiarFacturas_Click);
            // 
            // cmdQuitar
            // 
            this.cmdQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuitar.Location = new System.Drawing.Point(389, 203);
            this.cmdQuitar.Name = "cmdQuitar";
            this.cmdQuitar.Size = new System.Drawing.Size(107, 28);
            this.cmdQuitar.TabIndex = 37;
            this.cmdQuitar.Text = "Quitar";
            this.cmdQuitar.UseVisualStyleBackColor = true;
            this.cmdQuitar.Click += new System.EventHandler(this.cmdQuitar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAgregar.Location = new System.Drawing.Point(502, 203);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(107, 28);
            this.cmdAgregar.TabIndex = 36;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Cliente,
            this.Empresa,
            this.Fecha,
            this.Total});
            this.dgvFacturas.Location = new System.Drawing.Point(12, 19);
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.Size = new System.Drawing.Size(597, 178);
            this.dgvFacturas.TabIndex = 35;
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Empresa
            // 
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbRendicion);
            this.groupBox2.Controls.Add(this.rdbPago);
            this.groupBox2.Location = new System.Drawing.Point(246, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 72);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de devolución";
            // 
            // rdbRendicion
            // 
            this.rdbRendicion.AutoSize = true;
            this.rdbRendicion.Enabled = false;
            this.rdbRendicion.Location = new System.Drawing.Point(62, 30);
            this.rdbRendicion.Name = "rdbRendicion";
            this.rdbRendicion.Size = new System.Drawing.Size(73, 17);
            this.rdbRendicion.TabIndex = 1;
            this.rdbRendicion.TabStop = true;
            this.rdbRendicion.Text = "Rendición";
            this.rdbRendicion.UseVisualStyleBackColor = true;
            // 
            // rdbPago
            // 
            this.rdbPago.AutoSize = true;
            this.rdbPago.Enabled = false;
            this.rdbPago.Location = new System.Drawing.Point(6, 30);
            this.rdbPago.Name = "rdbPago";
            this.rdbPago.Size = new System.Drawing.Size(50, 17);
            this.rdbPago.TabIndex = 0;
            this.rdbPago.TabStop = true;
            this.rdbPago.Text = "Pago";
            this.rdbPago.UseVisualStyleBackColor = true;
            this.rdbPago.CheckedChanged += new System.EventHandler(this.rdbPago_CheckedChanged);
            // 
            // cmdMenu
            // 
            this.cmdMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.Location = new System.Drawing.Point(502, 436);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(125, 37);
            this.cmdMenu.TabIndex = 35;
            this.cmdMenu.Text = "Menu Principal";
            this.cmdMenu.UseVisualStyleBackColor = true;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
            // 
            // Devoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 479);
            this.Controls.Add(this.groupBox1);
            this.Name = "Devoluciones";
            this.Text = "Devoluciones";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbRendicion;
        private System.Windows.Forms.RadioButton rdbPago;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdLimpiarFacturas;
        private System.Windows.Forms.Button cmdQuitar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button cmdDevolver;
        private System.Windows.Forms.Button cmdMenu;
    }
}