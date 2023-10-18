using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Equipos : ICloneable
    {

        public int IdEquipos { get; set; }

        public string NombreEquipos { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
