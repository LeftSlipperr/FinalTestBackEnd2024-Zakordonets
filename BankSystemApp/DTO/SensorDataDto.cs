using BuildingSystem.Domain.Models;

namespace BankSystemApp.DTO;

public class SensorDataDto
{
    public Guid Id { get; set; }
    public Guid SensorId { get; set; }
    public DateTime Timestamp { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public int BatteryLevel { get; set; }
    public Sensor Sensor { get; set; }
}