namespace BuildingSystem.Domain.Models;

public class Notification
{
    public Guid Id { get; set; }
    public string RecipientUserId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
}