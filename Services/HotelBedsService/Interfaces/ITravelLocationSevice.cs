using ShopifyHotelSourcing.DBModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Services.HotelBedsService.Interfaces
{
    public interface ITravelLocationSevice
    {
        List<Country> GetAllCountries();
        Country GetCountryByCode(string countryCode);
        List<Destination> GetDestinationsByCountryState(string countryCode, string stateCode);
        Destination GetDestinationByCode(string destinationCode);
        List<Destination> GetAllDestinations();
        //List<Hotel> GetHotelListingsByCountryState(string countryCode, string stateCode);
    }
}
