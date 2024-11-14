using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingSystem.Data.Storage;

public class SensorStorage
{
    private readonly BuildingSystemDbContext _context;

    public SensorStorage(BuildingSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Sensor> GetByIdAsync(Guid sensorId)
        => await _context.Sensors.FindAsync(sensorId);

    public async Task<IEnumerable<Sensor>> GetByBuildingIdAsync(Guid buildingId)
        => await _context.Sensors.Where(s => s.BuildingId == buildingId).ToListAsync();

    public async Task AddAsync(Sensor sensor)
    {
        await _context.Sensors.AddAsync(sensor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sensor sensor)
    {
        _context.Sensors.Update(sensor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid sensorId)
    {
        var sensor = await GetByIdAsync(sensorId);
        if (sensor != null)
        {
            _context.Sensors.Remove(sensor);
            await _context.SaveChangesAsync();
        }
    }
}