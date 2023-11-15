using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Partidos :ICloneable
    {
        public int IdPartidos { get; set; }

        public int IdEquipo_A { get; set; }

        public int  IdEquipo_B { get; set; }

        public int IdTorneo { get; set; }

        public string Resultado { get; set; }

        public int IdRondas { get; set; }

        public Equipos equipos { get; set; }
        public Torneo torneo { get; set; }
        public Rondas rondas { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
