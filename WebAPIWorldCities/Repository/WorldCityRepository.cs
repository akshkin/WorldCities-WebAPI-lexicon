using Microsoft.EntityFrameworkCore;
using Models;
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

    public async Task<WorldCityDto?> GetById(int id)
    {
        var city = await _context.WorldCities.FindAsync(id);

        if (city == null) return null;

        return city.ToWorldCityDto();

    }

    public async Task<WorldCity> CreateCity(WorldCity city)
    {
        await _context.WorldCities.AddAsync(city);
        await _context.SaveChangesAsync();
        return city;
    }

    public async Task<WorldCity?> UpdateCity(int id, UpdateCityDto city)
    {
        var existingCity = await _context.WorldCities.FirstOrDefaultAsync(c => c.CityId == id);

        if (existingCity == null) return null;

        existingCity.CityName = city.CityName;
        existingCity.Country = city.Country;
        existingCity.Population = city.Population;

        await _context.SaveChangesAsync();

        return existingCity;
    }

    public async Task<WorldCity?> DeleteCity(int id)
    {
        var city = await _context.WorldCities.FirstOrDefaultAsync(c => c.CityId == id);

        if (city == null) return null;

        _context.WorldCities.Remove(city);

        await _context.SaveChangesAsync();

        return city;
    }
}
