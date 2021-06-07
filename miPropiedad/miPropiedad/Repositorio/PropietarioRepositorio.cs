using miPropiedad.data;
using miPropiedad.interfaces;
using miPropiedad.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.Repositorio
{
    public class PropietarioRepositorio : IPropietarioRepositorio
    {
        private readonly miPropiedadContext _db;
        public PropietarioRepositorio(miPropiedadContext db)
        {
            _db = db;
        }

        public async Task InsertarPropietario(Propietario model)
        {
             _db.Propietario.Add(model);
           await _db.SaveChangesAsync();
        }
    }
}
