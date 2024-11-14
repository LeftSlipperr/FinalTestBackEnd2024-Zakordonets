using BankSystemApp.Interfaces;
using BuildingSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SensorDataController : ControllerBase
{
    private readonly ISensorDataService _sensorDataService;

    public SensorDataController(ISensorDataService sensorDataService)
    {
        _sensorDataService = sensorDataService;
    }

    [HttpPost]
    public async Task<IActionResult> AddSensorData([FromBody] SensorData sensor)
    {
        if (sensor == null)
        {
            return BadRequest("Sensor data cannot be null.");
        }

        await _sensorDataService.AddAsync(sensor, CancellationToken.None);
        return NoContent();
    }

    [HttpGet("{sensorId}")]
    public async Task<IActionResult> GetSensorData([FromRoute] Guid sensorId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var data = await _sensorDataService.GetBySensorIdAndDateRangeAsync(sensorId, startDate, endDate, CancellationToken.None);
        return Ok(data);
    }
}