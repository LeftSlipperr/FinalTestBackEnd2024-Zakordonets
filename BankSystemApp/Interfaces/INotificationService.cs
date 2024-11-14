using BuildingSystem.Domain.Models;

namespace BankSystemApp.Interfaces;

public interface INotificationService
{
    Task AddAsync(Notification notification, CancellationToken cancellationToken);
    Task<IEnumerable<Notification>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}