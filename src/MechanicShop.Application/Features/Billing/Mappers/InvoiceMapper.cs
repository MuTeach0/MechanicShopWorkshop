using MechanicShop.Application.Features.Billing.DTOs;
using MechanicShop.Application.Features.Customers.Mappers;
using MechanicShop.Domain.WorkOrders.Billing;

namespace MechanicShop.Application.Features.Billing.Mappers;

public static class InvoiceMapper
{
    public static InvoiceDTO ToDto(this Invoice invoice)
    {
        ArgumentNullException.ThrowIfNull(invoice);

        return new InvoiceDTO
        {
            InvoiceId = invoice.Id,
            WorkOrderId = invoice.WorkOrderId,
            Customer = invoice.WorkOrder!.Vehicle!.Customer!.ToDTO(),
            Vehicle = invoice.WorkOrder.Vehicle.ToDTO(),
            IssuedAtUtc = invoice.IssuedAtUtc,
            Subtotal = invoice.Subtotal,
            TaxAmount = invoice.TaxAmount,
            DiscountAmount = invoice.DiscountAmount,
            Total = invoice.Total,
            PaymentStatus = invoice.Status.ToString(),
            Items = invoice.LineItems.Select(x => x.ToDTO()).ToList()
        };
    }

    public static List<InvoiceDTO> ToDTOs(this IEnumerable<Invoice> entities) =>
        [.. entities.Select(e => e.ToDto())];

    public static InvoiceLineItemDTO ToDTO(this InvoiceLineItem item)
    {
        return new InvoiceLineItemDTO
        {
            InvoiceId = item.InvoiceId,
            LineNumber = item.LineNumber,
            Description = item.Description,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            LineTotal = item.LineTotal
        };
    }

    public static List<InvoiceLineItemDTO> ToDTOs(this IEnumerable<InvoiceLineItem> entities) =>
        [.. entities.Select(e => e.ToDTO())];
}