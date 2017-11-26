namespace PagoAgilFrba.AbmSucursal
{
    partial class agregarSucursal
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
            this.nombreSucursal = new System.Windows.Forms.Label();
            this.dirSucursal = new System.Windows.Forms.Label();
            this.cpSucursal = new System.Windows.Forms.Label();
            this.pisoSucursal = new System.Windows.Forms.Label();
            this.dptoSucursal = new System.Windows.Forms.Label();
            this.GrupoDatos = new System.Windows.Forms.GroupBox();
            this.campoLocalidad = new System.Windows.Forms.TextBox();
            this.localidad = new System.Windows.Forms.Label();
            this.codPostal = new System.Windows.Forms.TextBox();
            this.piso = new System.Windows.Forms.TextBox();
            this.departamento = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.direccion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GrupoDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // nombreSucursal
            // 
            this.nombreSucursal.AutoSize = true;
            this.nombreSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreSucursal.Location = new System.Drawing.Point(15, 26);
            this.nombreSucursal.Name = "nombreSucursal";
            this.nombreSucursal.Size = new System.Drawing.Size(65, 16);
            this.nombreSucursal.TabIndex = 1;
            this.nombreSucursal.Text = "Nombre *";
            // 
            // dirSucursal
            // 
            this.dirSucursal.AutoSize = true;
            this.dirSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dirSucursal.Location = new System.Drawing.Point(15, 56);
            this.dirSucursal.Name = "dirSucursal";
            this.dirSucursal.Size = new System.Drawing.Size(73, 16);
            this.dirSucursal.TabIndex = 2;
            this.dirSucursal.Text = "Direccion *";
            // 
            // cpSucursal
            // 
            this.cpSucursal.AutoSize = true;
            this.cpSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpSucursal.Location = new System.Drawing.Point(15, 88);
            this.cpSucursal.Name = "cpSucursal";
            this.cpSucursal.Size = new System.Drawing.Size(85, 16);
            this.cpSucursal.TabIndex = 3;
            this.cpSucursal.Text = "Cod. Postal *";
            // 
            // pisoSucursal
            // 
            this.pisoSucursal.AutoSize = true;
            this.pisoSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pisoSucursal.Location = new System.Drawing.Point(224, 88);
            this.pisoSucursal.Name = "pisoSucursal";
            this.pisoSucursal.Size = new System.Drawing.Size(35, 16);
            this.pisoSucursal.TabIndex = 4;
            this.pisoSucursal.Text = "Piso";
            // 
            // dptoSucursal
            // 
            this.dptoSucursal.AutoSize = true;
            this.dptoSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptoSucursal.Location = new System.Drawing.Point(357, 88);
            this.dptoSucursal.Name = "dptoSucursal";
            this.dptoSucursal.Size = new System.Drawing.Size(94, 16);
            this.dptoSucursal.TabIndex = 5;
            this.dptoSucursal.Text = "Departamento";
            // 
            // GrupoDatos
            // 
            this.GrupoDatos.Controls.Add(this.campoLocalidad);
            this.GrupoDatos.Controls.Add(this.localidad);
            this.GrupoDatos.Controls.Add(this.codPostal);
            this.GrupoDatos.Controls.Add(this.piso);
            this.GrupoDatos.Controls.Add(this.departamento);
            this.GrupoDatos.Controls.Add(this.nombre);
            this.GrupoDatos.Controls.Add(this.dptoSucursal);
            this.GrupoDatos.Controls.Add(this.direccion);
            this.GrupoDatos.Controls.Add(this.pisoSucursal);
            this.GrupoDatos.Controls.Add(this.nombreSucursal);
            this.GrupoDatos.Controls.Add(this.cpSucursal);
            this.GrupoDatos.Controls.Add(this.dirSucursal);
            this.GrupoDatos.Location = new System.Drawing.Point(12, 12);
            this.GrupoDatos.Name = "GrupoDatos";
            this.GrupoDatos.Size = new System.Drawing.Size(533, 158);
            this.GrupoDatos.TabIndex = 7;
            this.GrupoDatos.TabStop = false;
            this.GrupoDatos.Text = "Datos Sucursal";
            // 
            // campoLocalidad
            // 
            this.campoLocalidad.Location = new System.Drawing.Point(127, 118);
            this.campoLocalidad.Name = "campoLocalidad";
            this.campoLocalidad.Size = new System.Drawing.Size(400, 20);
            this.campoLocalidad.TabIndex = 7;
            this.campoLocalidad.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // localidad
            // 
            this.localidad.AutoSize = true;
            this.localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.localidad.Location = new System.Drawing.Point(15, 121);
            this.localidad.Name = "localidad";
            this.localidad.Size = new System.Drawing.Size(76, 16);
            this.localidad.TabIndex = 6;
            this.localidad.Text = "Localidad *";
            // 
            // codPostal
            // 
            this.codPostal.Location = new System.Drawing.Point(127, 85);
            this.codPostal.Name = "codPostal";
            this.codPostal.Size = new System.Drawing.Size(79, 20);
            this.codPostal.TabIndex = 4;
            // 
            // piso
            // 
            this.piso.Location = new System.Drawing.Point(265, 85);
            this.piso.Name = "piso";
            this.piso.Size = new System.Drawing.Size(79, 20);
            this.piso.TabIndex = 3;
            // 
            // departamento
            // 
            this.departamento.Location = new System.Drawing.Point(455, 85);
            this.departamento.Name = "departamento";
            this.departamento.Size = new System.Drawing.Size(72, 20);
            this.departamento.TabIndex = 2;
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
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(315, 176);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 40);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(432, 176);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 40);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Campos obligatorios ( * )";
            // 
            // agregarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 228);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.GrupoDatos);
            this.Name = "agregarSucursal";
            this.Text = "agregarSucursal";
            this.GrupoDatos.ResumeLayout(false);
            this.GrupoDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nombreSucursal;
        private System.Windows.Forms.Label dirSucursal;
        private System.Windows.Forms.Label cpSucursal;
        private System.Windows.Forms.Label pisoSucursal;
        private System.Windows.Forms.Label dptoSucursal;
        private System.Windows.Forms.GroupBox GrupoDatos;
        private System.Windows.Forms.TextBox codPostal;
        private System.Windows.Forms.TextBox piso;
        private System.Windows.Forms.TextBox departamento;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox campoLocalidad;
        private System.Windows.Forms.Label localidad;
    }
}