using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICountryRepository Countries { get; }
        IDestinationRepository Destinations { get; }

        int Complete();
    }
}
