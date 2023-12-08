using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Domain.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IUnitOrganizationsUsers _unitOfWork;

    public UserController(IUnitOrganizationsUsers unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var newUser = new UserDto
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Tenant = user.Tenant
            };
            
            await _unitOfWork.UserRepo.AddAsync(newUser);

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var organization = await _unitOfWork.OrganizationRepo.GetByIdAsync(id);
        return Ok(organization);
    }
}