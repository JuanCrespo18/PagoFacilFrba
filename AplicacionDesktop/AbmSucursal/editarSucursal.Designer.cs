namespace PagoAgilFrba.AbmSucursal
{
    partial class editarSucursal
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.bntCancelar = new System.Windows.Forms.Button();
            this.checkHabilitado = new System.Windows.Forms.CheckBox();
            this.GrupoDatos = new System.Windows.Forms.GroupBox();
            this.codPostal = new System.Windows.Forms.TextBox();
            this.piso = new System.Windows.Forms.TextBox();
            this.departamento = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.dptoSucursal = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.pisoSucursal = new System.Windows.Forms.Label();
            this.nombreSucursal = new System.Windows.Forms.Label();
            this.cpSucursal = new System.Windows.Forms.Label();
            this.dirSucursal = new System.Windows.Forms.Label();
            this.localidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrupoDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnAceptar.Location = new System.Drawing.Point(445, 187);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 33);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // bntCancelar
            // 
            this.bntCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCancelar.Location = new System.Drawing.Point(306, 187);
            this.bntCancelar.Name = "bntCancelar";
            this.bntCancelar.Size = new System.Drawing.Size(104, 33);
            this.bntCancelar.TabIndex = 6;
            this.bntCancelar.Text = "Cancelar";
            this.bntCancelar.UseVisualStyleBackColor = true;
            this.bntCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // checkHabilitado
            // 
            this.checkHabilitado.AutoSize = true;
            this.checkHabilitado.Location = new System.Drawing.Point(13, 172);
            this.checkHabilitado.Name = "checkHabilitado";
            this.checkHabilitado.Size = new System.Drawing.Size(71, 17);
            this.checkHabilitado.TabIndex = 7;
            this.checkHabilitado.Text = "habilitado";
            this.checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // GrupoDatos
            // 
            this.GrupoDatos.Controls.Add(this.label1);
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
            this.GrupoDatos.Size = new System.Drawing.Size(533, 154);
            this.GrupoDatos.TabIndex = 8;
            this.GrupoDatos.TabStop = false;
            this.GrupoDatos.Text = "Datos Sucursal";
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
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(127, 53);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(400, 20);
            this.direccion.TabIndex = 0;
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
            // localidad
            // 
            this.localidad.Location = new System.Drawing.Point(127, 117);
            this.localidad.Name = "localidad";
            this.localidad.Size = new System.Drawing.Size(400, 20);
            this.localidad.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Localidad";
            // 
            // editarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 232);
            this.Controls.Add(this.GrupoDatos);
            this.Controls.Add(this.checkHabilitado);
            this.Controls.Add(this.bntCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "editarSucursal";
            this.Text = "editarSucursal";
            this.GrupoDatos.ResumeLayout(false);
            this.GrupoDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button bntCancelar;
        private System.Windows.Forms.CheckBox checkHabilitado;
        private System.Windows.Forms.GroupBox GrupoDatos;
        private System.Windows.Forms.TextBox codPostal;
        private System.Windows.Forms.TextBox piso;
        private System.Windows.Forms.TextBox departamento;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label dptoSucursal;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label pisoSucursal;
        private System.Windows.Forms.Label nombreSucursal;
        private System.Windows.Forms.Label cpSucursal;
        private System.Windows.Forms.Label dirSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox localidad;
    }
}