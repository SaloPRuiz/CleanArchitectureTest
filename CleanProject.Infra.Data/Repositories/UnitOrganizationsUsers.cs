using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Infra.Data.Persistence;

namespace CleanProject.Infra.Data.Repositories;

public class UnitOrganizationsUsers : IUnitOrganizationsUsers
{
    private readonly DbOrgUsersContext _orgUsersContext;
    public IUserRepo UserRepo { get; }
    public IOrganizationRepo OrganizationRepo { get; }

    public UnitOrganizationsUsers(DbOrgUsersContext orgUsersContext)
    {
        _orgUsersContext = orgUsersContext;
        UserRepo = new UserRepo(orgUsersContext);
        OrganizationRepo = new OrganizationRepo(orgUsersContext);
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _orgUsersContext.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _orgUsersContext.Dispose();
    }

}