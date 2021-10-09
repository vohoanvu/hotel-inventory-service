﻿#nullable enable
using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.Repositories.Interfaces;
using ShopifyHotelSourcing.Services.HotelBedsService.Interfaces;
using ShopifyHotelSourcing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Services.HotelBedsService
{
    public class TravelLocationService : ITravelLocationSevice
    {
        private readonly IUnitOfWork _unitOfWork;

        public TravelLocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<List<Country>>> GetAllCountries()
        {
            var serviceResponse = new ServiceResponse<List<Country>>();

            var results = await _unitOfWork.Countries.GetAllAsync();
            if (results != null)
            {
                serviceResponse.Data = results.OrderBy(c => c.code).ToList();
            } 
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There are NO countries in database";
            }


            return serviceResponse;
        }

        public ServiceResponse<Country> GetCountryByCode(string countryCode)
        {
            var serviceResponse = new ServiceResponse<Country>();

            serviceResponse.Data = _unitOfWork.Countries.GetById(countryCode);

            return serviceResponse;
        }

        public ServiceResponse<Destination> GetDestinationByCode(string destinationCode)
        {
            var serviceResponse = new ServiceResponse<Destination>();
            serviceResponse.Data = _unitOfWork.Destinations.GetById(destinationCode);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Destination>>> GetAllDestinations()
        {
            var serviceResponse = new ServiceResponse<List<Destination>>();

            var results = await _unitOfWork.Destinations.GetAllAsync();
            if (results != null)
            {
                serviceResponse.Data = results.OrderBy(d => d.name.content).ToList();
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There are NO destinations in database";
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DestinationVM>>> GetDestinationsNamesByCountryCode(string countryCode)
        {
            var serviceResponse = new ServiceResponse<List<DestinationVM>>();
            // Retrieve a list of Destination by country
            var destinations = await _unitOfWork.Destinations.FindByCondition(d => d.countryCode == countryCode);

            if (destinations != null)
            {
                serviceResponse.Data = destinations.Select(d => new DestinationVM
                                                                    {
                                                                       destinationCode = d.code,
                                                                       destinationName = d.name.content,
                                                                       countryCode = d.countryCode
                                                                    }).ToList();
            } 
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There are no existing destinations with your country code!";
            }

            return serviceResponse;
        }
    }
}
