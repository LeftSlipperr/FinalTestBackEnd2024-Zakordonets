using BankSystemApp.Interfaces;
using BuildingSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNotification([FromBody] Notification notification, CancellationToken cancellationToken)
    {
        if (notification == null)
        {
            return BadRequest("Notification cannot be null.");
        }

        await _notificationService.AddAsync(notification, cancellationToken);
        return NoContent();
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetNotifications([FromRoute] Guid userId)
    {
        var notifications = await _notificationService.GetByUserIdAsync(userId, CancellationToken.None);
        return Ok(notifications);
    }
}