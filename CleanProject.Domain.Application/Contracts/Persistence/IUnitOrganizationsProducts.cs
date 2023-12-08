using CleanProject.Domain.Application.Models;

namespace CleanProject.Domain.Application.Contracts.Persistence;

public interface IUnitOrganizationsProducts : IDisposable
{
    IProductRepo ProductRepo { get; } 
    Task<int> SaveChangesAsync();
}