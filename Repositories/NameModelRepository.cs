using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.DBModels.Types;
using ShopifyHotelSourcing.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Repositories
{
    public class NameModelRepository : GenericRepository<NameModel>, INameModelRepository
    {
        public NameModelRepository(DBContext context) : base(context)
        {
        }
    }
}
