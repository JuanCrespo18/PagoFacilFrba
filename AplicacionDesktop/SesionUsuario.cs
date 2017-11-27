using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba
{
    class SesionUsuario
    {
        public static SesionUsuario usuario;
        public int id { get; set; }
        public String rol { get; set; }
        public String username { get; set; }
        
        public static SesionUsuario user
        {get{
                if (usuario == null){ usuario = new SesionUsuario();}
                return usuario;
            }
        }

        private SesionUsuario() { }
    }
}
