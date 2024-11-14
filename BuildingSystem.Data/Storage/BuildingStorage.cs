using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingSystem.Data.Storage;

public class BuildingStorage
{
    private readonly BuildingSystemDbContext _context;

    public BuildingStorage(BuildingSystemDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Building>> GetByUserIdAsync(Guid userId)
        => await _context.Buildings.Where(b => b.UserId == userId).ToListAsync();

    public async Task AddAsync(Building building)
    {
        await _context.Buildings.AddAsync(building);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid buildingId)
    {
        var building = await _context.Buildings.FindAsync(buildingId);
        if (building != null)
        {
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
        }
    }
}