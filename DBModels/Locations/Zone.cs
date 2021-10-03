using Microsoft.EntityFrameworkCore;
using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    [Owned]
    public class Zone
    {
        public int zoneCode { get; set; }
        public string name { get; set; }

        public NameModel description { get; set; }

        //related Entity model
        //public string DestinationCode { get; set; }
        //public Destination Destination { get; set; }

        //public int GroupZoneID { get; set; }
        //public GroupZone GroupZone { get; set; }
    }
}
