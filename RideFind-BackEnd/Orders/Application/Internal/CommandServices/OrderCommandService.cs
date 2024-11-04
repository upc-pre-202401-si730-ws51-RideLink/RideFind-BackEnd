
using RideFind_BackEnd.Orders.Domain.Model.Aggregates;
using RideFind_BackEnd.Orders.Domain.Model.Commands;
using RideFind_BackEnd.Orders.Domain.Repositories;
using RideFind_BackEnd.Orders.Domain.Services;
using RideFind_BackEnd.Shared.Domain.Repositories;

namespace RideFind_BackEnd.Orders.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) :IOrderCommandService
{
    public async Task<Order> Handle(CreateOrderCommand command)
    {
        var existingOrder = await orderRepository.FindByOwnerNameAsync(command.OwnerName);
        if (existingOrder.Any())
            throw new
                Exception("Order already exists for the given Name");
        var order = new Order(command);
        await orderRepository.AddAsync(order);
        await unitOfWork.CompleteAsync();
        return order;
    }
}