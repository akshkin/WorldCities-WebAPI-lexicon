using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIWorldCities.DTOs;
using WebAPIWorldCities.Helpers;
using WebAPIWorldCities.Interfaces;
using WebAPIWorldCities.Mappers;
using WebAPIWorldCities.Models;

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
        public async Task<ActionResult<IEnumerable<WorldCityDto>>> GetAllCities([FromQuery] QueryObject query)
        {
            var cities = await _worldCityRepo.GetAllCities(query);

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCityDto?>> GetCityById([FromRoute] int id)
        {
            var city = await _worldCityRepo.GetById(id);

            if (city == null) return NotFound($"City with id: {id} does not exist");

            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<WorldCityDto>> CreateCity(CreateWorldCityDto cityDto)
        {
           var city = await _worldCityRepo.CreateCity(cityDto);

            return CreatedAtAction(nameof(GetCityById), new { id = city.CityId }, city.ToWorldCityDto());
        }

        //UPDATE city using post method
        [HttpPost("update/{id}")]
        public async Task<ActionResult<WorldCityDto>> UpdateCity(int id,  [FromBody] UpdateCityDto cityDto)
        {
            var existingCity = await _worldCityRepo.UpdateCity(id, cityDto);

            if (existingCity == null) return NotFound($"City with id: {id} does not exist");

            return Ok(existingCity.ToWorldCityDto());
        }

        //DELETE city using post method
        [HttpPost("delete/{id}")]
        public async Task<ActionResult> DeleteCity(int id) 
        {
            var city  = await _worldCityRepo.DeleteCity(id);

            if (city == null) return NotFound($"City with id:{id} does not exist" );

            return Ok("Successfully deleted city");
        }
    }
}
