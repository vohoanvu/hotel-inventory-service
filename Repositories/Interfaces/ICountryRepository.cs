using ShopifyHotelSourcing.DBModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Repositories.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        //extending CountryRepo here..
    }
}
