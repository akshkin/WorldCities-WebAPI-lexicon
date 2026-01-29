using Models;
using WebAPIWorldCities.DTOs;

namespace WebAPIWorldCities.Interfaces;

public interface IWorldCityRepository
{
    public Task<IEnumerable<WorldCityDto>> GetAllCities();
    
}
