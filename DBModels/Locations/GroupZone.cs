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
        public string GroupZoneCode { get; set; }
        public NameModel Name { get; set; }
        public virtual List<int> zonesCodes { get; set; }
    }
}
