using BuildingSystem.Domain.Models;

namespace BankSystemApp.Interfaces;

public interface ISensorService
{
    Task<Sensor> GetByIdAsync(Guid sensorId, CancellationToken cancellationToken);
    Task<IEnumerable<Sensor>> GetByBuildingIdAsync(Guid buildingId, CancellationToken cancellationToken);
    Task AddAsync(Sensor sensor, CancellationToken cancellationToken);
    Task UpdateAsync(Sensor sensor, CancellationToken cancellationToken);
    Task DeleteAsync(Guid sensorId, CancellationToken cancellationToken);
}