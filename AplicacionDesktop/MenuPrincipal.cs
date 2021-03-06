﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            desactivarBotones();
        }

        private void desactivarBotones()
        {
            SesionUsuario.user.cargarFuncionalidadesRol();

            if (!SesionUsuario.usuario.funcionalidades.Exists(f => f.Equals("Realizar Devoluciones")))
                cmdDevoluciones.Enabled = false;
            else
                cmdDevoluciones.Enabled = true;

            if (!SesionUsuario.usuario.funcionalidades.Exists(f => f.Equals("Rendir Factura")))
                cmdRendir.Enabled = false;
            else
                cmdRendir.Enabled = true;

            if (!SesionUsuario.usuario.funcionalidades.Exists(f => f.Equals("Cobrar Factura")))
                cmdRegistroPago.Enabled = false;
            else
                cmdRegistroPago.Enabled = true;

            if (!SesionUsuario.usuario.funcionalidades.Exists(f => f.Equals("Generar Estadisticas")))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void cmdRoles_Click_1(object sender, EventArgs e)
        {
            new AbmRol.ListarRoles(this).Show();
            this.Hide();
        }

        private void cmdClientes_Click(object sender, EventArgs e)
        {
            new AbmCliente.ListarClientes(this).Show();
            this.Hide();
        }

        private void cmdFacturas_Click(object sender, EventArgs e)
        {
            new AbmFactura.ListarFacturas(this).Show();
            this.Hide();
        }

        private void cmdPagarFacturas_Click(object sender, EventArgs e)
        {
            new RegistroPago.RegistroPago(this).Show();
            this.Hide();
        }

        private void cmdRendir_Click(object sender, EventArgs e)
        {
            new Rendicion.Rendicion(this).Show();
            this.Hide();
        }

        private void cmdDevoluciones_Click(object sender, EventArgs e)
        {
            new Devoluciones.Devoluciones(this).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ListadoEstadistico.MenuListadoEstadistico(this).Show();
            this.Hide();
        }

        private void cmdEmpresas_Click(object sender, EventArgs e)
        {
            new AbmEmpresa.MenuEmpresas(this).Show();
            this.Hide();
        }

        private void cmdSucursales_Click(object sender, EventArgs e)
        {
            new AbmSucursal.MenuSucursales(this).Show();
            this.Hide();
        }

        private void cmdRegistroPago_Click(object sender, EventArgs e)
        {
            new RegistroPago.RegistroPago(this).Show();
            this.Hide();
        }

        private void cmdRendir_Click_1(object sender, EventArgs e)
        {
            new Rendicion.Rendicion(this).Show();
            this.Hide();
        }

        private void cmdDevoluciones_Click_1(object sender, EventArgs e)
        {
            new Devoluciones.Devoluciones(this).Show();
            this.Hide();
        }

        private void cmdLogout_Click(object sender, EventArgs e)
        {
            new Login.Login().Show();
            SesionUsuario.usuario = null;
            this.Close();
        }

        private void MenuPrincipal_Activated(object sender, EventArgs e)
        {
            desactivarBotones();
        }
    }
}
