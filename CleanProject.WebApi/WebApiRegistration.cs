using System.Text;
using CleanProject.Infra.Data.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CleanProject.WebApi;

public static class WebApiRegistration
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanProject API", Version = "v1" });
        });

        services.AddControllers();

        Console.WriteLine("TESTE");
        Console.WriteLine(configuration["Jwt:Issuer"]);
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
                };
            });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
        });
        

        // Services - WebApi Layer
        services.AddDbContext<DbOrgProductsContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DB_ORG_PROD"),
                sqlServerOptionsAction: sqlserveroptions => sqlserveroptions.EnableRetryOnFailure());
        });

        services.AddDbContext<DbOrgUsersContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DB_ORG_USERS"),
                sqlServerOptionsAction: sqlserveroptions => sqlserveroptions.EnableRetryOnFailure());
        });

        return services;
    }

    public static void ConfigureWebApiService(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanProject API V1"); });

        app.UseAuthentication();

        app.UseMiddleware<MultitenantMiddleware>();
    }
}