using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    public class Category
    {
        public int SimpleCode { get; set; }
        public string Code { get; set; }
        public string AccomodationType { get; set; }
        public string Group { get; set; }
        public NameModel Description { get; set; }
    }
}
