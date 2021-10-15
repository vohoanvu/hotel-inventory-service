using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    [Owned]
    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Floor { get; set; }
    }
}
