using miPropiedad.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace miPropiedad.interfaces
{
    public interface IFotoRepositorio
    {
        Task<IEnumerable<Foto>> GetFotos();
    }
}