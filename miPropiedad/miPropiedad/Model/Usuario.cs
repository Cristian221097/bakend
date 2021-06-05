using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace miPropiedad.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            Propietario = new HashSet<Propietario>();
        }

        public string Email { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Propietario> Propietario { get; set; }
    }
}
