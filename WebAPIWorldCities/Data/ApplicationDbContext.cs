using Microsoft.EntityFrameworkCore;
using Models;

namespace WebAPIWorldCities.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    public DbSet<WorldCity> WorldCities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WorldCity>().HasData(
            new WorldCity
            {
                CityId = 1,
                CityName = "Gdansk",
                Country = "Poland",
                Population = 487370
            },
            new WorldCity
            {
                CityId = 2,
                CityName = "Malmö",
                Country = "Sweden",
                Population = 339320
            },
            new WorldCity
            {
                CityId = 3,
                CityName = "Bergen",
                Country = "Norway",
                Population = 294029
            }
        );
    }
}
