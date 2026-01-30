using MechanicShop.Domain.Common;
using MechanicShop.Domain.Customers.Vehicles;
using MechanicShop.Domain.Employees;
using MechanicShop.Domain.RepairTasks;
using MechanicShop.Domain.Workorders.Billing;
using MechanicShop.Domain.WorkOrders.Enum;

namespace MechanicShop.Domain.WorkOrders;

public sealed class WorkOrder : AuditableEntity
{
    public Guid VehicleId { get;}
    public DateTimeOffset StartAtUtc { get; private set; }
    public DateTimeOffset EndAtUtc { get; private set; }

    public Guid LaborId { get; private set; }
    public Spot spot { get; private set; }
    public WorkOrderState State { get; private set; }
    public Employee? Labor { get; set; }
    public Vehicle? Vehicle { get; set; }
    public Invoice? Invoice { get; set; }
    public decimal? Discount { get; private set; }
    public decimal? Tax { get; private set; }
    public decimal? TotalPartsCost => _repairTasks.SelectMany(rt => rt.Parts).Sum(p => p.Cost);
    public decimal? TotalLaborCost => _repairTasks.Sum(rt => rt.LaborCost);
    public decimal? Total => (TotalPartsCost ?? 0) + (TotalLaborCost ?? 0);

    private readonly List<RepairTask> _repairTasks = [];
    public IEnumerable<RepairTask> RepairTasks => _repairTasks.AsReadOnly();

}