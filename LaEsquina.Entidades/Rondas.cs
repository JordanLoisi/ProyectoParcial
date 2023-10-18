using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Rondas:ICloneable
    {
        public int IdRondas { get; set; }

        public string NombreDeRondas { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
