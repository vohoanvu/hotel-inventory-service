using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Services.HotelBedsService.Interfaces
{
    public interface IHotelAPIService
    {
        CountriesResponse FetchAllCountries();

        DestinationsResponse FetchDestinations(string countryCodes, int from, int to);

        void FetchHotelListings();

        void SaveCountriesResponseToDB(CountriesResponse countriesResponse);

        void SaveDestinationsResponseToDB(DestinationsResponse destinationsResponse);

    }
}
