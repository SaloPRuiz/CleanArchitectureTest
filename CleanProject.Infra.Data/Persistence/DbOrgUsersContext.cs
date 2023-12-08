using CleanProject.Infra.Data.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanProject.Infra.Data.Persistence;

public class DbOrgUsersContext : DbContext
{
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<User> Users { get; set; } 
    
    private readonly IConfiguration _configuration;
    
    public DbOrgUsersContext() {}
    
    public DbOrgUsersContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=DB_ORG_USERS;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Organization)
            .WithMany(o => o.Users)
            .HasForeignKey(u => u.OrganizationId);
        
        base.OnModelCreating(modelBuilder);
    }
}