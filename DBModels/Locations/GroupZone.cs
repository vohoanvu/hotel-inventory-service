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
    public class GroupZone
    {
        public string groupZoneCode { get; set; }

        public NameModel name { get; set; }
        public List<int> zones { get; set; }

        // related entity
        //public string DestinationCode { get; set; }
        //public Destination Destination { get; set; }

        //public List<Zone> ZonesList { get; set; }
    }
}
