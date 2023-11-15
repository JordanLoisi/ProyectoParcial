using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Miembro : ICloneable
    {

        public int IdMiembros { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int IdEquipos { get; set; }

        public Equipos Equipos { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
