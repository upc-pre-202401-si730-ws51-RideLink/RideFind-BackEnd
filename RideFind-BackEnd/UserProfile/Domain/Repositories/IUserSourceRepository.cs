using RideFind_BackEnd.Shared.Domain.Repositories;
using RideFind_BackEnd.UserProfile.Domain.Model.Aggregates;

namespace RideFind_BackEnd.UserProfile.Domain.Repositories;

public interface IUserSourceRepository : IBaseRepository<UserSource>
{

    
    Task<UserSource> FindByUserDNIAsync(int DNI);
    Task DeleteUser(UserSource UserSource);

}