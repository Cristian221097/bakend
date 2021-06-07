using Microsoft.EntityFrameworkCore;
using miPropiedad.data;
using miPropiedad.interfaces;
using miPropiedad.resquest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.Repositorio
{
    public class PropiedadRepositorio : IPropiedadRepositorio
    {
        
        private readonly miPropiedadContext _db;
        public PropiedadRepositorio(miPropiedadContext db)
        {
            _db = db;
           
        }

      

        public  async  Task InsertarPropiedad(Propiedad model)
        {
 
           _db.Propiedad.Add(model);
           await _db.SaveChangesAsync();

        }

        public async Task<IEnumerable<Propiedad>> GetPropiedades()
        {
            var propiedades = await  _db.Propiedad.OrderByDescending(x => x.IdPropiedad).ToListAsync();
            return propiedades;

        }
    }
}
