using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Cuotas : ICloneable
    {
        public int IdCuotas { get; set; }
        public string Mes { get; set; }

        public decimal Monto { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
