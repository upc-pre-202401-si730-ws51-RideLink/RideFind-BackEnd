using Microsoft.EntityFrameworkCore;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;
using RideFind_BackEnd.UserProfile.Domain.Model.Aggregates;
using RideFind_BackEnd.UserProfile.Domain.Repositories;

namespace RideFind_BackEnd.UserProfile.Infrastructure.Repositories;

public class UserSourceRepository : BaseRepository<UserSource>, IUserSourceRepository
{
    public UserSourceRepository(AppDbContext context) : base(context)
    {
        
    }

   
    
    public async Task<UserSource?> FindByUserDNIAsync(int DNI)
    {
        return await Context.Set<UserSource>()
            .FirstOrDefaultAsync(f => f.Dni == DNI);
    }
    
    public async Task DeleteUser(UserSource userSource)
    {
        Remove(userSource);
        await Context.SaveChangesAsync();
    }
    
}