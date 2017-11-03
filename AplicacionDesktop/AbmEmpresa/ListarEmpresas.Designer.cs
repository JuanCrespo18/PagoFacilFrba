namespace PagoAgilFrba.AbmEmpresa
{
    partial class ListarEmpresas
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
            this.groupBox1Emp = new System.Windows.Forms.GroupBox();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.label2Emp = new System.Windows.Forms.Label();
            this.label1Emp = new System.Windows.Forms.Label();
            this.txtNombreEmp = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.label4Emp = new System.Windows.Forms.Label();
            this.groupBox2Emp = new System.Windows.Forms.GroupBox();
            this.dgvEmpresas = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdLimpiarEmp = new System.Windows.Forms.Button();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.cmdEditar = new System.Windows.Forms.Button();
            this.groupBox1Emp.SuspendLayout();
            this.groupBox2Emp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1Emp
            // 
            this.groupBox1Emp.Controls.Add(this.txtNombreEmp);
            this.groupBox1Emp.Controls.Add(this.cmdBuscar);
            this.groupBox1Emp.Controls.Add(this.label2Emp);
            this.groupBox1Emp.Controls.Add(this.label1Emp);
            this.groupBox1Emp.Controls.Add(this.txtCuit);
            this.groupBox1Emp.Controls.Add(this.txtRubro);
            this.groupBox1Emp.Controls.Add(this.label4Emp);
            this.groupBox1Emp.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1Emp.Location = new System.Drawing.Point(0, 0);
            this.groupBox1Emp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1Emp.Name = "groupBox1Emp";
            this.groupBox1Emp.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1Emp.Size = new System.Drawing.Size(1164, 169);
            this.groupBox1Emp.TabIndex = 26;
            this.groupBox1Emp.TabStop = false;
            this.groupBox1Emp.Text = "Filtros de busqueda";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuscar.Location = new System.Drawing.Point(284, 111);
            this.cmdBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(595, 38);
            this.cmdBuscar.TabIndex = 6;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // label2Emp
            // 
            this.label2Emp.AutoSize = true;
            this.label2Emp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2Emp.Location = new System.Drawing.Point(280, 66);
            this.label2Emp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2Emp.Name = "label2Emp";
            this.label2Emp.Size = new System.Drawing.Size(58, 17);
            this.label2Emp.TabIndex = 14;
            this.label2Emp.Text = "Cuit";
            // 
            // label1Emp
            // 
            this.label1Emp.AutoSize = true;
            this.label1Emp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Emp.Location = new System.Drawing.Point(280, 27);
            this.label1Emp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1Emp.Name = "label1";
            this.label1Emp.Size = new System.Drawing.Size(58, 17);
            this.label1Emp.TabIndex = 11;
            this.label1Emp.Text = "Nombre";
            // 
            // txtNombreEmp
            // 
            this.txtNombreEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreEmp.Location = new System.Drawing.Point(376, 23);
            this.txtNombreEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreEmp.Name = "txtNombreEmp";
            this.txtNombreEmp.Size = new System.Drawing.Size(189, 23);
            this.txtNombreEmp.TabIndex = 0;
            // 
            // txtCuit
            // 
            this.txtCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuit.Location = new System.Drawing.Point(376, 63);
            this.txtCuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(189, 23);
            this.txtCuit.TabIndex = 2;
            // 
            // txtRubro
            // 
            this.txtRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRubro.Location = new System.Drawing.Point(635, 43);
            this.txtRubro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(243, 23);
            this.txtRubro.TabIndex = 5;
            // 
            // label4Emp
            // 
            this.label4Emp.AutoSize = true;
            this.label4Emp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4Emp.Location = new System.Drawing.Point(585, 47);
            this.label4Emp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4Emp.Name = "label4Emp";
            this.label4Emp.Size = new System.Drawing.Size(31, 17);
            this.label4Emp.TabIndex = 20;
            this.label4Emp.Text = "Rubro";
            // 
            // groupBox2Emp
            // 
            this.groupBox2Emp.Controls.Add(this.dgvEmpresas);
            this.groupBox2Emp.Controls.Add(this.cmdLimpiarEmp);
            this.groupBox2Emp.Controls.Add(this.cmdMenu);
            this.groupBox2Emp.Controls.Add(this.cmdEditar);
            this.groupBox2Emp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2Emp.Location = new System.Drawing.Point(0, 176);
            this.groupBox2Emp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2Emp.Name = "groupBox2Emp";
            this.groupBox2Emp.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2Emp.Size = new System.Drawing.Size(1164, 500);
            this.groupBox2Emp.TabIndex = 27;
            this.groupBox2Emp.TabStop = false;
            this.groupBox2Emp.Text = "Resultados";
            // 
            // dgvEmpresas
            // 
            this.dgvEmpresas.AllowUserToAddRows = false;
            this.dgvEmpresas.AllowUserToDeleteRows = false;
            this.dgvEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEmpresas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Apellido,
            this.FechaNacimiento,
            this.Dni,
            this.Mail,
            this.Activo});
            this.dgvEmpresas.Location = new System.Drawing.Point(32, 23);
            this.dgvEmpresas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvEmpresas.MultiSelect = false;
            this.dgvEmpresas.Name = "dgvEmpresas";
            this.dgvEmpresas.ReadOnly = true;
            this.dgvEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpresas.Size = new System.Drawing.Size(1100, 314);
            this.dgvEmpresas.TabIndex = 34;
            this.dgvEmpresas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpresas_CellClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.HeaderText = "Nacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.ReadOnly = true;
            this.FechaNacimiento.Width = 101;
            // 
            // Dni
            // 
            this.Dni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Dni.HeaderText = "DNI";
            this.Dni.Name = "Dni";
            this.Dni.ReadOnly = true;
            // 
            // Mail
            // 
            this.Mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            this.Mail.Width = 58;
            // 
            // Activo
            // 
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            this.Activo.Width = 51;
            // 
            // cmdLimpiarEmp
            // 
            this.cmdLimpiarEmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdLimpiarEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLimpiarEmp.Location = new System.Drawing.Point(369, 345);
            this.cmdLimpiarEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdLimpiarEmp.Name = "cmdLimpiarEmp";
            this.cmdLimpiarEmp.Size = new System.Drawing.Size(208, 65);
            this.cmdLimpiarEmp.TabIndex = 31;
            this.cmdLimpiarEmp.Text = "Limpiar";
            this.cmdLimpiarEmp.UseVisualStyleBackColor = true;
            this.cmdLimpiarEmp.Click += new System.EventHandler(this.cmdLimpiarEmp_Click);
            // 
            // cmdMenu
            // 
            this.cmdMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.Location = new System.Drawing.Point(965, 439);
            this.cmdMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(167, 46);
            this.cmdMenu.TabIndex = 33;
            this.cmdMenu.Text = "Menu Principal";
            this.cmdMenu.UseVisualStyleBackColor = true;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
            // 
            // cmdEditar
            // 
            this.cmdEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditar.Location = new System.Drawing.Point(589, 345);
            this.cmdEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(208, 65);
            this.cmdEditar.TabIndex = 32;
            this.cmdEditar.UseVisualStyleBackColor = true;
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
            // 
            // ListarEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 676);
            this.Controls.Add(this.groupBox2Emp);
            this.Controls.Add(this.groupBox1Emp);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListarEmpresas";
            this.Text = "Empresas";
            this.groupBox1Emp.ResumeLayout(false);
            this.groupBox1Emp.PerformLayout();
            this.groupBox2Emp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1Emp;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label label2Emp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreEmp;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.TextBox txtRubro;
        private System.Windows.Forms.Label label4Emp;
        private System.Windows.Forms.GroupBox groupBox2Emp;
        private System.Windows.Forms.DataGridView dgvEmpresas;
        private System.Windows.Forms.Button cmdLimpiarEmp;
        private System.Windows.Forms.Button cmdMenu;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
    }
}