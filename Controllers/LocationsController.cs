using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopifyHotelSourcing.Repositories;
using ShopifyHotelSourcing.Services.HotelBedsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopifyHotelSourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IHotelClient hotelBedService; 

        public LocationsController(IHotelClient hotelBedsService)
        {
            hotelBedService = hotelBedsService;
        }
        // GET: api/<LocationsController>/countries
        [HttpGet("countries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCountries()
        {
            var hotelBedsCountries = hotelBedService.GetAllCountries();

            return Ok(hotelBedsCountries);
        }

        // GET api/<LocationsController>/destinations
        [HttpGet("destinations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetDestinations(string countryCodes)
        {
            var hotelBedsDestinations = new DestinationsResponse();
            try
            {
                hotelBedsDestinations = hotelBedService.GetDestinations(countryCodes);
            }
            catch (Exception)
            {
                throw;
            }
            
            return Ok(hotelBedsDestinations);  
        }

        // POST api/<CountriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
