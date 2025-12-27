using MechanicShop.Application.Common.Interfaces;
using MechanicShop.Application.Features.Labors.DTOs;
using MechanicShop.Application.Features.Labors.Mappers;
using MechanicShop.Domain.Common.Results;
using MechanicShop.Domain.Identity;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace MechanicShop.Application.Features.Labors.Queries.GetLabors;

public class GetLaborsQueryHandler(IAppDbContext context)
    : IRequestHandler<GetLaborsQuery, Result<List<LaborDTO>>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<List<LaborDTO>>> Handle(GetLaborsQuery query, CancellationToken ct)
    {
        var labors = await _context.Employees.AsNoTracking().Where(e => e.Role == Role.Labor).ToListAsync(ct);

        return labors.ToDtos();
    }
}