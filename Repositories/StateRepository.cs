using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(DBContext context) : base(context)
        {
        }
    }
}
