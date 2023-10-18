using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LaEsquina.Entidades
{
    public class Turno : ICloneable
    {
        public int IdTurnos { get; set; }

        public TimeSpan Horario { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
