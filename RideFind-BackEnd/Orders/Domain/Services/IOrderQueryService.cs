using RideFind_BackEnd.Orders.Domain.Model.Aggregates;
using RideFind_BackEnd.Orders.Domain.Model.Queries;

namespace RideFind_BackEnd.Orders.Domain.Services;

public interface IOrderQueryService
{
    
    Task<IEnumerable<Order>> Handle(GetOrderByOwnerNameQuery query);

    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);

    Task<Order> Handle(GetOrderByIdQuery query);
}