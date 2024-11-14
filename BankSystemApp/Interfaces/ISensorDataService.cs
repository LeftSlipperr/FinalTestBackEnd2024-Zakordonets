using BuildingSystem.Domain.Models;

namespace BankSystemApp.Interfaces;

public interface ISensorDataService
{
    Task AddAsync(SensorData data, CancellationToken cancellationToken);
    Task<IEnumerable<SensorData>> GetBySensorIdAndDateRangeAsync(Guid sensorId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
}