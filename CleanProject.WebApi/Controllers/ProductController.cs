using CleanProject.Domain.Application.Contracts.Persistence;
using CleanProject.Domain.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IUnitOrganizationsProducts _unitOfWork;

    public ProductController(IUnitOrganizationsProducts unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var entity = new ProductDto
            {
                Name = product.Name
            };

            entity = await _unitOfWork.ProductRepo.AddAsync(entity);

            return CreatedAtAction(nameof(GetProduct), new { id = entity.Id }, entity);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var organization = await _unitOfWork.ProductRepo.GetByIdAsync(id);
        return Ok(organization);
    }
}