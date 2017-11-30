using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dto
{
    class SucursalDto
    {
        private int id { get; set; }
        private String nombre { get; set; }
        private String direccion { get; set; }
        public String cp { get; set; }
        private String piso { get; set; }
        private String departamento { get; set; }
        private String localidad { get; set; }
        private Boolean activa { get; set; }

        public SucursalDto(int _id,String _nombre, String _direccion, String _cp, String _piso, String _departamento,String _localidad, Boolean _activa)
        {
            id = _id;
            nombre = _nombre;
            direccion = _direccion;
            cp = _cp;
            piso = _piso;
            departamento = _departamento;
            localidad = _localidad;
            activa = _activa;
        }

        public SucursalDto() { }

        public bool equals(SucursalDto _sucursal) {
            if (this.id == _sucursal.id &&
                this.nombre == _sucursal.nombre &&
                this.direccion == _sucursal.direccion &&
                this.cp == _sucursal.cp &&
                this.piso == _sucursal.piso &&
                this.departamento == _sucursal.departamento &&
                this.localidad == _sucursal.localidad &&
                this.activa == _sucursal.activa
                ) return true;
            return false;
        }
    }
}
