using Microsoft.EntityFrameworkCore;
using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    [Owned]
    public class Images
    {
        public string ImageTypeCode { get; set; }
        public string Path { get; set; }
        public string RoomCode { get; set; }
        public string RoomType { get; set; }
        public string CharacteristicCode { get; set; }
        public int Order { get; set; }
        public int VisualOrder { get; set; }
        public NameModel Description { get; set; }
    }
}
