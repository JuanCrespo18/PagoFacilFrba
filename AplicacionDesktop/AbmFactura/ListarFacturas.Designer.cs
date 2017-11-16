namespace PagoAgilFrba.AbmFactura
{
    partial class ListarFacturas
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.cmdEditar = new System.Windows.Forms.Button();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboEmpresas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdBuscarCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rendicion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Activa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvFacturas);
            this.groupBox2.Controls.Add(this.cmdLimpiar);
            this.groupBox2.Controls.Add(this.cmdMenu);
            this.groupBox2.Controls.Add(this.cmdEditar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(878, 406);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvFacturas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Cliente,
            this.Empresa,
            this.Vto,
            this.Alta,
            this.Total,
            this.Pago,
            this.Rendicion,
            this.Activa});
            this.dgvFacturas.Location = new System.Drawing.Point(24, 19);
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.Size = new System.Drawing.Size(825, 255);
            this.dgvFacturas.TabIndex = 34;
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLimpiar.Location = new System.Drawing.Point(277, 280);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(156, 53);
            this.cmdLimpiar.TabIndex = 31;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
            // 
            // cmdMenu
            // 
            this.cmdMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.Location = new System.Drawing.Point(724, 357);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(125, 37);
            this.cmdMenu.TabIndex = 33;
            this.cmdMenu.Text = "Menu Principal";
            this.cmdMenu.UseVisualStyleBackColor = true;
            // 
            // cmdEditar
            // 
            this.cmdEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditar.Location = new System.Drawing.Point(442, 280);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(156, 53);
            this.cmdEditar.TabIndex = 32;
            this.cmdEditar.UseVisualStyleBackColor = true;
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuscar.Location = new System.Drawing.Point(215, 119);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(446, 31);
            this.cmdBuscar.TabIndex = 6;
            this.cmdBuscar.Text = "Buscar Facturas";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cmdBuscar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(878, 166);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNumeroFactura);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboEmpresas);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmdBuscarCliente);
            this.groupBox3.Controls.Add(this.txtCliente);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(157, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 79);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtros";
            // 
            // cboEmpresas
            // 
            this.cboEmpresas.FormattingEnabled = true;
            this.cboEmpresas.Location = new System.Drawing.Point(88, 44);
            this.cboEmpresas.Name = "cboEmpresas";
            this.cboEmpresas.Size = new System.Drawing.Size(227, 21);
            this.cboEmpresas.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Empresa";
            // 
            // cmdBuscarCliente
            // 
            this.cmdBuscarCliente.Location = new System.Drawing.Point(240, 19);
            this.cmdBuscarCliente.Name = "cmdBuscarCliente";
            this.cmdBuscarCliente.Size = new System.Drawing.Size(75, 20);
            this.cmdBuscarCliente.TabIndex = 16;
            this.cmdBuscarCliente.Text = "Buscar";
            this.cmdBuscarCliente.UseVisualStyleBackColor = true;
            this.cmdBuscarCliente.Click += new System.EventHandler(this.cmdBuscarCliente_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(88, 18);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(143, 20);
            this.txtCliente.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cliente";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(410, 30);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(143, 20);
            this.txtNumeroFactura.TabIndex = 23;
            this.txtNumeroFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFactura_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(346, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Numero";
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
            this.Empresa.Width = 73;
            // 
            // Vto
            // 
            this.Vto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Vto.HeaderText = "FechaVto";
            this.Vto.Name = "Vto";
            this.Vto.ReadOnly = true;
            // 
            // Alta
            // 
            this.Alta.HeaderText = "FechaAlta";
            this.Alta.Name = "Alta";
            this.Alta.ReadOnly = true;
            this.Alta.Width = 80;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 56;
            // 
            // Pago
            // 
            this.Pago.HeaderText = "Pagada";
            this.Pago.Name = "Pago";
            this.Pago.ReadOnly = true;
            this.Pago.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Pago.Width = 69;
            // 
            // Rendicion
            // 
            this.Rendicion.HeaderText = "Rendida";
            this.Rendicion.Name = "Rendicion";
            this.Rendicion.ReadOnly = true;
            this.Rendicion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rendicion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Rendicion.Width = 72;
            // 
            // Activa
            // 
            this.Activa.HeaderText = "Activa";
            this.Activa.Name = "Activa";
            this.Activa.ReadOnly = true;
            this.Activa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Activa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Activa.Width = 62;
            // 
            // ListarFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 578);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListarFacturas";
            this.Text = "Facturas";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.Button cmdMenu;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdBuscarCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEmpresas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pago;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Rendicion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activa;
    }
}