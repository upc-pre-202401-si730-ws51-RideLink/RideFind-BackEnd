using RideFind_BackEnd.UserProfile.Domain.Model.Aggregates;
using RideFind_BackEnd.UserProfile.Domain.Model.Queries;
using RideFind_BackEnd.UserProfile.Domain.Repositories;
using RideFind_BackEnd.UserProfile.Domain.Services;

namespace RideFind_BackEnd.UserProfile.Application.Internal.QueryService;

public class UserSourceQueryService(IUserSourceRepository userSourceRepository) :
IUserSourceQueryService
{
   
    

    public async Task<UserSource> Handle(GetUserSourceByDNIQuery query)
    {
        return await userSourceRepository.FindByUserDNIAsync(query.DNI);
    }

    public async Task<UserSource> Handle(GetUserSourceByIdQuery query)
    {
        return await userSourceRepository.FindByIdAsync(query.id);
    }
    
}