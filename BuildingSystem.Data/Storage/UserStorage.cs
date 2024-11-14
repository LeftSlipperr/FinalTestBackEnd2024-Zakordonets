using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingSystem.Data.Storage;

public class UserStorage
{
    private readonly BuildingSystemDbContext _context;

    public UserStorage(BuildingSystemDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(Guid userId)
        => await _context.Users.FindAsync(userId);

    public async Task<IEnumerable<User>> GetAllAsync()
        => await _context.Users.ToListAsync();

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await GetByIdAsync(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}