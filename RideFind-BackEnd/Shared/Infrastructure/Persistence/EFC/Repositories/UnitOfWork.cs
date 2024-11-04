using RideFind_BackEnd.Shared.Domain.Repositories;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}