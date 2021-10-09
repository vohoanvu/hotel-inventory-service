using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ITravelLocationSevice _travelLocationService;

        public LocationsController(ITravelLocationSevice travelLocationService)
        {
            _travelLocationService = travelLocationService;
        }


        // GET: api/<LocationsController>
        [HttpGet("get-all-countries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCountries()
        {
            var response = await _travelLocationService.GetAllCountries();
            if (response == null)
            {
                return NotFound(response);
            }
            response.Message = $"There are a total of {response.Data.Count} countries";

            return Ok(response);
        }

        // GET api/<LocationsController>/US
        [HttpGet("Get-Country-By-Code/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCountryByCode(string code)
        {
            var response = _travelLocationService.GetCountryByCode(code);
            return response == null ? NotFound(response) : Ok(response);
        }

        // POST api/<LocationsController>/MX
        [HttpGet("Get-Destinations-By-Country/{countryCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDestinationsByCountry(string countryCode)
        {
            var response = await _travelLocationService.GetDestinationsNamesByCountryCode(countryCode);
            if (response == null)
            {
                return NotFound(response);
            }
            response.Message = $"There are a total of {response.Data.Count} travel destination in this country";

            return Ok(response);
        }


        // POST api/<LocationsController>/OAX
        [HttpGet("Get-Destinations-by-Id/{destinationCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDestinationsByCode(string destinationCode)
        {
            var response = _travelLocationService.GetDestinationByCode(destinationCode);

            return response == null ? NotFound(response) : Ok(response);
        }
    }
}
