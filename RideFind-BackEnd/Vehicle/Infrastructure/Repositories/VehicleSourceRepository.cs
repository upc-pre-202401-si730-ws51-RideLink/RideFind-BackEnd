using Microsoft.EntityFrameworkCore;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;
using RideFind_BackEnd.Vehicle.Domain.Model.Aggregates;
using RideFind_BackEnd.Vehicle.Domain.Repositories;

namespace RideFind_BackEnd.Vehicle.Infrastructure.Repositories;

public class VehicleSourceRepository : BaseRepository<VehicleSource>, IVehicleSourceRepository
{
    public VehicleSourceRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<VehicleSource>> FindByVehiclesApiKeyAsync(string vehiclesApiKey)
    {
        return await Context.Set<VehicleSource>().Where(f => f.VehiclesApiKey == vehiclesApiKey).ToListAsync();
    }

    public async Task<VehicleSource?> FindByVehiclesApiKeyAndSourceIdAsync(string vehiclesApiKey, string sourceId)
    {
        return await Context.Set<VehicleSource>()
            .FirstOrDefaultAsync(f => f.VehiclesApiKey == vehiclesApiKey && f.SourceId == sourceId);
    }

    

    public async Task<IEnumerable<VehicleSource>> FindByVehicleUserIdAsync(int vehicleUserId)
    {
        return await Context.Set<VehicleSource>()
            .Where(f => f.VehicleUserId == vehicleUserId)
            .ToListAsync();
    }

    public async Task DeleteFavoriteSourceAsync(VehicleSource vehicleSource)
    {
        Remove(vehicleSource);
        await Context.SaveChangesAsync();
    }
    
    
}