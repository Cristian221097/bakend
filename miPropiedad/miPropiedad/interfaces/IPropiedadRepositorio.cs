using Microsoft.AspNetCore.Http;
using miPropiedad.data;
using miPropiedad.Dtos;
using miPropiedad.Model;
using miPropiedad.resquest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace miPropiedad.interfaces
{
    public interface IPropiedadRepositorio
    {
        Task InsertarPropiedad(Propiedad model , List<IFormFile> fotos);

        Task<IEnumerable<Propiedad>> GetPropiedades();

        Task UpdatePropiedad(Propiedad propiedad, List<IFormFile> fotos);

        Task DeletePropiedad(int id);


        Task<Propiedad> GetByidPropiedad(int idPropiedad);
    }
}