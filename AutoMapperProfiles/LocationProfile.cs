using AutoMapper;
using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.AutoMapperProfiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Destination, DestinationVM>()
                .ForMember(dest => dest.destinationCode, opt => opt.MapFrom(src => src.code))
                .ForMember(dest => dest.destinationName, opt => opt.MapFrom(src => src.name.content))
                .ForMember(dest => dest.countryCode, opt => opt.MapFrom(src => src.countryCode))
                .ReverseMap(); // configure bi-directional mapping capability
        }
    }
}
