namespace PagoAgilFrba.AbmFactura
{
    partial class AltaFactura
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
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.chkHabilitada = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdAgregarItem = new System.Windows.Forms.Button();
            this.cmdEliminarItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.dtpVto = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpAlta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEmpresas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBuscarCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdCancelar);
            this.groupBox1.Controls.Add(this.chkHabilitada);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.cmdAceptar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmdLimpiar);
            this.groupBox1.Controls.Add(this.dtpVto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpAlta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNumeroFactura);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboEmpresas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdBuscarCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 585);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.Location = new System.Drawing.Point(25, 503);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(109, 41);
            this.cmdCancelar.TabIndex = 41;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // chkHabilitada
            // 
            this.chkHabilitada.AutoSize = true;
            this.chkHabilitada.Location = new System.Drawing.Point(290, 249);
            this.chkHabilitada.Name = "chkHabilitada";
            this.chkHabilitada.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitada.TabIndex = 40;
            this.chkHabilitada.Text = "Habilitada";
            this.chkHabilitada.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdAgregarItem);
            this.groupBox2.Controls.Add(this.cmdEliminarItem);
            this.groupBox2.Controls.Add(this.dgvItems);
            this.groupBox2.Location = new System.Drawing.Point(12, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 174);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Items";
            // 
            // cmdAgregarItem
            // 
            this.cmdAgregarItem.Location = new System.Drawing.Point(276, 134);
            this.cmdAgregarItem.Name = "cmdAgregarItem";
            this.cmdAgregarItem.Size = new System.Drawing.Size(75, 23);
            this.cmdAgregarItem.TabIndex = 37;
            this.cmdAgregarItem.Text = "Agregar";
            this.cmdAgregarItem.UseVisualStyleBackColor = true;
            this.cmdAgregarItem.Click += new System.EventHandler(this.cmdAgregarItem_Click);
            // 
            // cmdEliminarItem
            // 
            this.cmdEliminarItem.Location = new System.Drawing.Point(195, 134);
            this.cmdEliminarItem.Name = "cmdEliminarItem";
            this.cmdEliminarItem.Size = new System.Drawing.Size(75, 23);
            this.cmdEliminarItem.TabIndex = 36;
            this.cmdEliminarItem.Text = "Eliminar";
            this.cmdEliminarItem.UseVisualStyleBackColor = true;
            this.cmdEliminarItem.Click += new System.EventHandler(this.cmdEliminarItem_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Cantidad,
            this.Monto});
            this.dgvItems.Location = new System.Drawing.Point(6, 19);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(350, 109);
            this.dgvItems.TabIndex = 35;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 41;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(254, 450);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(108, 20);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAceptar.Location = new System.Drawing.Point(254, 503);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(109, 41);
            this.cmdAceptar.TabIndex = 37;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 453);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total   $";
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLimpiar.Location = new System.Drawing.Point(139, 503);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(109, 41);
            this.cmdLimpiar.TabIndex = 36;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
            // 
            // dtpVto
            // 
            this.dtpVto.Location = new System.Drawing.Point(126, 206);
            this.dtpVto.Name = "dtpVto";
            this.dtpVto.Size = new System.Drawing.Size(237, 20);
            this.dtpVto.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha Vencimiento";
            // 
            // dtpAlta
            // 
            this.dtpAlta.Location = new System.Drawing.Point(126, 161);
            this.dtpAlta.MaxDate = new System.DateTime(2017, 11, 15, 0, 0, 0, 0);
            this.dtpAlta.Name = "dtpAlta";
            this.dtpAlta.Size = new System.Drawing.Size(237, 20);
            this.dtpAlta.TabIndex = 8;
            this.dtpAlta.Value = new System.DateTime(2017, 11, 15, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Alta";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(126, 115);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(237, 20);
            this.txtNumeroFactura.TabIndex = 6;
            this.txtNumeroFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFactura_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Numero de Factura";
            // 
            // cboEmpresas
            // 
            this.cboEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresas.FormattingEnabled = true;
            this.cboEmpresas.Location = new System.Drawing.Point(126, 73);
            this.cboEmpresas.Name = "cboEmpresas";
            this.cboEmpresas.Size = new System.Drawing.Size(237, 21);
            this.cboEmpresas.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Empresa";
            // 
            // cmdBuscarCliente
            // 
            this.cmdBuscarCliente.Location = new System.Drawing.Point(288, 28);
            this.cmdBuscarCliente.Name = "cmdBuscarCliente";
            this.cmdBuscarCliente.Size = new System.Drawing.Size(75, 23);
            this.cmdBuscarCliente.TabIndex = 2;
            this.cmdBuscarCliente.Text = "Buscar";
            this.cmdBuscarCliente.UseVisualStyleBackColor = true;
            this.cmdBuscarCliente.Click += new System.EventHandler(this.cmdBuscarCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(126, 31);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(156, 20);
            this.txtCliente.TabIndex = 0;
            // 
            // AltaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 585);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaFactura";
            this.Text = "Factura";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpVto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpAlta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEmpresas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdAgregarItem;
        private System.Windows.Forms.Button cmdEliminarItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.CheckBox chkHabilitada;
        private System.Windows.Forms.Button cmdCancelar;
    }
}