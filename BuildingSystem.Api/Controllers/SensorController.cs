using BankSystemApp.Interfaces;
using BuildingSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SensorController : ControllerBase
{
    private readonly ISensorService _sensorService;

    public SensorController(ISensorService sensorService)
    {
        _sensorService = sensorService;
    }

    [HttpGet("{buildingId}")]
    public async Task<IActionResult> GetSensors([FromRoute] Guid buildingId)
    {
        var sensors = await _sensorService.GetByIdAsync(buildingId, cancellationToken: CancellationToken.None);
        return Ok(sensors);
    }

    [HttpPost]
    public async Task<IActionResult> AddSensor([FromBody] Sensor sensor)
    {
        if (sensor == null)
        {
            return BadRequest("Sensor cannot be null.");
        }

        await _sensorService.AddAsync(sensor, CancellationToken.None);
        return CreatedAtAction(nameof(GetSensors), sensor);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateSensor(Guid id, [FromBody] Sensor sensor)
    {
        await _sensorService.UpdateAsync(sensor, CancellationToken.None);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSensor(Guid id)
    {
        await _sensorService.DeleteAsync(id, CancellationToken.None);
        return NoContent();
    }
}