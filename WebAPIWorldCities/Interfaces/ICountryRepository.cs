using WebAPIWorldCities.DTOs.Country;
using WebAPIWorldCities.Models;

namespace WebAPIWorldCities.Interfaces;

public interface ICountryRepository
{
    public Task<IEnumerable<CountryDto>> GetAllCountries();

    public Task<CountryDto> GetCountryById(int id);

    public Task<Country> CreateCountry(CreateCountryDto createCountryDto);

    public Task<Country?> UpdateCountry(int id, UpdateCountryDto countryDto);

    public Task<Country?> DeleteCountry(int id);
}
