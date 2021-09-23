using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ShopifyHotelSourcing.DBModels.Types;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    public class Country
    {
        [Key]
        public string code { get; set; }
        public string isoCode { get; set; }
        [NotMapped]
        public NameModel description { get; set; }
        // Related entity
        public virtual List<State> states { get; set; }
        public virtual List<Destination> destinations { get; set; }
    }
}
