using Microsoft.EntityFrameworkCore;
using Models;
using WebAPIWorldCities.Data;
using WebAPIWorldCities.DTOs;
using WebAPIWorldCities.Helpers;
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

    public async Task<IEnumerable<WorldCityDto>> GetAllCities(QueryObject query)
    {
        var cities = _context.WorldCities.AsQueryable();

        if (!string.IsNullOrEmpty(query.Name))
        {
            cities = cities.Where(c => c.CityName.Contains(query.Name));
        }

        if (!string.IsNullOrEmpty(query.Country))
        {
            cities = cities.Where(c => c.Country.CountryName.Contains(query.Country));
        }

        if (query.PopulationGreaterThan != null)
        {
            cities = cities.Where(c => c.Population >  query.PopulationGreaterThan);
        }

        if (query.SortBy != null) 
        {
            cities = query.SortBy switch
            {
                CitySortOption.PopulationDesc => cities.OrderByDescending(c => c.Population),
                CitySortOption.PopulationAsc => cities.OrderBy(c => c.Population),
                CitySortOption.NameDesc => cities.OrderByDescending(c => c.CityName),
                CitySortOption.NameAsc=> cities.OrderBy(c => c.CityName),
                CitySortOption.CountryDesc => cities.OrderByDescending(c => c.Country),
                CitySortOption.CountryAsc => cities.OrderBy(c => c.Country),
                _ => cities.OrderByDescending(c => c.Population)
            };
        }

        var skipNumber = (query.PageNumber - 1) * query.PageSize;

        var citiesDto = cities.Select(c => c.ToWorldCityDto()).Skip(skipNumber).Take(query.PageSize);

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
        //existingCity.CountryId = city.CountryId;
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
