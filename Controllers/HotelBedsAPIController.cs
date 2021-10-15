using com.hotelbeds.distribution.hotel_api_model.auto.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopifyHotelSourcing.APIHotelResponseModel;
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
    public class HotelBedsAPIController : ControllerBase
    {
        private readonly IHotelApiContentService hotelBedService; 

        public HotelBedsAPIController(IHotelApiContentService hotelBedsService)
        {
            hotelBedService = hotelBedsService;
        }
        // GET: api/<LocationsController>/countries
        [HttpGet("fetch-countries-into-DB")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult FetchCountries()
        {
            var hotelBedsCountries = hotelBedService.FetchAllCountries();

            return Ok(hotelBedsCountries);
        }

        // GET api/<LocationsController>/destinations
        [HttpGet("fetch-destinations-into-DB")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult FetchDestinations(string countryCodes, int from, int to)
        {
            var hotelBedsDestinations = new DestinationsResponse();
            try
            {
                hotelBedsDestinations = hotelBedService.FetchDestinations(countryCodes, from, to);
            }
            catch (Exception)
            {
                throw;
            }
            
            return Ok(hotelBedsDestinations);
        }

        // Fetch Hotel Availability Sample in Console
        [HttpGet("availability-sample-check")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAvalability()
        {
            var resultResponse = new List<string>();
            resultResponse = hotelBedService.CheckAvailability();

            return Ok(resultResponse);
        }

        // PUT api/<CountriesController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
