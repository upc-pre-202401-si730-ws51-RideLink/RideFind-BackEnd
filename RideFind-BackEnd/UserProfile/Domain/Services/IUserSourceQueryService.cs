using RideFind_BackEnd.UserProfile.Domain.Model.Aggregates;
using RideFind_BackEnd.UserProfile.Domain.Model.Queries;
using RideFind_BackEnd.Vehicle.Domain.Model.Aggregates;

namespace RideFind_BackEnd.UserProfile.Domain.Services;

public interface IUserSourceQueryService
{
    Task<UserSource> Handle(GetUserSourceByDNIQuery query);
    Task<UserSource> Handle(GetUserSourceByIdQuery query);
}