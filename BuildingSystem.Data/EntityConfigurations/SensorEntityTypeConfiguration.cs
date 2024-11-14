using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingSystem.Data.EntityConfigurations;

public class SensorEntityTypeConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.ToTable("Sensors");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        builder.Property(s => s.GeoPosition)
            .HasMaxLength(100);

        builder.Property(s => s.PhotoUrl)
            .HasMaxLength(300);

        builder.Property(s => s.MinValue)
            .IsRequired();

        builder.Property(s => s.MaxValue)
            .IsRequired();

        builder.Property(s => s.BatteryThreehold)
            .HasDefaultValue(10)
            .IsRequired();

        builder.HasOne(s => s.Building)
            .WithMany(b => b.Sensors)
            .HasForeignKey(s => s.BuildingId);

        builder.HasMany(s => s.SensorData)
            .WithOne(sd => sd.Sensor)
            .HasForeignKey(sd => sd.SensorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
