using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopifyHotelSourcing.DBModels.Types;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    public class Country
    {
        public string code { get; set; }
        public string isoCode { get; set; }
        public Description description { get; set; }
        public List<State> states { get; set; }
    }

    public class Description
    {
        public string content { get; set; }
    }
}
