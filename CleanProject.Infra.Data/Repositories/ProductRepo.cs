using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Domain.Application.Models;
using CleanProject.Infra.Data.Persistence;
using CleanProject.Infra.Data.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanProject.Infra.Data.Repositories;

public class ProductRepo : IProductRepo
{
    private readonly DbOrgProductsContext _ctx;

    public ProductRepo(DbOrgProductsContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var entity = await _ctx.Products.Where(p => p.Id == id).Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name
        }).FirstOrDefaultAsync();

        return entity ?? new ProductDto();
    }

    public async Task<ProductDto> AddAsync(ProductDto product)
    {
        var entity = new Product
        {
            Name = product.Name
        };
        
        await _ctx.Products.AddAsync(entity);
        await _ctx.SaveChangesAsync();

        product.Id = entity.Id;

        return product;
    }
}