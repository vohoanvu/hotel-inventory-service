using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopifyHotelSourcing.DBModels.Types;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    public class Destination
    {
        public string Code { get; set; }
        public NameModel Name { get; set; }
        public string CountryCode { get; set; }
        public string IsoCode { get; set; }
        public List<Zone> zones { get; set; }
        public List<GroupZone> groupZones { get; set; }
    }
}
