using MechanicShop.Application.Common.Interfaces;
using MechanicShop.Application.Features.Customers.DTOs;
using MechanicShop.Application.Features.Customers.Mappers;
using MechanicShop.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MechanicShop.Application.Features.Customers.Queries.GetCustomers;

public class GetCustomersQueryHandler(IAppDbContext context) : IRequestHandler<GetCustomerQuery, Result<List<CustomerDTO>>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<List<CustomerDTO>>> Handle(GetCustomerQuery request, CancellationToken ct) =>
        await _context.Customers.Include(c => c.Vehicles).AsNoTracking().Select(c => c.ToDTO()).ToListAsync(ct);
}