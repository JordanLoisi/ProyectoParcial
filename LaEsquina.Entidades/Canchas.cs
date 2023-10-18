﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.Entidades
{
    public class Canchas : ICloneable
    {
        public int IdCanchas { get; set; }

        public int Nombre { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
