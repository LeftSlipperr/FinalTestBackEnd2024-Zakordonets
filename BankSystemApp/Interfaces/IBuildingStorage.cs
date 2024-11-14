using BuildingSystem.Domain.Models;

namespace BankSystemApp.Interfaces;

public interface IBuildingStorage
{
    Task<IEnumerable<Building>> GetByUserIdAsync(Guid userId);
    Task AddAsync(Building building);
    Task DeleteAsync(Guid buildingId);

}