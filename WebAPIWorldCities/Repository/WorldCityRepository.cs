using Microsoft.EntityFrameworkCore;
using WebAPIWorldCities.Data;
using WebAPIWorldCities.DTOs;
using WebAPIWorldCities.Interfaces;
using WebAPIWorldCities.Mappers;

namespace WebAPIWorldCities.Repository;

public class WorldCityRepository : IWorldCityRepository
{
    private readonly ApplicationDbContext _context;

    public WorldCityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorldCityDto>> GetAllCities()
    {
        var cities = await _context.WorldCities.ToListAsync();

        var citiesDto = cities.Select(c => c.ToWorldCityDto());

        return citiesDto;
    }
}
