using miPropiedad.data;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace miPropiedad.Model
{
    public partial class Publicacion
    {
        public int IdPublicacion { get; set; }
        public int IdPropiedad { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }

        public virtual Propiedad IdPublicacionNavigation { get; set; }
    }
}
