﻿using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Services.HotelBedsService.Interfaces
{
    public interface IHotelClient
    {
        CountriesResponse GetAllCountries();
        List<Destination> FilterDestinationsByCountryAndState(string countryCode, string stateCode);
        List<State> GetStatesByCountry(string countryCode);
        void GetHotelListings();
        void ConvertPlaceNametoGeoCoordinates(string placeName);
    }
}