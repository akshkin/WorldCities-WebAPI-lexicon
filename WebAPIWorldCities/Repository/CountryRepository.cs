using Microsoft.EntityFrameworkCore;
using WebAPIWorldCities.Data;
using WebAPIWorldCities.DTOs.Country;
using WebAPIWorldCities.Interfaces;
using WebAPIWorldCities.Mappers;

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
}
