namespace CleanProject.Infra.Data.Persistence.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public int OrganizationId { get; set; }
    public virtual Organization Organization { get; set; }
}