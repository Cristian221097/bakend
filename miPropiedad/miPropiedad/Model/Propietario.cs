using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace miPropiedad.Model
{
    public partial class Propietario
    {
        public Propietario()
        {
            Propiedad = new HashSet<Propiedad>();
        }

        public int IdPropietario { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }

        public virtual Usuario EmailNavigation { get; set; }
        public virtual ICollection<Propiedad> Propiedad { get; set; }
    }
}
