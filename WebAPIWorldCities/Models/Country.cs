using Models;
using System.ComponentModel.DataAnnotations;
using WebAPIWorldCities.Helpers;

namespace WebAPIWorldCities.Models;

public class Country
{
    public int CountryId { get; set; }

    private string _countryName = string.Empty;

    [Required]
    [MinLength(2, ErrorMessage = "Country name must be at least 2 characters long.")]
    [MaxLength(100, ErrorMessage = "Country name cannot exceed 100 characters.")]
    public string CountryName 
    { 
        get => _countryName; 
        set => _countryName = Utilities.Normalize(_countryName); 
    }

    public List<WorldCity> Cities { get; set; } = new List<WorldCity>();
}
