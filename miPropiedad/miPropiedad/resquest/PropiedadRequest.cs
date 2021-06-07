using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.resquest
{
    public class PropiedadRequest
    {
        public int Id { get; set; }

        public int Id_propiedad { get; set; }

        public string Categoria { get; set; }

        public string Operacion { get; set; }

        public decimal Precio { get; set; }

        public string Caracteristica { get; set; }

        public int Baños { get; set; }

        public int Habitaciones { get; set; }

        public string Direccion { get; set; }

        public string Sector { get; set; }

        public string Ciudad { get; set; }

        public string Pais { get; set; }

        public byte[] Fotos { get; set; }
    }
}
