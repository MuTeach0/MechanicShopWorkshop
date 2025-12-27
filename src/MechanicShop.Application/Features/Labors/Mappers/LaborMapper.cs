using MechanicShop.Application.Features.Labors.DTOs;
using MechanicShop.Domain.Employees;

namespace MechanicShop.Application.Features.Labors.Mappers;

public static class LaborMapper
{
    public static LaborDTO ToDto(this Employee employee)
    {
        return new LaborDTO { LaborId = employee.Id, Name = employee.FullName };
    }

    public static List<LaborDTO> ToDtos(this IEnumerable<Employee> entities)
    {
        return [.. entities.Select(l => l.ToDto())];
    }
}