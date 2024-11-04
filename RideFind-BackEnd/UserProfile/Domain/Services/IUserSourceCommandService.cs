using RideFind_BackEnd.UserProfile.Domain.Model.Aggregates;
using RideFind_BackEnd.UserProfile.Domain.Model.Commands;

namespace RideFind_BackEnd.UserProfile.Domain.Services;

public interface IUserSourceCommandService
{
    Task<UserSource> Handle(CreateUserSourceCommand command);
}