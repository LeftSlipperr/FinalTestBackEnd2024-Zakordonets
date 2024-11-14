using BuildingSystem.Domain.Models;

namespace BankSystemApp.Interfaces;

public interface INotificationStorage
{
    Task AddAsync(Notification notification);
    Task<IEnumerable<Notification>> GetByUserIdAsync(Guid userId);

}