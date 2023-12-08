using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Domain.Application.Models;
using CleanProject.Infra.Data.Persistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationController : ControllerBase
{
    private readonly IUnitOrganizationsUsers _unitOfWork;

    public OrganizationController(IUnitOrganizationsUsers unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrganization([FromBody] OrganizationDto organizationDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var newOrganization = new OrganizationDto
            {
                Name = organizationDto.Name
            };
            
            newOrganization = await _unitOfWork.OrganizationRepo.AddAsync(newOrganization);
            
            return CreatedAtAction(nameof(GetOrganization), new { id = newOrganization.Id }, newOrganization);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrganization(int id)
    {
        var organization = await _unitOfWork.OrganizationRepo.GetByIdAsync(id);
        return Ok(organization);
    }
}