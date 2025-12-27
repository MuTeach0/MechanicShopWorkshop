using MechanicShop.Application.Features.Customers.Mappers;
using MechanicShop.Application.Features.Labors.DTOs;
using MechanicShop.Application.Features.RepairTasks.Mappers;
using MechanicShop.Application.Features.WorkOrders.DTOs;
using MechanicShop.Domain.WorkOrders;

namespace MechanicShop.Application.Features.WorkOrders.Mappers;

public static class WorkOrderMapper
{
    public static WorkOrderDTO ToDTO(this WorkOrder entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new WorkOrderDTO
        {
            WorkOrderId = entity.Id,
            Spot = entity.Spot,
            StartAtUtc = entity.StartAtUtc,
            EndAtUtc = entity.EndAtUtc,
            Labor = entity.Labor is null ? null : new LaborDTO
            {
                LaborId = entity.LaborId,
                Name = $"{entity.Labor.FirstName} {entity.Labor.LastName}"
            },
            RepairTasks = entity.RepairTasks.ToDtos(),
            Vehicle = entity.Vehicle is null ? null : entity.Vehicle.ToDTO(),
            State = entity.State,
            TotalPartCost = entity.RepairTasks.SelectMany(t => t.Parts).Sum(p => p.Cost * p.Quantity),
            TotalLaborCost = entity.RepairTasks.Sum(p => p.LaborCost),
            TotalCost = entity.RepairTasks.Sum(rt => rt.TotalCost),
            TotalDurationInMins = entity.RepairTasks.Sum(rt => (int)rt.EstimatedDurationInMins),
            InvoiceId = entity.Invoice?.Id,
            CreatedAt = entity.CreatedAtUtc
        };
    }

    public static List<WorkOrderDTO> ToDtos(this IEnumerable<WorkOrder> entities)
    {
        return [.. entities.Select(e => e.ToDTO())];
    }

    public static WorkOrderListItemDTO ToListItemDto(this WorkOrder entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new WorkOrderListItemDTO
        {
            WorkOrderId = entity.Id,
            Spot = entity.Spot,
            StartAtUtc = entity.StartAtUtc,
            EndAtUtc = entity.EndAtUtc,
            Vehicle = entity.Vehicle!.ToDTO(),
            Labor = entity.Labor is null ? null :
                $"{entity.Labor.FirstName} {entity.Labor.LastName}",
            State = entity.State,
            RepairTasks = entity.RepairTasks.Select(rt => rt.Name).ToList()
        };
    }
}