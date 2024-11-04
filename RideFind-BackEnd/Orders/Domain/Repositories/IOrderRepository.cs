using RideFind_BackEnd.Orders.Domain.Model.Aggregates;
using RideFind_BackEnd.Shared.Domain.Repositories;

namespace RideFind_BackEnd.Orders.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> FindByOwnerNameAsync(string ownerName);
    
    Task<IEnumerable<Order>> GetAllAsync();
    
    //
    Task DeleteOrderAsync(Order order);
}