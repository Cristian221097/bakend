using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.resquest
{
    public class Repuesta
    {
        public string Mensaje { get; set; }

        public int Exito { get; set; }

        public object Data { get; set; }
    }
}
