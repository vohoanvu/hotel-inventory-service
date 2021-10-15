using ShopifyHotelSourcing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.hotelbeds.distribution.hotel_api_sdk_core;
using ShopifyHotelSourcing.APIHotelResponseModel;

namespace ShopifyHotelSourcing.Services.HotelBedsService.Interfaces
{
    public interface IHotelApiContentService
    {
        CountriesResponse FetchAllCountries();

        DestinationsResponse FetchDestinations(string countryCodes, int from, int to);

        List<string> CheckAvailability();

        void SaveCountriesResponseToDB(CountriesResponse countriesResponse);

        void SaveDestinationsResponseToDB(DestinationsResponse destinationsResponse);

    }
}
