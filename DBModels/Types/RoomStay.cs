using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Types
{
    public class RoomStay
    {
        public int Id { get; set; }
        public string StayType { get; set; }
        public string Order { get; set; }
        public string Description { get; set; }
        public virtual List<Facility> RoomStayFacilities { get; set; }
    }
}
