namespace RideFind_BackEnd.Orders.Interfaces.REST.Resources;

public record CreateOrderResource(string OwnerName,
    string SelectedPlan,
    double Discount,
    double Subtotal,
    double Total);