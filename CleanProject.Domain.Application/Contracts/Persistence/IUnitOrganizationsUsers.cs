namespace CleanProject.Domain.Application.Contracts.Persistence;

public interface IUnitOrganizationsUsers : IDisposable
{
    IUserRepo UserRepo { get; } 
    
    IOrganizationRepo OrganizationRepo { get; } 
 
    Task<int> SaveChangesAsync();
}