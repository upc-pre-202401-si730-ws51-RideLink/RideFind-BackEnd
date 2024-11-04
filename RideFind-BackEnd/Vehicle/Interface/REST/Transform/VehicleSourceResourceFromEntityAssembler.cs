using RideFind_BackEnd.Vehicle.Domain.Model.Aggregates;
using RideFind_BackEnd.Vehicle.Interface.REST.Resource;

namespace RideFind_BackEnd.Vehicle.Interface.REST.Transform;

public static class VehicleSourceResourceFromEntityAssembler
{
    public static VehicleSourceResource toResourceFromEntity(VehicleSource entity) =>
        new VehicleSourceResource(entity.Id, entity.VehiclesApiKey, entity.SourceId, entity.VehicleName, entity.VehicleType, entity.VehicleUserId);
}