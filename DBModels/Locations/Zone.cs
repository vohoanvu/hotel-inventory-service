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
        public int ZoneCode { get; set; }
        public string Name { get; set; }
        public NameModel Description { get; set; }
    }
}
