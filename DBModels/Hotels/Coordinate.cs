using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    [Owned]
    public class Coordinate
    {
        public double longtitude { get; set; }
        public double latitude { get; set; }
    }
}
