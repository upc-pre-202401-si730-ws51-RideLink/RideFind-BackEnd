using RideFind_BackEnd.Vehicle.Domain.Model.Aggregates;
using RideFind_BackEnd.Vehicle.Domain.Model.Queries;
using RideFind_BackEnd.Vehicle.Domain.Repositories;
using RideFind_BackEnd.Vehicle.Domain.Services;

namespace RideFind_BackEnd.Vehicle.Application.Internal.QueryService;

public class VehicleSourceQueryService(IVehicleSourceRepository vehicleSourceRepository) :
    IVehicleSourceQueryService
{
    public async Task<VehicleSource> Handle(GetVehicleSourceByVehicleApiKeyANDSourceIdQuery query)
    {
        return await vehicleSourceRepository.FindByVehiclesApiKeyAndSourceIdAsync(query.VehicleApiKey, query.SourceId);
    }

    public async Task<VehicleSource> Handle(GetVehicleSourceByIdQuery query)
    {
        return await vehicleSourceRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<VehicleSource>> Handle(GetVehicleSourceByVehicleApiKeyQuery query)
    {
        return await vehicleSourceRepository.FindByVehiclesApiKeyAsync(query.VehicleApiKey);
    }
}