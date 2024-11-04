using RideFind_BackEnd.Vehicle.Domain.Model.Aggregates;
using RideFind_BackEnd.Vehicle.Domain.Model.Queries;

namespace RideFind_BackEnd.Vehicle.Domain.Services;

public interface IVehicleSourceQueryService
{
    Task<IEnumerable<VehicleSource>> Handle(GetVehicleSourceByVehicleApiKeyQuery query);
    Task<VehicleSource> Handle(GetVehicleSourceByVehicleApiKeyANDSourceIdQuery query);
    Task<VehicleSource> Handle(GetVehicleSourceByIdQuery query);
}