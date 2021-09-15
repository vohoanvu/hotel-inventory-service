using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    public class DistanceFromTerminal
    {
        public int HotelCode { get; set; }
        public string TerminalCode { get; set; }
        public int Distance { get; set; }
    }
}
