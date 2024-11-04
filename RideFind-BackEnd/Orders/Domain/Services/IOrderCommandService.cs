using RideFind_BackEnd.Orders.Domain.Model.Aggregates;
using RideFind_BackEnd.Orders.Domain.Model.Commands;

namespace RideFind_BackEnd.Orders.Domain.Services;

public interface IOrderCommandService
{
    Task<Order> Handle(CreateOrderCommand command);
}