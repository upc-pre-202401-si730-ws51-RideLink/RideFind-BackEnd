namespace RideFind_BackEnd.Orders.Interfaces.REST.Resources;

public record OrderResource(
    int Id,
    string OwnerName,
    string SelectedPlan,
    double Discount,
    double Subtotal,
    double Total);