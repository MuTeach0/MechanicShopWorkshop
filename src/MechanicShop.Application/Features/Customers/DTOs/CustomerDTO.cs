namespace MechanicShop.Application.Features.Customers.DTOs;

public class CustomerDTO
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<VehicleDTO> Vehicles { get; set; } = [];
}