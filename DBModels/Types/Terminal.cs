using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    [Owned]
    public class Terminal
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public string CountryCode { get; set; }
        public NameModel Name { get; set; }
        public NameModel Description { get; set; }
    }
}
