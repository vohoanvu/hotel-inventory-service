using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    public class Hotel
    {
        public int Code { get; set; }
        public NameModel Name { get; set; }
        public NameModel Description { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string DestinationCode { get; set; }
        public int ZoneCode { get; set; }
        public Coordinate Coordinates { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryGroupCode { get; set; }
        public string ChainCode { get; set; }
        public string AccomodationTypeCode { get; set; }
        public List<int> SegmentCodes { get; set; }
        public List<Address> Address { get; set; }
        public string PostalCode { get; set; }
        public NameModel City { get; set; }
        public string Email { get; set; }
        public string License { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Rooms> Rooms { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<DistanceFromTerminal> Terminals { get; set; }
        public List<Issues> Issues { get; set; }
        public List<Images> Images { get; set; }
        public List<WildCard> WildCards { get; set; }
        public string WebURL { get; set; }
        public DateTime LastUpdate { get; set; }
        public string S2C { get; set; }
        public int Ranking { get; set; }
    }
}
