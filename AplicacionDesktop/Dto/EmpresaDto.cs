using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dto
{
    class EmpresaDto
    {
        public int id { get; set; }
        private string nombre { get; set; }
        private string cuit { get; set; }
        private int id_rubro { get; set; }
        private int id_dir { get; set; }
        private bool activa { get; set; }

        public EmpresaDto(int _id, string _nombre, string _cuit, int _id_rubro, int _id_dir, bool _activo)
        {
            id = _id;
            nombre = _nombre;
            cuit = _cuit;
            id_rubro = _id_rubro;
            id_dir = _id_dir;
            activa = _activo;
        }

        public EmpresaDto() { }

        public bool equals(EmpresaDto _empresa)
        {
            if (this.id == _empresa.id &&
                this.nombre == _empresa.nombre &&
                this.cuit == _empresa.cuit &&
                this.id_rubro == _empresa.id_rubro &&
                this.id_dir == _empresa.id_dir &&
                this.activa == _empresa.activa 
                ) return true;
            return false;
        }

    }
}
