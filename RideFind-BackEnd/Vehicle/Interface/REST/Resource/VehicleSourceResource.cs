namespace RideFind_BackEnd.Vehicle.Interface.REST.Resource;

public record VehicleSourceResource(int Id, string VehiclesApiKey, string SourceId, string VehicleName, string VehicleType, int VehicleUserId);
