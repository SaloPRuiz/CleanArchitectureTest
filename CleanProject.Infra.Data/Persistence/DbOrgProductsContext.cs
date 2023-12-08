using CleanProject.Infra.Data.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanProject.Infra.Data.Persistence;

public class DbOrgProductsContext : DbContext
{
    
    public DbSet<Product> Products { get; set; }

    private readonly IConfiguration _configuration;
    
    public DbOrgProductsContext() {}
    
    public DbOrgProductsContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configura la cadena de conexión para Productos por Organización
        optionsBuilder.UseSqlServer("Server=localhost;Database=DB_ORG_PROD;Trusted_Connection=True;");
    }

    // Otras configuraciones específicas de este contexto...
}