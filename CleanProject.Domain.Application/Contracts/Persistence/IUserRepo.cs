using CleanProject.Domain.Application.Models;

namespace CleanProject.Domain.Application.Contracts.Persistence;

public interface IUserRepo
{
    Task<UserDto> GetByUsernameAsync(string username);
    Task<UserDto> AddAsync(UserDto user);
}