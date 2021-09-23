using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ShopifyHotelSourcing.Migrations
{
    public partial class LocationsDBSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    isoCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "NameContents",
                columns: table => new
                {
                    NameId = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    countryCode = table.Column<string>(type: "text", nullable: true),
                    isoCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.code);
                    table.ForeignKey(
                        name: "FK_Destinations_Countries_countryCode",
                        column: x => x.countryCode,
                        principalTable: "Countries",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    countryCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.code);
                    table.ForeignKey(
                        name: "FK_States_Countries_countryCode",
                        column: x => x.countryCode,
                        principalTable: "Countries",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    groupZoneCode = table.Column<string>(type: "text", nullable: true),
                    zones = table.Column<List<int>>(type: "integer[]", nullable: true),
                    DestinationCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupZones_Destinations_DestinationCode",
                        column: x => x.DestinationCode,
                        principalTable: "Destinations",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    zoneCode = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    DestinationCode = table.Column<string>(type: "text", nullable: true),
                    GroupZoneID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Destinations_DestinationCode",
                        column: x => x.DestinationCode,
                        principalTable: "Destinations",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zones_GroupZones_GroupZoneID",
                        column: x => x.GroupZoneID,
                        principalTable: "GroupZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_countryCode",
                table: "Destinations",
                column: "countryCode");

            migrationBuilder.CreateIndex(
                name: "IX_GroupZones_DestinationCode",
                table: "GroupZones",
                column: "DestinationCode");

            migrationBuilder.CreateIndex(
                name: "IX_States_countryCode",
                table: "States",
                column: "countryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_DestinationCode",
                table: "Zones",
                column: "DestinationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_GroupZoneID",
                table: "Zones",
                column: "GroupZoneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NameContents");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "GroupZones");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
