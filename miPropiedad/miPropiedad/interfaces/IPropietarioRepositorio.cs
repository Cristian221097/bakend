using miPropiedad.Model;
using System.Threading.Tasks;

namespace miPropiedad.interfaces
{
    public interface IPropietarioRepositorio
    {
         Task InsertarPropietario(Propietario model);

    }
}