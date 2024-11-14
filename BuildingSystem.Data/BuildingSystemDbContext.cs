using System.Reflection;
using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingSystem.Data;

public class BuildingSystemDbContext : DbContext
{
    public DbSet<Building> Buildings => Set<Building>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<SensorData> SensorData => Set<SensorData>();
    public DbSet<User> Users => Set<User>();

    public BuildingSystemDbContext(DbContextOptions<BuildingSystemDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var assembly = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}