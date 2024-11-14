using AutoMapper;
using BankSystemApp.Interfaces;
using BuildingSystem.Data.Storage;
using BuildingSystem.Domain.Models;

namespace BankSystemApp.Services;

public class NotificationService : INotificationService
{
    private readonly NotificationStorage _storage;
    private readonly IMapper _mapper;

    public NotificationService(NotificationStorage storage, IMapper mapper)
    {
        _storage = storage;
        _mapper = mapper;
    }

    public async Task AddAsync(Notification notification, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(notification.Message))
            throw new ArgumentException("Сообщение не может быть пустым.", nameof(notification.Message));
        
        await _storage.AddAsync(notification);
    }

    public async Task<IEnumerable<Notification>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var notifications = await _storage.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<Notification>>(notifications);
    }
}