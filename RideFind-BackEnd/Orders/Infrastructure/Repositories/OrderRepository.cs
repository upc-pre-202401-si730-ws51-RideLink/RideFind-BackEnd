using Microsoft.EntityFrameworkCore;
using RideFind_BackEnd.Orders.Domain.Model.Aggregates;
using RideFind_BackEnd.Orders.Domain.Repositories;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RideFind_BackEnd.Orders.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> FindByOwnerNameAsync(string ownerName)
    {
        return await Context.Set<Order>().Where(o => o.OwnerName == ownerName).ToListAsync();
    }

    public async  Task<IEnumerable<Order>> GetAllAsync()
    {
        return await Context.Set<Order>().ToListAsync();
    }
    
    //
    public async Task DeleteOrderAsync(Order order)
    {
        Remove(order);
        await Context.SaveChangesAsync();
    }
}