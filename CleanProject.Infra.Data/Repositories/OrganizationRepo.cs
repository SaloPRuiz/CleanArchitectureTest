using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Domain.Application.Models;
using CleanProject.Infra.Data.Persistence;
using CleanProject.Infra.Data.Persistence.Models;

namespace CleanProject.Infra.Data.Repositories;

public class OrganizationRepo : IOrganizationRepo
{
    private readonly DbOrgUsersContext _ctx;

    public OrganizationRepo(DbOrgUsersContext ctx)
    {
        _ctx = ctx;
    }
    
    public Task<List<OrganizationDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<OrganizationDto> AddAsync(OrganizationDto organization)
    {
        var entity = new Organization
        {
            Name = organization.Name
        };
        
        await _ctx.Organizations.AddAsync(entity);
        await _ctx.SaveChangesAsync();

        organization.Id = entity.Id;
        return organization;
    }
}