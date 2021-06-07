using miPropiedad.data;
using miPropiedad.resquest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace miPropiedad.interfaces
{
    public interface IPropiedadRepositorio
    {
        Task InsertarPropiedad(Propiedad model);

        Task<IEnumerable<Propiedad>> GetPropiedades();
    }
}