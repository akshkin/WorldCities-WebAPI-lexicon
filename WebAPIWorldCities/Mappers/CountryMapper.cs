using WebAPIWorldCities.DTOs.Country;
using WebAPIWorldCities.Models;

namespace WebAPIWorldCities.Mappers;

public static class CountryMapper
{
    public static CountryDto ToCountryDto(this Country country)
    {
        return new CountryDto
        {
            CountryId = country.CountryId,
            CountryName = country.CountryName,
        };
    }

    public static Country ToCountryFromDto(this CreateCountryDto countryDto, int countryId)
    {
        return new Country
        {
            CountryId = countryId,
            CountryName = countryDto.CountryName,
        };
    }
}
