using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopifyHotelSourcing.DBModels.Types;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    public class Country
    {
        public string code { get; set; }
        public string isoCode { get; set; }
        public NameModel description { get; set; }
        // Related entity
        public virtual List<State> states { get; set; }
        public virtual List<Destination> destinations { get; set; }
    }
}
