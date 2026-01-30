using Microsoft.EntityFrameworkCore;
using WebAPIWorldCities.Data;
using WebAPIWorldCities.DTOs.Country;
using WebAPIWorldCities.Helpers;
using WebAPIWorldCities.Interfaces;
using WebAPIWorldCities.Mappers;
using WebAPIWorldCities.Models;

namespace WebAPIWorldCities.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _context;
    public CountryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CountryDto>> GetAllCountries()
    {
        var countries = await _context.Countries.ToListAsync();
        return countries.Select(c => c.ToCountryDto());
    }

    public async Task<CountryDto?> GetCountryById(int id)
    {
        var country = await _context.Countries.FindAsync(id);

        if (country == null) return null;

        return country.ToCountryDto();
    }

    public async Task<Country> CreateCountry(CreateCountryDto createCountryDto)
    {
        var normalizedCountryName = Utilities.Normalize(createCountryDto.CountryName);

        var country = await GetOrCreateCountry(normalizedCountryName);

        return country;
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

    public async Task<Country?> UpdateCountry(int id, UpdateCountryDto countryDto)
    {
        var existingCountry = await _context.Countries.FirstOrDefaultAsync(c => c.CountryId == id);

        if (existingCountry == null) return null;
      
        var normalizedCountryName = Utilities.Normalize(countryDto.CountryName);

        //check if another country with same name exists
        var duplicateCountry = await _context.Countries.AnyAsync(c => c.CountryName == normalizedCountryName && c.CountryId != id);

        if (duplicateCountry) return null;

        existingCountry.CountryName = normalizedCountryName;
        await _context.SaveChangesAsync();

        return existingCountry;

    }
}
