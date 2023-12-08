using CleanProject.Domain.Application.Models;

namespace CleanProject.Domain.Application.Contracts.Persistence;

public interface IProductRepo
{
    Task<ProductDto> GetByIdAsync(int id);
    Task<ProductDto> AddAsync(ProductDto product);
}