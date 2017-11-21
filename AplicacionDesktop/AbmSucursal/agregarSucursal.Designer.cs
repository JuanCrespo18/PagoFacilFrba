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
            this.label1 = new System.Windows.Forms.Label();
            this.nombreSucursal = new System.Windows.Forms.Label();
            this.dirSucursal = new System.Windows.Forms.Label();
            this.cpSucursal = new System.Windows.Forms.Label();
            this.pisoSucursal = new System.Windows.Forms.Label();
            this.dptoSucursal = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.GrupoDatos = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.GrupoDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECCIONE LA EMPRESA";
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
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(153, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 23);
            this.comboBox1.TabIndex = 6;
            // 
            // GrupoDatos
            // 
            this.GrupoDatos.Controls.Add(this.textBox5);
            this.GrupoDatos.Controls.Add(this.textBox4);
            this.GrupoDatos.Controls.Add(this.textBox3);
            this.GrupoDatos.Controls.Add(this.textBox2);
            this.GrupoDatos.Controls.Add(this.dptoSucursal);
            this.GrupoDatos.Controls.Add(this.textBox1);
            this.GrupoDatos.Controls.Add(this.pisoSucursal);
            this.GrupoDatos.Controls.Add(this.nombreSucursal);
            this.GrupoDatos.Controls.Add(this.cpSucursal);
            this.GrupoDatos.Controls.Add(this.dirSucursal);
            this.GrupoDatos.Location = new System.Drawing.Point(12, 93);
            this.GrupoDatos.Name = "GrupoDatos";
            this.GrupoDatos.Size = new System.Drawing.Size(533, 131);
            this.GrupoDatos.TabIndex = 7;
            this.GrupoDatos.TabStop = false;
            this.GrupoDatos.Text = "Datos Sucursal";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(127, 85);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(79, 20);
            this.textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(265, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(79, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(455, 85);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(400, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(400, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(309, 230);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 40);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(438, 230);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 40);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // agregarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 282);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.GrupoDatos);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "agregarSucursal";
            this.Text = "agregarSucursal";
            this.GrupoDatos.ResumeLayout(false);
            this.GrupoDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nombreSucursal;
        private System.Windows.Forms.Label dirSucursal;
        private System.Windows.Forms.Label cpSucursal;
        private System.Windows.Forms.Label pisoSucursal;
        private System.Windows.Forms.Label dptoSucursal;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox GrupoDatos;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
    }
}