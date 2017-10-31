using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IVehicleRepository
    {
        Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery filter);
         Task<Vehicle> GetVehicle(int id, bool incluedeRelated = true);

         void Add(Vehicle vehicle) ;

         void Remove(Vehicle vehicle);
    }
}