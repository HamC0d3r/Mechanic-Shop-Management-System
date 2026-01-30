namespace MechanicShop.Domain.WorkOrders.Events;
public sealed class WorkOrderCompleted
{
    public Guid WorkOrderId { get; init; }

}