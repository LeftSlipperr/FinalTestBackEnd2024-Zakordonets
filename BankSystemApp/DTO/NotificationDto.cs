namespace BankSystemApp.DTO;

public class NotificationDto
{
    public Guid Id { get; set; }
    public string RecipientUserId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
}