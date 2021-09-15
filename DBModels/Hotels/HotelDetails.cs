using ShopifyHotelSourcing.DBModels.Locations;
using ShopifyHotelSourcing.DBModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Hotels
{
    public class HotelDetails
    {
        public int Code { get; set; }
        public NameModel Name { get; set; }
        public NameModel Description { get; set; }
        //public Country Country { get; set; }
        public State State { get; set; }
        public Destination Destination { get; set; }
        public Zone Zone { get; set; }
        public Coordinate Coordinates { get; set; } // duplicate of Hotels
        public Category Category { get; set; } 
        public GroupCategory CategoryGroup { get; set; }
        public Chain Chain { get; set; }
        public AccomodationType AccomodationType { get; set; }
        public List<Segment> Segments { get; set; }
        public Address Address { get; set; } 
        public string PostalCode { get; set; } // duplicate of Hotels
        public NameModel City { get; set; } // duplicate of Hotels
        public string Email { get; set; } // duplicate of Hotels
        public string License { get; set; } // duplicate of Hotels
        public List<Phone> Phones { get; set; } // duplicate of Hotels
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
