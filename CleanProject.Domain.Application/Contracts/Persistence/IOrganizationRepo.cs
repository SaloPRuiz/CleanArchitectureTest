using CleanProject.Domain.Application.Models;

namespace CleanProject.Domain.Application.Contracts.Persistence;

public interface IOrganizationRepo
{
    Task<List<OrganizationDto>> GetAllAsync();
    Task<OrganizationDto> GetByIdAsync(int id);
    Task<OrganizationDto> AddAsync(OrganizationDto organization);
}