using Microsoft.EntityFrameworkCore;
using miPropiedad.data;
using miPropiedad.interfaces;
using miPropiedad.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.Repositorio
{
    public class FotoRepositorio : IFotoRepositorio
    {
        private readonly miPropiedadContext _db;
        public FotoRepositorio(miPropiedadContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Foto>> GetFotos()
        {
            var fotos = await _db.Foto.OrderByDescending(x => x.Id).ToListAsync();
            return fotos;
        }
    }
}
