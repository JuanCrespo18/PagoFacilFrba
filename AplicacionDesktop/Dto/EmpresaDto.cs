using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dto
{
    public class EmpresaDto
    {
        public int id { get; set; }
        private string razon_social { get; set; }
        private string cuit { get; set; }
        private string rubro { get; set; }
        private string direccion { get; set; }
        private string localidad { get; set; }
        private string cp { get; set; }
        private string piso { get; set; }
        private string depto { get; set; }
        public bool activa { get; set; }
        public string diaRendicion { get; set; }

        public EmpresaDto(int _id, string _razon_social, string _cuit, string _rubro, string _direccion, string _localidad, string _cp, string _piso, string _depto, bool _activo, string _diaRendicion)
        {
            id = _id;
            razon_social = _razon_social;
            cuit = _cuit;
            rubro = _rubro;
            direccion = _direccion;
            localidad = _localidad;
            cp = _cp;
            piso = _piso;
            depto = _depto;
            activa = _activo;
            diaRendicion = _diaRendicion;
        }

        public EmpresaDto() { }

        public bool equals(EmpresaDto _empresa)
        {
            if (this.id == _empresa.id &&
                this.razon_social == _empresa.razon_social &&
                this.cuit == _empresa.cuit &&
                this.rubro == _empresa.rubro &&
                this.direccion == _empresa.direccion &&
                this.localidad == _empresa.localidad &&
                this.cp == _empresa.cp &&
                this.piso == _empresa.piso &&
                this.depto == _empresa.depto &&
                this.activa == _empresa.activa &&
                this.diaRendicion == _empresa.diaRendicion
                ) return true;
            return false;
        }

    }
}
