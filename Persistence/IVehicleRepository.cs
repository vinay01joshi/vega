using System.Threading.Tasks;
using vega.Models;

namespace vega.Persistence
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id, bool incluedeRelated = true);

         void Add(Vehicle vehicle) ;

         void Remove(Vehicle vehicle);
    }
}