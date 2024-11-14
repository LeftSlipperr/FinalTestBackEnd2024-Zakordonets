using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingSystem.Data.EntityConfigurations;

public class SensorDataEntityTypeConfiguration : IEntityTypeConfiguration<SensorData>
{
    public void Configure(EntityTypeBuilder<SensorData> builder)
    {
        builder.ToTable("SensorData");

        builder.HasKey(sd => sd.Id);
        builder.Property(sd => sd.Id).ValueGeneratedOnAdd();

        builder.Property(sd => sd.Timestamp)
            .IsRequired();

        builder.Property(sd => sd.Temperature)
            .IsRequired();

        builder.Property(sd => sd.Humidity)
            .IsRequired();

        builder.Property(sd => sd.BatteryLevel)
            .IsRequired();

        builder.HasOne(sd => sd.Sensor)
            .WithMany(s => s.SensorData)
            .HasForeignKey(sd => sd.SensorId);
    }

}