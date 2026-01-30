using System.ComponentModel.DataAnnotations;
using WebAPIWorldCities.Helpers;
using WebAPIWorldCities.Models;

namespace Models;

public class WorldCity
{
    [Key]
    public int CityId { get; set; }

    private string _cityName = string.Empty;

    [Required]
    [MinLength(2, ErrorMessage ="City name must be at least 2 characters long.")]
    [MaxLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
    public string CityName 
    { 
        get => _cityName; 
        set => _cityName = Utilities.Normalize(value);    
    }

    [Required]
    public int CountryId { get; set; }

    public Country Country { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Population must be a non-negative integer.")]
    public int Population { get; set; }
}
