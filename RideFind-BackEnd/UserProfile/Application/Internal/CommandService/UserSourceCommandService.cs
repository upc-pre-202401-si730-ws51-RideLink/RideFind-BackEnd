using RideFind_BackEnd.Shared.Domain.Repositories;
using RideFind_BackEnd.UserProfile.Domain.Model.Aggregates;
using RideFind_BackEnd.UserProfile.Domain.Model.Commands;
using RideFind_BackEnd.UserProfile.Domain.Repositories;
using RideFind_BackEnd.UserProfile.Domain.Services;

namespace RideFind_BackEnd.UserProfile.Application.Internal.CommandService;

public class UserSourceCommandService(IUserSourceRepository userSourceRepository
, IUnitOfWork unitOfWork) : IUserSourceCommandService
{
    public async Task<UserSource> Handle(CreateUserSourceCommand command)
    {
        var favoriteSource = await
            userSourceRepository.FindByUserDNIAsync(command.DNI);
        if (favoriteSource != null)
            throw new Exception("Favorite source with this DNI already exists");
        favoriteSource = new UserSource(command);
        await userSourceRepository.AddAsync(favoriteSource);
        await unitOfWork.CompleteAsync();
        return favoriteSource;
        
    }
}