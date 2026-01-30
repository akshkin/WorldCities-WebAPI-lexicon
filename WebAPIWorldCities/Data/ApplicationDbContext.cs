using Microsoft.EntityFrameworkCore;
using Models;
using WebAPIWorldCities.Models;

namespace WebAPIWorldCities.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    public DbSet<WorldCity> WorldCities { get; set; }

    public DbSet<Country> Countries { get; set;  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().HasData(
            new Country { CountryId = 1, CountryName = "Sweden" },
            new Country { CountryId = 2, CountryName = "Denmark" },
            new Country { CountryId = 3, CountryName = "Poland" },
            new Country { CountryId = 4, CountryName = "Norway" }
        );

        modelBuilder.Entity<WorldCity>().HasData(
            new WorldCity
            {
                CityId = 1,
                CityName = "Gdansk",
                CountryId = 3,
                Population = 487370
            },
            new WorldCity
            {
                CityId = 2,
                CityName = "Malmö",
                CountryId = 1,
                Population = 339320
            },
            new WorldCity
            {
                CityId = 3,
                CityName = "Bergen",
                CountryId = 4,
                Population = 294029
            }
        );
    }
}
