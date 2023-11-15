using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades.dto
{
    public class TorneoDTO:ICloneable
    {
        public int IdTorneo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string NombreCategoria { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
