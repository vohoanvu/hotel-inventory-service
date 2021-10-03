//using com.hotelbeds.distribution.hotel_api_model.auto.model;
using ShopifyHotelSourcing.DBModels.Hotels;
using Microsoft.EntityFrameworkCore;
using ShopifyHotelSourcing.DBModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopifyHotelSourcing.DBModels.Types;

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
        public virtual DbSet<Destination> Destinations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure DB relations though fluent API
            /*modelBuilder.Entity<Country>()
                .HasMany(c => c.states)
                .WithOne(s => s.country)
                .HasForeignKey(c => c.countryCode);*/
            // using Owned Entity Type for reference navigation properties
            modelBuilder.Entity<Country>().OwnsMany(
                c => c.states,
                s => 
                {
                    s.WithOwner().HasForeignKey("OwnerId");
                    s.Property<int>("Id");
                    s.HasKey("Id");
                });
            modelBuilder.Entity<Country>().OwnsOne(c => c.description);


            modelBuilder.Entity<Destination>()
                .HasOne(d => d.country)
                .WithMany(c => c.destinations)
                .HasForeignKey(d => d.countryCode);

            modelBuilder.Entity<Destination>().OwnsOne(c => c.name);

            modelBuilder.Entity<Destination>().OwnsMany(
                d => d.zones,
                z =>
                {
                    z.WithOwner().HasForeignKey("OwnerId");
                    z.Property<int>("ZoneId");
                    z.HasKey("ZoneId");
                    z.OwnsOne(z => z.description);
                    z.ToTable("Zone");
                });

            modelBuilder.Entity<Destination>().OwnsMany(
                d => d.groupZones,
                gz =>
                {
                    gz.WithOwner().HasForeignKey("OwnerId");
                    gz.Property<int>("GroupZoneId");
                    gz.HasKey("GroupZoneId");
                    gz.OwnsOne(gz => gz.name);
                    gz.ToTable("GroupZone");
                });
            // Configure zone and groupZone with the purpose of practicing DB Design...
            /*modelBuilder.Entity<Zone>()
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

            modelBuilder.Entity<NameModel>().HasNoKey();*/
        }
    }
}
