// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopifyHotelSourcing.Repositories;

namespace ShopifyHotelSourcing.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20211003221304_DBschemaModified")]
    partial class DBschemaModified
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ShopifyHotelSourcing.DBModels.Locations.Country", b =>
                {
                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<string>("isoCode")
                        .HasColumnType("text");

                    b.HasKey("code");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ShopifyHotelSourcing.DBModels.Locations.Destination", b =>
                {
                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<string>("countryCode")
                        .HasColumnType("text");

                    b.Property<string>("isoCode")
                        .HasColumnType("text");

                    b.HasKey("code");

                    b.HasIndex("countryCode");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("ShopifyHotelSourcing.DBModels.Locations.Country", b =>
                {
                    b.OwnsOne("ShopifyHotelSourcing.DBModels.Types.NameModel", "description", b1 =>
                        {
                            b1.Property<string>("Countrycode")
                                .HasColumnType("text");

                            b1.Property<string>("content")
                                .HasColumnType("text");

                            b1.HasKey("Countrycode");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("Countrycode");
                        });

                    b.OwnsMany("ShopifyHotelSourcing.DBModels.Locations.State", "states", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("OwnerId")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("code")
                                .HasColumnType("text");

                            b1.Property<string>("name")
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("OwnerId");

                            b1.ToTable("State");

                            b1.WithOwner()
                                .HasForeignKey("OwnerId");
                        });

                    b.Navigation("description");

                    b.Navigation("states");
                });

            modelBuilder.Entity("ShopifyHotelSourcing.DBModels.Locations.Destination", b =>
                {
                    b.HasOne("ShopifyHotelSourcing.DBModels.Locations.Country", "country")
                        .WithMany("destinations")
                        .HasForeignKey("countryCode");

                    b.OwnsOne("ShopifyHotelSourcing.DBModels.Types.NameModel", "name", b1 =>
                        {
                            b1.Property<string>("Destinationcode")
                                .HasColumnType("text");

                            b1.Property<string>("content")
                                .HasColumnType("text");

                            b1.HasKey("Destinationcode");

                            b1.ToTable("Destinations");

                            b1.WithOwner()
                                .HasForeignKey("Destinationcode");
                        });

                    b.OwnsMany("ShopifyHotelSourcing.DBModels.Locations.GroupZone", "groupZones", b1 =>
                        {
                            b1.Property<int>("GroupZoneId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("OwnerId")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("groupZoneCode")
                                .HasColumnType("text");

                            b1.Property<List<int>>("zones")
                                .HasColumnType("integer[]");

                            b1.HasKey("GroupZoneId");

                            b1.HasIndex("OwnerId");

                            b1.ToTable("GroupZone");

                            b1.WithOwner()
                                .HasForeignKey("OwnerId");

                            b1.OwnsOne("ShopifyHotelSourcing.DBModels.Types.NameModel", "name", b2 =>
                                {
                                    b2.Property<int>("GroupZoneId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer")
                                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                                    b2.Property<string>("content")
                                        .HasColumnType("text");

                                    b2.HasKey("GroupZoneId");

                                    b2.ToTable("GroupZone");

                                    b2.WithOwner()
                                        .HasForeignKey("GroupZoneId");
                                });

                            b1.Navigation("name");
                        });

                    b.OwnsMany("ShopifyHotelSourcing.DBModels.Locations.Zone", "zones", b1 =>
                        {
                            b1.Property<int>("ZoneId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("OwnerId")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("name")
                                .HasColumnType("text");

                            b1.Property<int>("zoneCode")
                                .HasColumnType("integer");

                            b1.HasKey("ZoneId");

                            b1.HasIndex("OwnerId");

                            b1.ToTable("Zone");

                            b1.WithOwner()
                                .HasForeignKey("OwnerId");

                            b1.OwnsOne("ShopifyHotelSourcing.DBModels.Types.NameModel", "description", b2 =>
                                {
                                    b2.Property<int>("ZoneId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer")
                                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                                    b2.Property<string>("content")
                                        .HasColumnType("text");

                                    b2.HasKey("ZoneId");

                                    b2.ToTable("Zone");

                                    b2.WithOwner()
                                        .HasForeignKey("ZoneId");
                                });

                            b1.Navigation("description");
                        });

                    b.Navigation("country");

                    b.Navigation("groupZones");

                    b.Navigation("name");

                    b.Navigation("zones");
                });

            modelBuilder.Entity("ShopifyHotelSourcing.DBModels.Locations.Country", b =>
                {
                    b.Navigation("destinations");
                });
#pragma warning restore 612, 618
        }
    }
}
