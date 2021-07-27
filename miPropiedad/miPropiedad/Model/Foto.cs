using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace miPropiedad.Model
{
    public partial class Foto
    {
        public int IdPropiedad { get; set; }
        public string Imagen { get; set; }
        public int Id { get; set; }

        public virtual Propiedad IdPropiedadNavigation { get; set; }
    }
}
