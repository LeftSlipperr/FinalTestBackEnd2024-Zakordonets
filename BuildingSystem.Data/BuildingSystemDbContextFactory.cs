using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BuildingSystem.Data;

public class BuildingSystemDbContextFactory : IDesignTimeDbContextFactory<BuildingSystemDbContext>
{
    public BuildingSystemDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BuildingSystemDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5434;Username=postgres;Password=postgres;Database=local");

        return new BuildingSystemDbContext(optionsBuilder.Options);
    }
}