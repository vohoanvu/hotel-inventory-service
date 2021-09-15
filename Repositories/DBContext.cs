//using com.hotelbeds.distribution.hotel_api_model.auto.model;
using ShopifyHotelSourcing.DBModels.Hotels;
using Microsoft.EntityFrameworkCore;
using ShopifyHotelSourcing.DBModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Repositories
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
    }
}
