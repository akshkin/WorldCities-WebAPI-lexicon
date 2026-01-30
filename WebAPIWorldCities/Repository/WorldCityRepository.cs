using Humanizer;
using Microsoft.EntityFrameworkCore;
using Models;
using WebAPIWorldCities.Data;
using WebAPIWorldCities.DTOs;
using WebAPIWorldCities.Helpers;
using WebAPIWorldCities.Interfaces;
using WebAPIWorldCities.Mappers;
using WebAPIWorldCities.Models;

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
        var cities = _context.WorldCities.Include(c => c.Country).AsQueryable();

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
                CitySortOption.CountryDesc => cities.OrderByDescending(c => c.Country.CountryName),
                CitySortOption.CountryAsc => cities.OrderBy(c => c.Country.CountryName),
                _ => cities.OrderByDescending(c => c.Population)
            };
        }

        var skipNumber = (query.PageNumber - 1) * query.PageSize;

        var citiesDto = cities.Select(c => c.ToWorldCityDto()).Skip(skipNumber).Take(query.PageSize);

        return citiesDto;
    }

    public async Task<WorldCityDto?> GetById(int id)
    {
        var city = await _context.WorldCities.Include(c => c.Country).FirstOrDefaultAsync(c => c.CountryId == id);

        if (city == null) return null;

        return city.ToWorldCityDto();

    }

    public async Task<WorldCity> CreateCity(CreateWorldCityDto cityDto)
    {
        var normalized = Utilities.Normalize(cityDto.Country);

        var country = await GetOrCreateCountry(normalized);

        var newCity = new WorldCity
        {
            CityName = cityDto.CityName,
            Population = cityDto.Population,
            CountryId = country.CountryId
        };

        await _context.WorldCities.AddAsync(newCity);
        await _context.SaveChangesAsync();
        return newCity;
    }

    public async Task<WorldCity?> UpdateCity(int id, UpdateCityDto cityDto)
    {
        var existingCity = await _context.WorldCities.FirstOrDefaultAsync(c => c.CityId == id);

        if (existingCity == null) return null;

        var normalizedCountryName = Utilities.Normalize(cityDto.Country);

        var country = await GetOrCreateCountry(normalizedCountryName);

        existingCity.CityName = cityDto.CityName;
        existingCity.CountryId = country.CountryId;
        existingCity.Population = cityDto.Population;

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

    public async Task<Country> GetOrCreateCountry(string name)
    {
        var country = await _context.Countries
       .FirstOrDefaultAsync(c => c.CountryName == name);

        if (country == null)
        {
            country = new Country { CountryName = name };
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }
        return country;
    } 
}
