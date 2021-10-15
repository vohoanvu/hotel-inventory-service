using ShopifyHotelSourcing.DBModels.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.APIHotelResponseModel
{
    public class HotelsResponse
    {
        public int from { get; set; }
        public int to { get; set; }
        public int total { get; set; }
        public AuditDataResponse auditData { get; set; }
        public List<Hotel> hotels { get; set; }
    }
}
