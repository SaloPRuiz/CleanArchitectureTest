using CleanProject.Infra.Data;
using CleanProject.WebApi;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// add services container webapi layer
builder.Services.AddWebApiServices(builder.Configuration);

// add services container  data infrastructure layer
builder.Services.AddDataInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure Swagger
app.ConfigureWebApiService(builder.Configuration);

app.UseRouting();

app.MapControllers();

app.Run();