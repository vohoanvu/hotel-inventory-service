using ShopifyHotelSourcing.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;

        public ICountryRepository Countries { get; private set; }
        public IDestinationRepository Destinations { get; private set; }


        public UnitOfWork(DBContext context)
        {
            _context = context;
            Countries = new CountryRepository(context);
            Destinations = new DestinationRepository(context);
        }

        public int Complete() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }
}
