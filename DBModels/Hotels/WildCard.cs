using Microsoft.EntityFrameworkCore;
using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    [Owned]
    public class WildCard
    {
        public string RoomType { get; set; }
        public string RoomCode { get; set; }
        public string CharacteristicCode { get; set; }
        public NameModel HotelRoomDescription { get; set; }
    }
}
