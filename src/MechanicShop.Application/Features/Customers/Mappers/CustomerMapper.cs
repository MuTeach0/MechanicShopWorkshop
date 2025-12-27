using MechanicShop.Application.Features.Customers.DTOs;
using MechanicShop.Domain.Common.Customers;
using MechanicShop.Domain.Customers.Vehicles;

namespace MechanicShop.Application.Features.Customers.Mappers;

public static class CustomerMapper
{
    public static CustomerDTO ToDTO(this Customer entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new CustomerDTO
        {
            CustomerId = entity.Id,
            Name = entity.Name!,
            Email = entity.Email!,
            PhoneNumber = entity.PhoneNumber!,
            Vehicles = entity.Vehicles?.Select(v => v.ToDTO()).ToList() ?? []
        };
    }

    public static List<CustomerDTO> ToDTOs(this IEnumerable<Customer> entities) =>
        [.. entities.Select(e => e.ToDTO())];

    public static VehicleDTO ToDTO(this Vehicle entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new VehicleDTO(
            entity.Id,
            entity.Make!,
            entity.Model!,
            entity.Year,
            entity.LicensePlate);
    }

    public static List<VehicleDTO> ToDTOs(this IEnumerable<Vehicle> entities) =>
        [.. entities.Select(e => e.ToDTO())];

}