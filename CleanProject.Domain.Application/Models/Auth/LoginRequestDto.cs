namespace CleanProject.Domain.Application.Models.Auth;

public class LoginRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Tenant { get; set; }
}