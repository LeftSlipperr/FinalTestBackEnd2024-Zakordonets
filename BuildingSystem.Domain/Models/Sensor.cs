namespace BuildingSystem.Domain.Models;

public class Sensor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string GeoPosition { get; set; }
    public string PhotoUrl { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
    public int BatteryThreehold {get; set;}
    public Guid BuildingId { get; set; }
    public List<SensorData> SensorData { get; set; }
    public Building Building { get; set; }
    
}