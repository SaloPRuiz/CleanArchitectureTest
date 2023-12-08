using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Domain.Application.Models;
using CleanProject.Infra.Data.Persistence;
using CleanProject.Infra.Data.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanProject.Infra.Data.Repositories;

public class UserRepo : IUserRepo
{
    private readonly DbOrgUsersContext _ctx;

    public UserRepo(DbOrgUsersContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<UserDto> GetByUsernameAsync(string username)
    {
        var userEntity = await _ctx.Users.Where(u => u.Username == username).Select(u => new UserDto
        {
            Id = u.Id,
            Username = u.Username
        }).FirstOrDefaultAsync();

        return userEntity ?? new UserDto();
    }

    public async Task<UserDto> AddAsync(UserDto user)
    {
        var entity = new User
        {
            Username = user.Username,
            Password = HashPassword(user.Password),
            OrganizationId = user.Tenant,
            Email = user.Email
        };
        
        await _ctx.Users.AddAsync(entity);
        await _ctx.SaveChangesAsync();

        return user;
    }
    
    private string HashPassword(string password)
    {
        // Implementa la lógica para almacenar la contraseña de manera segura
        // Puedes usar un algoritmo de hash como BCrypt o ASP.NET Identity PasswordHasher
        // Aquí hay un ejemplo simple usando BCrypt (requiere el paquete BCrypt.Net)
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}