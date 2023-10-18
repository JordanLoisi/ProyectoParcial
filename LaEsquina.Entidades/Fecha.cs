using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Fecha : ICloneable
    {
        public int IdFechas { get; set; }

        public DateTime Dia { get; set; }

        public bool Torneo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
