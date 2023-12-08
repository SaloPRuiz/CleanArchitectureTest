using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Infra.Data.Persistence;

namespace CleanProject.Infra.Data.Repositories;

public class UnitOrganizationsProducts : IUnitOrganizationsProducts
{
    public IProductRepo ProductRepo { get; }
    
    private readonly DbOrgProductsContext _orgProductsContext;
 
    public UnitOrganizationsProducts(DbOrgProductsContext orgProductsContext, IProductRepo productRepo)
    {
        _orgProductsContext = orgProductsContext;
        ProductRepo = productRepo;
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _orgProductsContext.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _orgProductsContext.Dispose();
    }
}