namespace PagoAgilFrba.AbmSucursal
{
    partial class filtrarSucursal
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
            this.GrupoFiltros = new System.Windows.Forms.GroupBox();
            this.codPostal = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.direccion = new System.Windows.Forms.TextBox();
            this.nombreSucursal = new System.Windows.Forms.Label();
            this.cpSucursal = new System.Windows.Forms.Label();
            this.dirSucursal = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.bntBuscar = new System.Windows.Forms.Button();
            this.listaSucursales = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GrupoFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // GrupoFiltros
            // 
            this.GrupoFiltros.Controls.Add(this.codPostal);
            this.GrupoFiltros.Controls.Add(this.nombre);
            this.GrupoFiltros.Controls.Add(this.direccion);
            this.GrupoFiltros.Controls.Add(this.nombreSucursal);
            this.GrupoFiltros.Controls.Add(this.cpSucursal);
            this.GrupoFiltros.Controls.Add(this.dirSucursal);
            this.GrupoFiltros.Location = new System.Drawing.Point(12, 12);
            this.GrupoFiltros.Name = "GrupoFiltros";
            this.GrupoFiltros.Size = new System.Drawing.Size(533, 131);
            this.GrupoFiltros.TabIndex = 8;
            this.GrupoFiltros.TabStop = false;
            this.GrupoFiltros.Text = "Filtro Sucursales";
            // 
            // codPostal
            // 
            this.codPostal.Location = new System.Drawing.Point(127, 85);
            this.codPostal.Name = "codPostal";
            this.codPostal.Size = new System.Drawing.Size(79, 20);
            this.codPostal.TabIndex = 4;
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(127, 23);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(400, 20);
            this.nombre.TabIndex = 1;
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(127, 53);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(400, 20);
            this.direccion.TabIndex = 0;
            // 
            // nombreSucursal
            // 
            this.nombreSucursal.AutoSize = true;
            this.nombreSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreSucursal.Location = new System.Drawing.Point(15, 26);
            this.nombreSucursal.Name = "nombreSucursal";
            this.nombreSucursal.Size = new System.Drawing.Size(57, 16);
            this.nombreSucursal.TabIndex = 1;
            this.nombreSucursal.Text = "Nombre";
            // 
            // cpSucursal
            // 
            this.cpSucursal.AutoSize = true;
            this.cpSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpSucursal.Location = new System.Drawing.Point(15, 88);
            this.cpSucursal.Name = "cpSucursal";
            this.cpSucursal.Size = new System.Drawing.Size(77, 16);
            this.cpSucursal.TabIndex = 3;
            this.cpSucursal.Text = "Cod. Postal";
            // 
            // dirSucursal
            // 
            this.dirSucursal.AutoSize = true;
            this.dirSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dirSucursal.Location = new System.Drawing.Point(15, 56);
            this.dirSucursal.Name = "dirSucursal";
            this.dirSucursal.Size = new System.Drawing.Size(65, 16);
            this.dirSucursal.TabIndex = 2;
            this.dirSucursal.Text = "Direccion";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(308, 149);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(99, 40);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // bntBuscar
            // 
            this.bntBuscar.Location = new System.Drawing.Point(445, 149);
            this.bntBuscar.Name = "bntBuscar";
            this.bntBuscar.Size = new System.Drawing.Size(100, 40);
            this.bntBuscar.TabIndex = 10;
            this.bntBuscar.Text = "Buscar";
            this.bntBuscar.UseVisualStyleBackColor = true;
            this.bntBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // listaSucursales
            // 
            this.listaSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaSucursales.Location = new System.Drawing.Point(12, 205);
            this.listaSucursales.Name = "listaSucursales";
            this.listaSucursales.Size = new System.Drawing.Size(533, 202);
            this.listaSucursales.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(417, 413);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 32);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sucursales";
            // 
            // filtrarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 449);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.listaSucursales);
            this.Controls.Add(this.bntBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.GrupoFiltros);
            this.Name = "filtrarSucursal";
            this.Text = "filtrarSucursal";
            this.GrupoFiltros.ResumeLayout(false);
            this.GrupoFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaSucursales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrupoFiltros;
        private System.Windows.Forms.TextBox codPostal;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label nombreSucursal;
        private System.Windows.Forms.Label cpSucursal;
        private System.Windows.Forms.Label dirSucursal;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button bntBuscar;
        private System.Windows.Forms.DataGridView listaSucursales;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
    }
}