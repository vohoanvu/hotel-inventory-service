using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    public class GroupZone
    {
        public int Id { get; set; }
        public string groupZoneCode { get; set; }
        public NameModel name { get; set; }
        public List<int> zones { get; set; }

        // related entity
        public string DestinationCode { get; set; }
        public Destination Destination { get; set; }

        public List<Zone> ZonesList { get; set; }
    }
}
