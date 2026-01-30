using MechanicShop.Domain.Common.Results;

namespace MechanicShop.Domain.WorkOrders.Events;

public sealed class WorkOrderErrors
{

    public static readonly Error WorkOrderIdRequired = 
        Error.Validation(
            code: "WorkOrderErrors.WorkOrderIdRequired",
            description: "Work order ID is required."
        );
    public static readonly Error WorkOrderNotFound = 
        Error.NotFound(
            code: "WorkOrderErrors.WorkOrderNotFound",
            description: "Work order not found."
        );
}
