using System.ComponentModel.DataAnnotations;

namespace Models;

public class WorldCity
{
    [Key]
    public int CityId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage ="City name must be at least 2 characters long.")]
    [MaxLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
    public string CityName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage ="Country name must be at least 2 characters long.")]
    [MaxLength(100, ErrorMessage = "Country name cannot exceed 100 characters.")]
    public string Country { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Population must be a non-negative integer.")]
    public int Population { get; set; }
}
