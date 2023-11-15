using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Reserva : ICloneable
    {
        public int IdReserva { get; set; }

        public int IdTurnos { get; set; }
        public int IdCanchas { get; set; }
        public int IdMiembros { get; set; }
        public int IdFechas { get; set; }

        public Fecha fecha { get; set; }
        public Turno turno { get; set; }
        public Canchas canchas { get; set; }
        public Miembro miembro { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
