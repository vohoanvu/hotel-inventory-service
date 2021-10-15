using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ShopifyHotelSourcing.Migrations
{
    public partial class hotelModelConfigured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name_content = table.Column<string>(type: "text", nullable: true),
                    Description_content = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    StateCode = table.Column<string>(type: "text", nullable: true),
                    DestinationCode = table.Column<string>(type: "text", nullable: true),
                    ZoneCode = table.Column<int>(type: "integer", nullable: false),
                    Coordinates_longtitude = table.Column<double>(type: "double precision", nullable: true),
                    Coordinates_latitude = table.Column<double>(type: "double precision", nullable: true),
                    CategoryCode = table.Column<string>(type: "text", nullable: true),
                    CategoryGroupCode = table.Column<string>(type: "text", nullable: true),
                    ChainCode = table.Column<string>(type: "text", nullable: true),
                    AccomodationTypeCode = table.Column<string>(type: "text", nullable: true),
                    SegmentCodes = table.Column<List<int>>(type: "integer[]", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    City_content = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    License = table.Column<string>(type: "text", nullable: true),
                    WebURL = table.Column<string>(type: "text", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    S2C = table.Column<string>(type: "text", nullable: true),
                    Ranking = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Floor = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Hotels_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Hotels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistanceFromTerminal",
                columns: table => new
                {
                    distanceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HotelCode = table.Column<int>(type: "integer", nullable: false),
                    TerminalCode = table.Column<string>(type: "text", nullable: true),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistanceFromTerminal", x => x.distanceId);
                    table.ForeignKey(
                        name: "FK_DistanceFromTerminal_Hotels_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Hotels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels_Facilities",
                columns: table => new
                {
                    facilityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityCode = table.Column<int>(type: "integer", nullable: false),
                    FacilityGroupCode = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    IndLogic = table.Column<bool>(type: "boolean", nullable: false),
                    IndFee = table.Column<bool>(type: "boolean", nullable: false),
                    Voucher = table.Column<bool>(type: "boolean", nullable: false),
                    IndYesOrNo = table.Column<bool>(type: "boolean", nullable: false),
                    TimeFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimeTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels_Facilities", x => x.facilityId);
                    table.ForeignKey(
                        name: "FK_Hotels_Facilities_Hotels_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Hotels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    imageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageTypeCode = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    RoomCode = table.Column<string>(type: "text", nullable: true),
                    RoomType = table.Column<string>(type: "text", nullable: true),
                    CharacteristicCode = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    VisualOrder = table.Column<int>(type: "integer", nullable: false),
                    Description_content = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.imageId);
                    table.ForeignKey(
                        name: "FK_Images_Hotels_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Hotels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    issueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IssueCode = table.Column<string>(type: "text", nullable: true),
                    IssueType = table.Column<string>(type: "text", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Alternative = table.Column<bool>(type: "boolean", nullable: false),
                    Name_content = table.Column<string>(type: "text", nullable: true),
                    Description_content = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.issueId);
                    table.ForeignKey(
                        name: "FK_Issues_Hotels_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Hotels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    phoneId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneType = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.phoneId);
                    table.ForeignKey(
                        name: "FK_Phone_Hotels_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Hotels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomCode = table.Column<string>(type: "text", nullable: true),
                    minPax = table.Column<int>(type: "integer", nullable: false),
                    maxPax = table.Column<int>(type: "integer", nullable: false),
                    maxAdult = table.Column<int>(type: "integer", nullable: false),
                    maxChildren = table.Column<int>(type: "integer", nullable: false),
                    minAdult = table.Column<int>(type: "integer", nullable: false),
                    RoomType = table.Column<string>(type: "text", nullable: true),
                    CharateristicCode = table.Column<string>(type: "text", nullable: true),
                    PMSRoomCode = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Hotels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WildCard",
                columns: table => new
                {
                    wildcardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomType = table.Column<string>(type: "text", nullable: true),
                    RoomCode = table.Column<string>(type: "text", nullable: true),
                    CharacteristicCode = table.Column<string>(type: "text", nullable: true),
                    HotelRoomDescription_content = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WildCard", x => x.wildcardId);
                    table.ForeignKey(
                        name: "FK_WildCard_Hotels_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Hotels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms_RoomFacilities",
                columns: table => new
                {
                    RoomsroomId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityCode = table.Column<int>(type: "integer", nullable: false),
                    FacilityGroupCode = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    IndLogic = table.Column<bool>(type: "boolean", nullable: false),
                    IndFee = table.Column<bool>(type: "boolean", nullable: false),
                    Voucher = table.Column<bool>(type: "boolean", nullable: false),
                    IndYesOrNo = table.Column<bool>(type: "boolean", nullable: false),
                    TimeFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimeTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms_RoomFacilities", x => new { x.RoomsroomId, x.Id });
                    table.ForeignKey(
                        name: "FK_Rooms_RoomFacilities_Rooms_RoomsroomId",
                        column: x => x.RoomsroomId,
                        principalTable: "Rooms",
                        principalColumn: "roomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomStay",
                columns: table => new
                {
                    RoomsroomId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StayType = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStay", x => new { x.RoomsroomId, x.Id });
                    table.ForeignKey(
                        name: "FK_RoomStay_Rooms_RoomsroomId",
                        column: x => x.RoomsroomId,
                        principalTable: "Rooms",
                        principalColumn: "roomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomStay_RoomStayFacilities",
                columns: table => new
                {
                    RoomStayRoomsroomId = table.Column<int>(type: "integer", nullable: false),
                    RoomStayId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityCode = table.Column<int>(type: "integer", nullable: false),
                    FacilityGroupCode = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    IndLogic = table.Column<bool>(type: "boolean", nullable: false),
                    IndFee = table.Column<bool>(type: "boolean", nullable: false),
                    Voucher = table.Column<bool>(type: "boolean", nullable: false),
                    IndYesOrNo = table.Column<bool>(type: "boolean", nullable: false),
                    TimeFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimeTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStay_RoomStayFacilities", x => new { x.RoomStayRoomsroomId, x.RoomStayId, x.Id });
                    table.ForeignKey(
                        name: "FK_RoomStay_RoomStayFacilities_RoomStay_RoomStayRoomsroomId_Ro~",
                        columns: x => new { x.RoomStayRoomsroomId, x.RoomStayId },
                        principalTable: "RoomStay",
                        principalColumns: new[] { "RoomsroomId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_OwnerId",
                table: "Address",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DistanceFromTerminal_OwnerId",
                table: "DistanceFromTerminal",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Facilities_OwnerId",
                table: "Hotels_Facilities",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_OwnerId",
                table: "Images",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_OwnerId",
                table: "Issues",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_OwnerId",
                table: "Phone",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OwnerId",
                table: "Rooms",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WildCard_OwnerId",
                table: "WildCard",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "DistanceFromTerminal");

            migrationBuilder.DropTable(
                name: "Hotels_Facilities");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Rooms_RoomFacilities");

            migrationBuilder.DropTable(
                name: "RoomStay_RoomStayFacilities");

            migrationBuilder.DropTable(
                name: "WildCard");

            migrationBuilder.DropTable(
                name: "RoomStay");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
