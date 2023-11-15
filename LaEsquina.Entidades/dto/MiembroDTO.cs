using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades.dto
{
    public class MiembroDTO:ICloneable
    {
        public int IdMiembros { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreEquipos{ get; set; }

        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
