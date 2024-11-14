using BuildingSystem.Domain.Models;

namespace BankSystemApp.Interfaces;

public interface IUserService
{
    Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
    Task DeleteAsync(Guid userId, CancellationToken cancellationToken);
}