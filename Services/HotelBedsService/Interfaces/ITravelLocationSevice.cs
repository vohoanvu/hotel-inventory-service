using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Services.HotelBedsService.Interfaces
{
    public interface ITravelLocationSevice
    {
        Task<ServiceResponse<List<Country>>> GetAllCountries();
        ServiceResponse<Country> GetCountryByCode(string countryCode);

        ServiceResponse<Destination> GetDestinationByCode(string destinationCode);
        Task<ServiceResponse<List<Destination>>> GetAllDestinations();
        Task<ServiceResponse<List<DestinationVM>>> GetDestinationsNamesByCountryCode(string countryCode);
        ServiceResponse<List<DestinationVM>> SearchDestinationsByName(string destinationKeyword);
        //ServiceResponse<List<DestinationVM>> SearchDestinatinosByNameAndCountry(string countryCode, string destinationKeyword);
        //List<Hotel> GetHotelListingsByCountryState(string countryCode, string stateCode);
    }
}
