
namespace WebAPIWorldCities.Helpers;

public class QueryObject
{
    public string? Country { get; set; }

    public string? Name { get; set; }

    public int? PopulationGreaterThan { get; set; }

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 20;

    public CitySortOption? SortBy { get; set; } = CitySortOption.PopulationDesc;
}
