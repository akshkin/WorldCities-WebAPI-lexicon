using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIWorldCities.DTOs.Country;
using WebAPIWorldCities.Interfaces;
using WebAPIWorldCities.Mappers;
using WebAPIWorldCities.Models;

namespace WebAPIWorldCities.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepo;

        public CountriesController(ICountryRepository countryRepo)
        {
            _countryRepo = countryRepo;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
        {
            var countries = await _countryRepo.GetAllCountries();
            return Ok(countries);
        }

        //GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto?>> GetCountry(int id)
        {
            var country = await _countryRepo.GetCountryById(id);

            if (country == null)
            {
                return NotFound($"Country with id: {id} does not exist");
            }

            return Ok(country);
        }

        // UPDATE a country using POST
       [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, UpdateCountryDto countryDto)
        {
            try
            {
                var existingCountry = await _countryRepo.UpdateCountry(id, countryDto);

                if (existingCountry == null) return NotFound($"Country with id: {id} not found.");

                return Ok(existingCountry.ToCountryDto());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(CreateCountryDto countryDto)
        {
            var country = await _countryRepo.CreateCountry(countryDto);
           
            return CreatedAtAction(nameof(GetCountry), new { id = country.CountryId }, country.ToCountryDto());
        }

        // DELETE a country using POST 
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                var country = await _countryRepo.DeleteCountry(id);

                if (country == null)
                {
                    return NotFound();
                }

                return NoContent();

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
