using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    public class WildCard
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public string RoomCode { get; set; }
        public string CharacteristicCode { get; set; }
        public NameModel HotelRoomDescription { get; set; }
    }
}
