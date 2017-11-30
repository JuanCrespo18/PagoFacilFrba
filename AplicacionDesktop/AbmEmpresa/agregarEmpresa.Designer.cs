
namespace PagoAgilFrba.AbmEmpresa
{
    partial class agregarEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
      

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 

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
            this.datosEmpresa = new System.Windows.Forms.GroupBox();
            this.activa = new System.Windows.Forms.CheckBox();
            this.diaRendicion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rubro = new System.Windows.Forms.ComboBox();
            this.razonSocial = new System.Windows.Forms.TextBox();
            this.cuit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.departamento = new System.Windows.Forms.TextBox();
            this.piso = new System.Windows.Forms.TextBox();
            this.codPostal = new System.Windows.Forms.TextBox();
            this.localidad = new System.Windows.Forms.TextBox();
            this.direccion = new System.Windows.Forms.TextBox();
            this.bntAgregar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dirEmpresa = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.datosEmpresa.SuspendLayout();
            this.dirEmpresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // datosEmpresa
            // 
            this.datosEmpresa.Controls.Add(this.activa);
            this.datosEmpresa.Controls.Add(this.diaRendicion);
            this.datosEmpresa.Controls.Add(this.label10);
            this.datosEmpresa.Controls.Add(this.rubro);
            this.datosEmpresa.Controls.Add(this.razonSocial);
            this.datosEmpresa.Controls.Add(this.cuit);
            this.datosEmpresa.Controls.Add(this.label3);
            this.datosEmpresa.Controls.Add(this.label2);
            this.datosEmpresa.Controls.Add(this.label1);
            this.datosEmpresa.Location = new System.Drawing.Point(12, 12);
            this.datosEmpresa.Name = "datosEmpresa";
            this.datosEmpresa.Size = new System.Drawing.Size(442, 207);
            this.datosEmpresa.TabIndex = 0;
            this.datosEmpresa.TabStop = false;
            this.datosEmpresa.Text = "Datos Empresa";
            // 
            // activa
            // 
            this.activa.AutoSize = true;
            this.activa.Location = new System.Drawing.Point(198, 158);
            this.activa.Name = "activa";
            this.activa.Size = new System.Drawing.Size(73, 17);
            this.activa.TabIndex = 14;
            this.activa.Text = "Habilitada";
            this.activa.UseVisualStyleBackColor = true;
            // 
            // diaRendicion
            // 
            this.diaRendicion.Location = new System.Drawing.Point(119, 110);
            this.diaRendicion.Name = "diaRendicion";
            this.diaRendicion.Size = new System.Drawing.Size(317, 20);
            this.diaRendicion.TabIndex = 13;
            this.diaRendicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.diaRendicion_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label10.Location = new System.Drawing.Point(19, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Dia Rendicion *";
            // 
            // rubro
            // 
            this.rubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rubro.FormattingEnabled = true;
            this.rubro.Location = new System.Drawing.Point(119, 83);
            this.rubro.Name = "rubro";
            this.rubro.Size = new System.Drawing.Size(317, 21);
            this.rubro.TabIndex = 11;
            // 
            // razonSocial
            // 
            this.razonSocial.Location = new System.Drawing.Point(119, 26);
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.Size = new System.Drawing.Size(317, 20);
            this.razonSocial.TabIndex = 10;
            // 
            // cuit
            // 
            this.cuit.Location = new System.Drawing.Point(119, 55);
            this.cuit.Name = "cuit";
            this.cuit.Size = new System.Drawing.Size(317, 20);
            this.cuit.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.Location = new System.Drawing.Point(19, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rubro *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "CUIT *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon Social *";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.Location = new System.Drawing.Point(19, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Direccion *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.Location = new System.Drawing.Point(19, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Localidad *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label6.Location = new System.Drawing.Point(19, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "CP *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label7.Location = new System.Drawing.Point(155, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Piso";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label8.Location = new System.Drawing.Point(278, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Departamento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Campos Obligatorios (*)";
            // 
            // departamento
            // 
            this.departamento.Location = new System.Drawing.Point(380, 89);
            this.departamento.Name = "departamento";
            this.departamento.Size = new System.Drawing.Size(56, 20);
            this.departamento.TabIndex = 11;
            // 
            // piso
            // 
            this.piso.Location = new System.Drawing.Point(198, 89);
            this.piso.Name = "piso";
            this.piso.Size = new System.Drawing.Size(69, 20);
            this.piso.TabIndex = 12;
            // 
            // codPostal
            // 
            this.codPostal.Location = new System.Drawing.Point(65, 89);
            this.codPostal.Name = "codPostal";
            this.codPostal.Size = new System.Drawing.Size(81, 20);
            this.codPostal.TabIndex = 13;
            // 
            // localidad
            // 
            this.localidad.Location = new System.Drawing.Point(119, 59);
            this.localidad.Name = "localidad";
            this.localidad.Size = new System.Drawing.Size(317, 20);
            this.localidad.TabIndex = 14;
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(119, 28);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(317, 20);
            this.direccion.TabIndex = 15;
            // 
            // bntAgregar
            // 
            this.bntAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.bntAgregar.Location = new System.Drawing.Point(354, 392);
            this.bntAgregar.Name = "bntAgregar";
            this.bntAgregar.Size = new System.Drawing.Size(100, 37);
            this.bntAgregar.TabIndex = 16;
            this.bntAgregar.Text = "Agregar";
            this.bntAgregar.UseVisualStyleBackColor = true;
            this.bntAgregar.Click += new System.EventHandler(this.bntAgregar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnLimpiar.Location = new System.Drawing.Point(247, 392);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 37);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dirEmpresa
            // 
            this.dirEmpresa.Controls.Add(this.departamento);
            this.dirEmpresa.Controls.Add(this.piso);
            this.dirEmpresa.Controls.Add(this.label5);
            this.dirEmpresa.Controls.Add(this.label4);
            this.dirEmpresa.Controls.Add(this.label6);
            this.dirEmpresa.Controls.Add(this.label7);
            this.dirEmpresa.Controls.Add(this.label8);
            this.dirEmpresa.Controls.Add(this.codPostal);
            this.dirEmpresa.Controls.Add(this.localidad);
            this.dirEmpresa.Controls.Add(this.direccion);
            this.dirEmpresa.Location = new System.Drawing.Point(12, 225);
            this.dirEmpresa.Name = "dirEmpresa";
            this.dirEmpresa.Size = new System.Drawing.Size(442, 139);
            this.dirEmpresa.TabIndex = 19;
            this.dirEmpresa.TabStop = false;
            this.dirEmpresa.Text = "Datos de Contacto";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnCancelar.Location = new System.Drawing.Point(12, 392);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 37);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // agregarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 443);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.bntAgregar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dirEmpresa);
            this.Controls.Add(this.datosEmpresa);
            this.Controls.Add(this.label9);
            this.Name = "agregarEmpresa";
            this.Text = "agregarEmpresa";
            this.datosEmpresa.ResumeLayout(false);
            this.datosEmpresa.PerformLayout();
            this.dirEmpresa.ResumeLayout(false);
            this.dirEmpresa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


      
        private System.Windows.Forms.GroupBox datosEmpresa;
        private System.Windows.Forms.ComboBox rubro;
        private System.Windows.Forms.TextBox razonSocial;
        private System.Windows.Forms.TextBox cuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox departamento;
        private System.Windows.Forms.TextBox piso;
        private System.Windows.Forms.TextBox codPostal;
        private System.Windows.Forms.TextBox localidad;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Button bntAgregar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox dirEmpresa;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox activa;
        private System.Windows.Forms.TextBox diaRendicion;
        private System.Windows.Forms.Label label10;
    }
}