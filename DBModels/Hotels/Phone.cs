using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    [Owned]
    public class Phone
    {
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
    }
}
