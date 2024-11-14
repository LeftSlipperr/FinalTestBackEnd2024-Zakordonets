using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingSystem.Data.Storage;

public class NotificationStorage
{
    private readonly BuildingSystemDbContext _context;

    public NotificationStorage(BuildingSystemDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Notification>> GetByUserIdAsync(Guid userId)
        => await _context.Notifications.Where(n => n.Id == userId).ToListAsync();
}