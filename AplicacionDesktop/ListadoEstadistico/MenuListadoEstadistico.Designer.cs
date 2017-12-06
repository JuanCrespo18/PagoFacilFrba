namespace PagoAgilFrba.ListadoEstadistico
{
    partial class MenuListadoEstadistico
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Anio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.list_Reporte = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMenuPral = new System.Windows.Forms.Button();
            this.textBox_Trimestre = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(30, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(30, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trimestre";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_Anio
            // 
            this.textBox_Anio.Location = new System.Drawing.Point(130, 87);
            this.textBox_Anio.Name = "textBox_Anio";
            this.textBox_Anio.Size = new System.Drawing.Size(100, 20);
            this.textBox_Anio.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(30, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Reporte";
            // 
            // list_Reporte
            // 
            this.list_Reporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.list_Reporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_Reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Reporte.FormattingEnabled = true;
            this.list_Reporte.Items.AddRange(new object[] {
            "Porcentaje de facturas cobradas por empresa",
            "Empresas con mayor monto rendido",
            "Clientes con mas pagos",
            "Clientes con mayor porcentaje de facturas pagadas (clientes cumplidores)"});
            this.list_Reporte.Location = new System.Drawing.Point(130, 162);
            this.list_Reporte.Name = "list_Reporte";
            this.list_Reporte.Size = new System.Drawing.Size(568, 24);
            this.list_Reporte.TabIndex = 6;
            this.list_Reporte.SelectedIndexChanged += new System.EventHandler(this.cboRoles_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(308, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ejecutar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "Listado Estadistico";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnMenuPral
            // 
            this.btnMenuPral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnMenuPral.Location = new System.Drawing.Point(574, 205);
            this.btnMenuPral.Name = "btnMenuPral";
            this.btnMenuPral.Size = new System.Drawing.Size(124, 42);
            this.btnMenuPral.TabIndex = 9;
            this.btnMenuPral.Text = "Menu Principal";
            this.btnMenuPral.UseVisualStyleBackColor = true;
            this.btnMenuPral.Click += new System.EventHandler(this.btnMenuPral_Click);
            // 
            // textBox_Trimestre
            // 
            this.textBox_Trimestre.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_Trimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBox_Trimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Trimestre.FormattingEnabled = true;
            this.textBox_Trimestre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.textBox_Trimestre.Location = new System.Drawing.Point(130, 119);
            this.textBox_Trimestre.Name = "textBox_Trimestre";
            this.textBox_Trimestre.Size = new System.Drawing.Size(77, 24);
            this.textBox_Trimestre.TabIndex = 11;
            // 
            // MenuListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 264);
            this.Controls.Add(this.textBox_Trimestre);
            this.Controls.Add(this.btnMenuPral);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.list_Reporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Anio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MenuListadoEstadistico";
            this.Text = "Menu Listado Estadistico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Anio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox list_Reporte;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMenuPral;
        private System.Windows.Forms.ComboBox textBox_Trimestre;
    }
}