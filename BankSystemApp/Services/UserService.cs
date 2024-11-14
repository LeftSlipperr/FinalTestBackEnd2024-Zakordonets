using AutoMapper;
using BankSystemApp.Interfaces;
using BuildingSystem.Data.Storage;
using BuildingSystem.Domain.Models;

namespace BankSystemApp.Services;

public class UserService : IUserService
{
private readonly UserStorage _storage;
private readonly IMapper _mapper;

public UserService(UserStorage storage, IMapper mapper)
{
    _storage = storage;
    _mapper = mapper;
}

    public async Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _storage.GetByIdAsync(userId);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _storage.GetAllAsync();
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _storage.AddAsync(user);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        await _storage.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken)
    {
        await _storage.DeleteAsync(userId);
    }
}