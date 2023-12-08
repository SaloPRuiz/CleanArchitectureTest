using CleanProject.Domain.Application.Models;

namespace CleanProject.Domain.Application.Contracts.Services;

public interface IUserService
{
    Task<UserDto?> AuthenticateAsync(string username);
}