namespace CleanProject.Infra.Data.Persistence.Models;

public class Organization
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
}