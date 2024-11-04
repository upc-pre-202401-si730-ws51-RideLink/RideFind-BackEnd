using RideFind_BackEnd.Vehicle.Domain.Model.Commands;
using RideFind_BackEnd.Vehicle.Interface.REST.Resource;

namespace RideFind_BackEnd.Vehicle.Interface.REST.Transform;

public class CreateVehicleSourceCommandFromResourceAssembler
{
    public static CreateVehicleSourceCommand
        ToCommandFromResource(CreateVehicleSourceResource resource) =>
        new CreateVehicleSourceCommand(resource.VehiclesApiKey, resource.SourceId, resource.VehicleName, resource.VehicleType, resource.VehicleUserId);
}