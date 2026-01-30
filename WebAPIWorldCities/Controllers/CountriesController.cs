using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIWorldCities.Data;
using WebAPIWorldCities.DTOs.Country;
using WebAPIWorldCities.Interfaces;
using WebAPIWorldCities.Mappers;
using WebAPIWorldCities.Models;
using WebAPIWorldCities.Repository;

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

        //    // PUT: api/Countries/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutCountry(int id, Country country)
        //    {
        //        if (id != country.CountryId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(country).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CountryExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto countryDto)
        {
            var country = await _countryRepo.CreateCountry(countryDto);
           
            return CreatedAtAction(nameof(GetCountry), new { id = country.CountryId }, country.ToCountryDto());
        }

        //    // DELETE: api/Countries/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteCountry(int id)
        //    {
        //        var country = await _context.Countries.FindAsync(id);
        //        if (country == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Countries.Remove(country);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool CountryExists(int id)
        //    {
        //        return _context.Countries.Any(e => e.CountryId == id);
        //    }
    }
}
