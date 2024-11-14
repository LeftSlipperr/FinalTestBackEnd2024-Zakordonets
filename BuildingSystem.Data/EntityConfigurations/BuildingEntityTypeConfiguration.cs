using BuildingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingSystem.Data.EntityConfigurations;

public class BuildingEntityTypeConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.ToTable("Buildings");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        builder.Property(b => b.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.Address)
            .HasMaxLength(300);

        builder.HasOne(b => b.User)
            .WithMany(u => u.Buildings)
            .HasForeignKey(b => b.UserId);

        builder.HasMany(b => b.Sensors)
            .WithOne(s => s.Building)
            .HasForeignKey(s => s.BuildingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
