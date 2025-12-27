using MechanicShop.Application.Common.Interfaces;
using MechanicShop.Application.Features.RepairTasks.DTOs;
using MechanicShop.Application.Features.RepairTasks.Mappers;
using MechanicShop.Domain.Common.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace MechanicShop.Application.Features.RepairTasks.Queries.GetRepairTasks;

public class GetRepairTasksQueryHandler(IAppDbContext context)
    : IRequestHandler<GetRepairTasksQuery, Result<List<RepairTaskDTO>>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Result<List<RepairTaskDTO>>> Handle(GetRepairTasksQuery query, CancellationToken ct)
    {
        var repairTasks = await _context.RepairTasks.Include(rt => rt.Parts).AsNoTracking().ToListAsync(ct);

        return repairTasks.ToDtos();
    }
}