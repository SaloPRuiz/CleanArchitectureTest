using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanProject.WebApi;

public class MultitenantMiddleware
{
    private readonly RequestDelegate _next;

    public MultitenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        // Getting the tenant name from URL
        var tenant = context.Request.Path.Value.Split('/')[1];

        // Configure the conexión of DB from the tenant
        // ConfigureDatabaseConnection(dbContextOptionsBuilder, tenant);
        
        // Calling next middleware
        await _next(context);
    }

    private void ConfigureDatabaseConnection(DbContextOptionsBuilder dbContextOptionsBuilder, string tenant)
    {
        dbContextOptionsBuilder.UseSqlServer(GetConnectionStringForTenant(tenant));
    }

    private string GetConnectionStringForTenant(string tenant)
    {
        var connectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog={tenant}Database;Integrated Security=True";
        return connectionString;
    }
}