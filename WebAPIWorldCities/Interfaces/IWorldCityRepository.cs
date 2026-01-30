using Models;
using WebAPIWorldCities.DTOs;
using WebAPIWorldCities.Helpers;

namespace WebAPIWorldCities.Interfaces;

public interface IWorldCityRepository
{
    public Task<IEnumerable<WorldCityDto>> GetAllCities(QueryObject query);

    public Task<WorldCityDto?> GetById(int id);

    public Task<WorldCity> CreateCity(CreateWorldCityDto cityDto);

    public Task<WorldCity?> UpdateCity(int id, UpdateCityDto cityDto);

    public Task<WorldCity?> DeleteCity(int id);
}
