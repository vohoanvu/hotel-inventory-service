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
        public IStateRepository States { get; private set; }
        public IDestinationRepository Destinations { get; private set; }
        public INameModelRepository NameContents { get; private set; }
        public IZoneRepository Zones { get; private set; }
        public IGroupZoneRepository GroupZones { get; private set; }


        public int Complete() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }
}
