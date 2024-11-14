namespace BuildingSystem.Domain.Models;

public class Building
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Guid UserId { get; set; }
    public List<Sensor> Sensors { get; set; } = new List<Sensor>();
    public User User { get; set; }
}