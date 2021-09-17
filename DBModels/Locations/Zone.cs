using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    public class Zone
    {
        public int Id { get; set; }
        public int zoneCode { get; set; }
        public string name { get; set; }
        public NameModel description { get; set; }

        //related Entity model
        public string DestinationCode { get; set; }
        public Destination Destination { get; set; }

        public int GroupZoneID { get; set; }
        public GroupZone GroupZone { get; set; }
    }
}
