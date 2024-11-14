using BankSystemApp.Interfaces;
using BuildingSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly IBuildingService _buildingService;

    public BuildingController(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpGet("{guid}", Name = "GetBuilding")]
    public async Task<IActionResult> GetBuilding([FromRoute] Guid guid)
    {
        var building = await _buildingService.GetByUserIdAsync(guid);
        return Ok(building);
    }

    [HttpPost]
    public async Task<IActionResult> AddBuilding([FromBody] Building building)
    {
        if (building == null)
        {
            return BadRequest("Building cannot be null.");
        }

        await _buildingService.AddAsync(building);
        return CreatedAtAction(nameof(GetBuilding),  building);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBuilding(Guid id)
    {
        await _buildingService.DeleteAsync(id);
        return NoContent();
    }
}