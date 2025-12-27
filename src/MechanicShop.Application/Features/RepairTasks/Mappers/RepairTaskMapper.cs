using MechanicShop.Application.Features.RepairTasks.DTOs;
using MechanicShop.Domain.RepairTasks;
using MechanicShop.Domain.RepairTasks.Parts;

namespace MechanicShop.Application.Features.RepairTasks.Mappers;

public static class RepairTaskMapper
{
    public static RepairTaskDTO ToDTO(this RepairTask entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new RepairTaskDTO
        {
            RepairTaskId = entity.Id,
            Name = entity.Name!,
            LaborCost = entity.LaborCost,
            TotalCost = entity.TotalCost,
            EstimatedDurationInMins = entity.EstimatedDurationInMins,
            Parts = entity.Parts.ToList().ConvertAll(ToDto)
        };
    }

    public static List<RepairTaskDTO> ToDtos(this IEnumerable<RepairTask> entities)
    {
        return [.. entities.Select(e => e.ToDTO())];
    }

    public static PartDTO ToDto(this Part entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new PartDTO
        {
            PartId = entity.Id,
            Name = entity.Name!,
            Cost = entity.Cost,
            Quantity = entity.Quantity
        };
    }

    public static List<PartDTO> ToDtos(this IEnumerable<Part> entities)
    {
        return [.. entities.Select(e => e.ToDto())];
    }
}