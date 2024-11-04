namespace RideFind_BackEnd.Vehicle.Interface.REST.Resource;

public record CreateVehicleSourceResource(string VehiclesApiKey, string SourceId, string VehicleName, string VehicleType, int VehicleUserId);