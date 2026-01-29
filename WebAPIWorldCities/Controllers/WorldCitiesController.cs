using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIWorldCities.Data;
using WebAPIWorldCities.DTOs;
using WebAPIWorldCities.Interfaces;

namespace WebAPIWorldCities.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class WorldCitiesController : ControllerBase
    {
        private readonly IWorldCityRepository _worldCityRepo;

        public WorldCitiesController(IWorldCityRepository worldCityRepo)
        {
            _worldCityRepo = worldCityRepo;
        }

        // GET: api/WorldCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldCityDto>>> GetAllCities()
        {
            var cities = await _worldCityRepo.GetAllCities();

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCityDto?>> GetCityById([FromRoute] int id)
        {
            var city = await _worldCityRepo.GetById(id);

            if (city == null) return NotFound($"City with id {id} does not exist");

            return Ok(city);
        }
    }
}
