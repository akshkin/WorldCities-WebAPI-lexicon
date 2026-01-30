using WebAPIWorldCities.DTOs.Country;

namespace WebAPIWorldCities.Interfaces;

public interface ICountryRepository
{
    public Task<IEnumerable<CountryDto>> GetAllCountries();
}
