using AutoMapper;
using BankSystemApp.Interfaces;
using BuildingSystem.Data.Storage;
using BuildingSystem.Domain.Models;

namespace BankSystemApp.Services;

public class BuildingService : IBuildingService
{
    private readonly BuildingStorage _storage;
    private readonly IMapper _mapper;

    public BuildingService(BuildingStorage storage, IMapper mapper)
    {
        _storage = storage;
        _mapper = mapper;
    }

    public async Task AddAsync(Building building, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(building.Name))
            throw new ArgumentException("Название здания не может быть пустым.", nameof(building.Name));
        
       await _storage.AddAsync(building);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _storage.DeleteAsync(id);
    }

    public async Task<IEnumerable<Building>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var buildings = await _storage.GetByUserIdAsync(userId);
        return buildings;
    }
}