using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ShopifyHotelSourcing.DBModels.Types;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    public class Destination
    {
        [Key]
        public string code { get; set; }

        [NotMapped]
        public NameModel name { get; set; }
        public string countryCode { get; set; }
        public string isoCode { get; set; }
        public List<Zone> zones { get; set; }
        public List<GroupZone> groupZones { get; set; }

        //Foreign Key and Related Entity
        public Country country { get; set; }
    }
}
