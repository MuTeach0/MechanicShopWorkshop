using MechanicShop.Application.Features.Dashboard.DTOs;
using MechanicShop.Domain.Common.Results;

using MediatR;

namespace MechanicShop.Application.Features.Dashboard.Queries.GetWorkOrderStats;

public sealed record GetWorkOrderStatsQuery(DateOnly Date) : IRequest<Result<TodayWorkOrderStatsDTO>>;