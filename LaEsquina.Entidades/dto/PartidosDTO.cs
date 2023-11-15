using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades.dto
{
    public class PartidosDTO : ICloneable
    {
        public int IdPartidos { get; set; }

        public string NombreEquipo_A { get; set; }

        public string NombreEquipo_B{ get; set; }

        public string NombreCategoria { get; set; }

        public string Resultado { get; set; }

        public string NombreDeRondas { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
