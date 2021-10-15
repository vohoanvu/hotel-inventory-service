using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    [Owned]
    public class RoomStay
    {
        public string StayType { get; set; }
        public string Order { get; set; }
        public string Description { get; set; }
        public virtual List<Facility> RoomStayFacilities { get; set; }
    }
}
