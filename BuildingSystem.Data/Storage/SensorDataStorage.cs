using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingSystem.Data.Storage;

public class SensorDataStorage
{
    private readonly BuildingSystemDbContext _context;

    public SensorDataStorage(BuildingSystemDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(SensorData data)
    {
        await _context.SensorData.AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SensorData>> GetBySensorIdAndDateRangeAsync(Guid sensorId, DateTime startDate, DateTime endDate)
        => await _context.SensorData
            .Where(sd => sd.SensorId == sensorId && sd.Timestamp >= startDate && sd.Timestamp <= endDate)
            .ToListAsync();
}