
using RideFind_BackEnd.Orders.Domain.Model.Aggregates;
using RideFind_BackEnd.Orders.Domain.Model.Queries;
using RideFind_BackEnd.Orders.Domain.Repositories;
using RideFind_BackEnd.Orders.Domain.Services;

namespace RideFind_BackEnd.Orders.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository) 
    : IOrderQueryService
{
    public async Task<Order> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<Order>> Handle(GetOrderByOwnerNameQuery query)
    {
        return await orderRepository.FindByOwnerNameAsync(query.OwnerName);
    }
    
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
    {
        return await orderRepository.ListAsync();
    }
}