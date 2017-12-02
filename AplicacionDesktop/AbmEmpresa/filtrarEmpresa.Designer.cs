using PagoAgilFrba.Dto;
using System.Collections.Generic;

namespace PagoAgilFrba.AbmEmpresa
{
    partial class filtrarEmpresa
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
            this.filtros = new System.Windows.Forms.GroupBox();
            this.rubro = new System.Windows.Forms.ComboBox();
            this.razonSocial = new System.Windows.Forms.TextBox();
            this.cuit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.listaEmpresas = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaEmpresas)).BeginInit();
            this.SuspendLayout();
            
            // 
            // filtros
            // 
            this.filtros.Controls.Add(this.rubro);
            this.filtros.Controls.Add(this.razonSocial);
            this.filtros.Controls.Add(this.cuit);
            this.filtros.Controls.Add(this.label3);
            this.filtros.Controls.Add(this.label2);
            this.filtros.Controls.Add(this.label1);
            this.filtros.Location = new System.Drawing.Point(12, 12);
            this.filtros.Name = "filtros";
            this.filtros.Size = new System.Drawing.Size(442, 119);
            this.filtros.TabIndex = 2;
            this.filtros.TabStop = false;
            this.filtros.Text = "Filtrar Por";
            // 
            // rubro
            // 
            this.rubro.FormattingEnabled = true;
            this.rubro.Location = new System.Drawing.Point(119, 83);
            this.rubro.Name = "rubro";
            this.rubro.Size = new System.Drawing.Size(317, 21);
            this.rubro.TabIndex = 11;
            this.rubro.SelectedIndexChanged += new System.EventHandler(this.rubro_SelectedIndexChanged);
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
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rubro ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "CUIT ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razos Social ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 137);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 30);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(355, 137);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(99, 30);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // listaEmpresas
            // 
            this.listaEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaEmpresas.Location = new System.Drawing.Point(12, 173);
            this.listaEmpresas.Name = "listaEmpresas";
            this.listaEmpresas.Size = new System.Drawing.Size(442, 198);
            this.listaEmpresas.TabIndex = 14;
            this.listaEmpresas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaEmpresa_celda_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(355, 377);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 34);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // filtrarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 418);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.listaEmpresas);
            this.Controls.Add(this.filtros);
            this.Name = "filtrarEmpresa";
            this.Text = "filtrarEmpresa";
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaEmpresas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filtros;
        private System.Windows.Forms.ComboBox rubro;
        private System.Windows.Forms.TextBox razonSocial;
        private System.Windows.Forms.TextBox cuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView listaEmpresas;
        private System.Windows.Forms.Button btnCancelar;
    }
}