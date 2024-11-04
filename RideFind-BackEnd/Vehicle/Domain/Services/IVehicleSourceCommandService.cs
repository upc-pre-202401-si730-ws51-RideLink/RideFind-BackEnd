using RideFind_BackEnd.Vehicle.Domain.Model.Aggregates;
using RideFind_BackEnd.Vehicle.Domain.Model.Commands;

namespace RideFind_BackEnd.Vehicle.Domain.Services;

public interface IVehicleSourceCommandService
{
    Task<VehicleSource> Handle(CreateVehicleSourceCommand command);
}