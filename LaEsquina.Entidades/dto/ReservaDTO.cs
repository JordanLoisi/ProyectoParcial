using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades.dto
{
    public class ReservaDTO : ICloneable
    {
        public int IdReservas { get; set; }
        public TimeSpan Horario { get; set; }
        public int NombreCancha { get; set; }
        public string NombreMiembro { get; set; }
        public string Apellido { get; set; }
        public DateTime Dia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
