using System.ComponentModel.DataAnnotations;
using WebAPIWorldCities.Helpers;

namespace WebAPIWorldCities.DTOs.Country;

public class UpdateCountryDto
{
    private string _countryName;

    [Required]
    [MinLength(2, ErrorMessage = "Country name must be at least 2 characters long.")]
    [MaxLength(100, ErrorMessage = "Country name cannot exceed 100 characters.")]
    public string CountryName
    {
        get => _countryName;
        set => _countryName = Utilities.Normalize(value);
    }
}
