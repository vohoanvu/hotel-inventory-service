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
        public virtual DbSet<Hotel> Hotels { get; set; }

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


            modelBuilder.Entity<Hotel>().OwnsOne(h => h.Name);
            modelBuilder.Entity<Hotel>().OwnsOne(h => h.Description);
            modelBuilder.Entity<Hotel>().OwnsOne(h => h.Coordinates);
            modelBuilder.Entity<Hotel>().OwnsOne(h => h.City);

            modelBuilder.Entity<Hotel>().OwnsMany(
                h => h.Address,
                a =>
                {
                    a.WithOwner().HasForeignKey("OwnerId");
                    a.Property<int>("AddressId");
                    a.HasKey("AddressId");
                });

            modelBuilder.Entity<Hotel>().OwnsMany(
                h => h.Phones,
                p =>
                {
                    p.WithOwner().HasForeignKey("OwnerId");
                    p.Property<int>("phoneId");
                    p.HasKey("phoneId");
                });

            modelBuilder.Entity<Hotel>().OwnsMany(
                h => h.Rooms,
                r =>
                {
                    r.WithOwner().HasForeignKey("OwnerId");
                    r.Property<int>("roomId");
                    r.HasKey("roomId");
                    r.OwnsMany(r => r.RoomStays);
                    r.OwnsMany(r => r.RoomFacilities);
                });

            modelBuilder.Entity<Hotel>().OwnsMany(
                h => h.Facilities,
                f =>
                {
                    f.WithOwner().HasForeignKey("OwnerId");
                    f.Property<int>("facilityId");
                    f.HasKey("facilityId");
                });
            modelBuilder.Entity<Hotel>().OwnsMany(
                h => h.Terminals,
                t =>
                {
                    t.WithOwner().HasForeignKey("OwnerId");
                    t.Property<int>("distanceId");
                    t.HasKey("distanceId");
                });
            modelBuilder.Entity<Hotel>().OwnsMany(
                h => h.Issues,
                i =>
                {
                    i.WithOwner().HasForeignKey("OwnerId");
                    i.Property<int>("issueId");
                    i.HasKey("issueId");
                    i.OwnsOne(i => i.Name);
                    i.OwnsOne(i => i.Description);
                });
            modelBuilder.Entity<Hotel>().OwnsMany(
                h => h.Images,
                i =>
                {
                    i.WithOwner().HasForeignKey("OwnerId");
                    i.Property<int>("imageId");
                    i.HasKey("imageId");
                    i.OwnsOne(i => i.Description);
                });
            modelBuilder.Entity<Hotel>().OwnsMany(
                h => h.WildCards,
                w =>
                {
                    w.WithOwner().HasForeignKey("OwnerId");
                    w.Property<int>("wildcardId");
                    w.HasKey("wildcardId");
                    w.OwnsOne(w => w.HotelRoomDescription);
                });
        }
    }
}
