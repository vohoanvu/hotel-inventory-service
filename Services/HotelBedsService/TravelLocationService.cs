#nullable enable
using AutoMapper;
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
        private readonly IMapper _mapper;

        public TravelLocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
                serviceResponse.Data = destinations.Select(d => _mapper.Map<DestinationVM>(d) ).ToList();
            } 
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There are no existing destinations with your country code!";
            }

            return serviceResponse;
        }


        public ServiceResponse<List<DestinationVM>> SearchDestinationsByName(string destinationKeyword)
        {
            var result = new ServiceResponse<List<DestinationVM>>();

            try
            {
                var destinationsInDB = _unitOfWork.Destinations.GetAllAsNoTracking().ToList();
                //(d => CheckforNameMatches(d, destinationKeyword))
                result.Data = destinationsInDB.Where(d => CheckforNameMatches(d, destinationKeyword))
                                                .Select(d => _mapper.Map<DestinationVM>(d) ).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        // should be placed inside Helper folder
        public bool CheckforNameMatches(Destination destination, string keyword)
        {
            var loweredSearch = keyword.ToLower();
            if (destination.name.content.ToLower().Contains(loweredSearch))
                return true;
            else
            {
                var zonesMatched = destination.zones.Where(z => z.name.ToLower().Contains(loweredSearch));
                if (zonesMatched.Any() && zonesMatched != null)
                    return true;
                else
                {
                    var groupZonesMatched = destination.groupZones.Where(gz => gz.name.content.ToLower().Contains(loweredSearch));
                    return (groupZonesMatched.Any() && groupZonesMatched != null);
                }
            }
        }
    }
}
