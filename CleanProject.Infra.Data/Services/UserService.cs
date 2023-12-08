using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Domain.Application.Contracts.Services;
using CleanProject.Domain.Application.Models;

namespace CleanProject.Infra.Data.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<UserDto?> AuthenticateAsync(string username)
    {
        var user = await _userRepo.GetByUsernameAsync(username);

        if (user.Username is null)
        {
            return null;
        }
        
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
        };
        
    }
}