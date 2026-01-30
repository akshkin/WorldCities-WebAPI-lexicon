using Models;

namespace WebAPIWorldCities.DTOs.Country;

public class CountryWithCitiesDto
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public List<WorldCity> Cities { get; set; }
}
