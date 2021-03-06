using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    [Owned]
    public class AccomodationType
    {
        public string Code { get; set; }
        public NameModel TypeMultiDescription { get; set; }
        public string TypeDescription { get; set; }
    }
}
