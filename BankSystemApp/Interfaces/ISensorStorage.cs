using BuildingSystem.Domain.Models;

namespace BankSystemApp.Interfaces;

public interface ISensorStorage
{
    Task<Sensor> GetByIdAsync(Guid sensorId);
    Task<IEnumerable<Sensor>> GetByBuildingIdAsync(Guid buildingId);
    Task AddAsync(Sensor sensor);
    Task UpdateAsync(Sensor sensor);
    Task DeleteAsync(Guid sensorId);
}