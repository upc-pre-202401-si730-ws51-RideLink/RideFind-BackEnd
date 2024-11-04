using RideFind_BackEnd.Orders.Domain.Model.Aggregates;
using RideFind_BackEnd.Orders.Interfaces.REST.Resources;

namespace RideFind_BackEnd.Orders.Interfaces.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order entity)
        => new OrderResource(entity.Id, entity.OwnerName, entity.SelectedPlan,entity.Discount,entity.Subtotal,entity.Total);
}