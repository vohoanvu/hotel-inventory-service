using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    public class Rooms
    {
        public int Id { get; set; }
        public string RoomCode { get; set; }
        public int minPax { get; set; }
        public int maxPax { get; set; }
        public int maxAdult { get; set; }
        public int maxChildren { get; set; }
        public int minAdult { get; set; }
        public string RoomType { get; set; }
        public string CharateristicCode { get; set; }
        public List<RoomStay> RoomStays { get; set; }
        public List<Facility> RoomFacilities { get; set; }
        public string PMSRoomCode { get; set; }
    }
}
