using CleanProject.Domain.Application.Contracts.Services;
using CleanProject.Domain.Application.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CleanProject.WebApi.Controllers;

[ApiController]
[Route("api/auth")]

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        var user = await _userService.AuthenticateAsync(loginRequest.Username);
        
        if (user == null)
        {
            return Unauthorized();
        }
        
        var token = await _authService.GenerateJwtTokenAsync(user, loginRequest.Tenant);

        return Ok(new { Token = token });
    }
}