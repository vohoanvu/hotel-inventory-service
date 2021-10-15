using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    [Owned]
    public class Segment
    {
        public int Code { get; set; }
        public NameModel Description { get; set; }
    }
}
