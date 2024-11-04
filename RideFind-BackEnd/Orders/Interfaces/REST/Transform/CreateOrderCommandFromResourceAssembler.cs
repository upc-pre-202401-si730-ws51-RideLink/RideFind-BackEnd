using RideFind_BackEnd.Orders.Domain.Model.Commands;
using RideFind_BackEnd.Orders.Interfaces.REST.Resources;

namespace RideFind_BackEnd.Orders.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand
        ToCommandFromResource(CreateOrderResource resource) =>
        new CreateOrderCommand(resource.OwnerName, resource.SelectedPlan,resource.Discount,resource.Subtotal,resource.Total);
}