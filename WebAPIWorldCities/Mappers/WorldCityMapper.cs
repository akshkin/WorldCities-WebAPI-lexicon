using Models;
using WebAPIWorldCities.DTOs;

namespace WebAPIWorldCities.Mappers;

public static class WorldCityMapper
{
    public static WorldCityDto ToWorldCityDto(this WorldCity city)
    {
        return new WorldCityDto
        {
            CityId = city.CityId,
            CityName = city.CityName,
            Country = city.Country,
            Population = city.Population,
        };
    }

    public static WorldCity ToCityFromDto(this CreateWorldCityDto worldCityDto) 
    {
        return new WorldCity
        {
            CityName = worldCityDto.CityName,
            Country = worldCityDto.Country,
            Population = worldCityDto.Population,
        };
    }
}
