using MechanicShop.Application.Features.Scheduling.DTOs;
using MechanicShop.Domain.WorkOrders.Enums;

namespace MechanicShop.Application.Features.Scheduling.DTOs;

public class SpotDTO
{
    public Spot Spot { get; set; }
    public List<AvailabilitySlotDTO> Slots { get; set; } = [];
}