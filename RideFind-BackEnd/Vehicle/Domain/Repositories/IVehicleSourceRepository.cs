using RideFind_BackEnd.Shared.Domain.Repositories;
using RideFind_BackEnd.Vehicle.Domain.Model.Aggregates;

namespace RideFind_BackEnd.Vehicle.Domain.Repositories;

public interface IVehicleSourceRepository : IBaseRepository<VehicleSource>
{
    Task<IEnumerable<VehicleSource>> FindByVehiclesApiKeyAsync(string vehiclesApiKey);

    Task<VehicleSource> FindByVehiclesApiKeyAndSourceIdAsync(string vehiclesApiKey, string sourceId);

    Task<IEnumerable<VehicleSource>> FindByVehicleUserIdAsync(int vehicleUserId);
    
    Task DeleteFavoriteSourceAsync(VehicleSource vehicleSource);
    
    
}