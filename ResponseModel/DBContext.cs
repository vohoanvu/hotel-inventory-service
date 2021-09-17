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

        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<GroupZone> GroupZones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure DB relations though fluent API
            modelBuilder.Entity<Country>()
                .HasMany(c => c.states)
                .WithOne(s => s.country)
                .HasForeignKey(c => c.countryCode);

            modelBuilder.Entity<Destination>()
                .HasOne(d => d.country)
                .WithMany(c => c.destinations)
                .HasForeignKey(d => d.countryCode);


            // Configure zone and groupZone with the purpose of practicing DB Design...
            modelBuilder.Entity<Zone>()
                .HasOne(z => z.Destination)
                .WithMany(d => d.zones)
                .HasForeignKey(z => z.DestinationCode);

            modelBuilder.Entity<GroupZone>()
                .HasOne(gz => gz.Destination)
                .WithMany(d => d.groupZones)
                .HasForeignKey(gz => gz.DestinationCode);

            modelBuilder.Entity<Zone>()
                .HasOne(z => z.GroupZone)
                .WithMany(gz => gz.ZonesList)
                .HasForeignKey(z => z.GroupZoneID);
        }
    }
}
