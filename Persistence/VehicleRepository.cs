using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using vega.Core;
using vega.Core.Models;

namespace vega.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;
        private readonly ILogger<VehicleRepository> logger;
        public VehicleRepository(VegaDbContext context, ILogger<VehicleRepository> logger)
        {
            this.logger = logger;
            this.context = context;

        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(Filter filter)
        {
            var query = context.Vehicles
                .Include(v => v.Model)
                .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .AsQueryable();

            if (filter.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == filter.MakeId.Value);

            // if (filter.ModelId.HasValue)
            //     query = query.Where(v => v.ModelId == filter.ModelId.Value);
                
            return await query.ToListAsync();
         }
        public async Task<Vehicle> GetVehicle(int id, bool incluedeRelated = true)
        {
            if (!incluedeRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles
               .Include(v => v.Features)
                   .ThenInclude(vf => vf.Feature)
               .Include(v => v.Model)
                   .ThenInclude(m => m.Make)
               .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
        }
    }
}