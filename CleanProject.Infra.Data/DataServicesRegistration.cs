using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Domain.Application.Contracts.Services;
using CleanProject.Infra.Data.Repositories;
using CleanProject.Infra.Data.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanProject.Infra.Data;

public static class DataServicesRegistration
{
    public static IServiceCollection AddDataInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOrganizationsUsers, UnitOrganizationsUsers>();
        services.AddScoped<IUserRepo, UserRepo>();
        services.AddScoped<IOrganizationRepo, OrganizationRepo>();
        
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}