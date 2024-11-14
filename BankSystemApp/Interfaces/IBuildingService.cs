using BuildingSystem.Domain.Models;

namespace BankSystemApp.Interfaces;

public interface IBuildingService
{
    Task<IEnumerable<Building>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task AddAsync(Building building, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid buildingId, CancellationToken cancellationToken = default);
}