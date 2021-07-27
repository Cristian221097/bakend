using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.Dtos
{
    public class PropiedadDtos
    {
        public int IdPropiedad { get; set; }
        public int IdPropietario { get; set; }
        public string Categoria { get; set; }
        public decimal? Precio { get; set; }
        public string Operacion { get; set; }
        public string Caracteristica { get; set; }
        public int? Banos { get; set; }
        public int? Habitaciones { get; set; }
        public string Direccion { get; set; }
        public string Sector { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Fotos { get; set; }
    }
}
