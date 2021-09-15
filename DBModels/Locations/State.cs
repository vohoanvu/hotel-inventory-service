using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    public class State
    {
        public string code { get; set; }
        public string name { get; set; }

        //Foreign Key
        public string countryCode { get; set; }
        public virtual Country country { get; set; }
    }
}
