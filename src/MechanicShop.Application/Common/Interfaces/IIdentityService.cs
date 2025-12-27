using MechanicShop.Application.Features.Identity.DTOs;
using MechanicShop.Domain.Common.Results;

namespace MechanicShop.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string? policyName);

    Task<Result<AppUserDTO>> AuthenticateAsync(string email, string password);

    Task<Result<AppUserDTO>> GetUserByIdAsync(string userId);

    Task<string?> GetUserNameAsync(string userId);
}