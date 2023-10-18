using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Categorias:ICloneable
    {
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
