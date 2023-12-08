using CleanProject.Domain.Application.Models;

namespace CleanProject.Domain.Application.Contracts.Services;

public interface IAuthService
{
    Task<string> GenerateJwtTokenAsync(UserDto user, string tenant);
}