﻿using com.hotelbeds.distribution.hotel_api_model.auto.messages;
using com.hotelbeds.distribution.hotel_api_sdk_core;
using com.hotelbeds.distribution.hotel_api_sdk_core.types;
using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.Services.HotelBedsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Net;
using ShopifyHotelSourcing.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using ShopifyHotelSourcing.Repositories.Interfaces;

namespace ShopifyHotelSourcing.Services.HotelBedsService
{
    public class HotelLocationService : IHotelLocationService
    {
        private const string baseLocationURL = "https://api.test.hotelbeds.com/hotel-content-api/1.0/locations/";
        private string countriesPath = "countries?fields=all&language=ENG&from=1&to=254";
        private string destinationPath = "destinations?fields=all&countryCodes={countryCodes}&language=ENG&from=1&to=100&useSecondaryLanguage=false";
        //private readonly HotelApiClient client = new HotelApiClient(new HotelApiVersion(HotelApiVersion.versions.V1_2), "83b3b9be38b90a41243e7bc6c41949b1", "6ba38be92a");
        private HttpClient myClient;
        private const string MyApiKey = "83b3b9be38b90a41243e7bc6c41949b1";
        private const string MySecret = "6ba38be92a";

        private readonly IUnitOfWork _unitOfWork;

        public HotelLocationService(HttpClient yourClient, IUnitOfWork unitOfWork)
        {
            myClient = yourClient;
            //myClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip });
            _unitOfWork = unitOfWork;
        }

        public CountriesResponse FetchAllCountries()
        {
            var responseResults = new CountriesResponse();

            myClient.BaseAddress = new Uri(baseLocationURL);
            
            //calculate X-Signature
            var MyXSignature = HotelAPIHelpers.GetXSignature(MyApiKey, MySecret); // this function is buggy, FIXED!
            // Add an Accept header for JSON format.
            //myClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //myClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            myClient.DefaultRequestHeaders.Add("Api-Key", MyApiKey);
            myClient.DefaultRequestHeaders.Add("X-Signature", MyXSignature); // brute force for testing
            myClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            myClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json; charset=utf-8");
            //myClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "hotel-api-sdk-net");

            // List data response.
            HttpResponseMessage response = myClient.GetAsync(countriesPath).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                var stringResult = response.Content.ReadAsStringAsync().Result;  
                responseResults = JsonSerializer.Deserialize<CountriesResponse>(stringResult);
                //saving responses into DB
                _unitOfWork.Countries.AddRange(responseResults.countries);
                foreach (var country in responseResults.countries)
                {
                    _unitOfWork.States.AddRange(country.states);
                }
                _unitOfWork.Complete();
            }
            else
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            myClient.Dispose();

            return responseResults;
        }

        public List<State> GetStatesByCountry(string countryCode)
        {
            var states = new List<State>();


            return states;
        }

        public DestinationsResponse FetchDestinations(string countryCodes)
        {
            var results = new DestinationsResponse();
            // prepare for request
            myClient.BaseAddress = new Uri(baseLocationURL);
            var MyXSignature = HotelAPIHelpers.GetXSignature(MyApiKey, MySecret);
            myClient.DefaultRequestHeaders.Add("Api-Key", MyApiKey);
            myClient.DefaultRequestHeaders.Add("X-Signature", MyXSignature); // brute force for testing
            myClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            myClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json; charset=utf-8");

            var newDestinationPath = destinationPath.Replace("{countryCodes}", countryCodes);

            // Making request
            HttpResponseMessage response = myClient.GetAsync(newDestinationPath).Result;
            if (response.IsSuccessStatusCode)
            {
                var stringResult = response.Content.ReadAsStringAsync().Result;
                results = JsonSerializer.Deserialize<DestinationsResponse>(stringResult);
                //saving responses into Postgres DB
                _unitOfWork.Destinations.AddRange(results.destinations);
                _unitOfWork.Complete();
            }
            else
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            myClient.Dispose();

            return results;
        }

        public void ConvertPlaceNametoGeoCoordinates(string placeName)
        {

        }

        public void GetHotelListings()
        {
            /*StatusRS status = client.status();

            if (status != null && status.error == null)
                Console.WriteLine("StatusRS: " + status.status);
            else if (status != null && status.error != null)
            {
                Console.WriteLine("StatusRS: " + status.status + " " + status.error.code + ": " + status.error.message);
                return;
            }
            else if (status == null)
            {
                Console.WriteLine("StatusRS: Is not available.");
                return;
            }*/
        }
    }
}