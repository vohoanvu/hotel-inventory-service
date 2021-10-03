using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.DBModels.Locations
{
    [Owned]
    public class State
    {
        public string code { get; set; }
        public string name { get; set; } 

        //Foreign Key
        //public string countryCode { get; set; }
        //public virtual Country country { get; set; }
    }
}
