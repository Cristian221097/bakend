using miPropiedad.Model;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace miPropiedad.data
{
    public partial class Propiedad
    {
        public int IdPropiedad { get; set; }
        public int IdPropietario { get; set; }
        public string Categoria { get; set; }
        public decimal? Precio { get; set; }
        public string Operacion { get; set; }
        public string Caracteristica { get; set; }
        public int? Baños { get; set; }
        public int? Habitaciones { get; set; }
        public string Direccion { get; set; }
        public string Sector { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public byte[] Fotos { get; set; }

        public virtual Propietario IdPropietarioNavigation { get; set; }
        public virtual Publicacion Publicacion { get; set; }
    }
}
