using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ShopifyHotelSourcing.Migrations
{
    public partial class DBschemaModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupZones_Destinations_DestinationCode",
                table: "GroupZones");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_countryCode",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Destinations_DestinationCode",
                table: "Zones");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_GroupZones_GroupZoneID",
                table: "Zones");

            migrationBuilder.DropTable(
                name: "NameContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zones",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Zones_DestinationCode",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Zones_GroupZoneID",
                table: "Zones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_countryCode",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupZones",
                table: "GroupZones");

            migrationBuilder.DropIndex(
                name: "IX_GroupZones_DestinationCode",
                table: "GroupZones");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "countryCode",
                table: "States");

            migrationBuilder.RenameTable(
                name: "Zones",
                newName: "Zone");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "GroupZones",
                newName: "GroupZone");

            migrationBuilder.RenameColumn(
                name: "GroupZoneID",
                table: "Zone",
                newName: "ZoneId");

            migrationBuilder.RenameColumn(
                name: "DestinationCode",
                table: "Zone",
                newName: "description_content");

            migrationBuilder.RenameColumn(
                name: "DestinationCode",
                table: "GroupZone",
                newName: "name_content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GroupZone",
                newName: "GroupZoneId");

            migrationBuilder.AddColumn<string>(
                name: "name_content",
                table: "Destinations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description_content",
                table: "Countries",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZoneId",
                table: "Zone",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Zone",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "State",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "State",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "State",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "GroupZone",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zone",
                table: "Zone",
                column: "ZoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupZone",
                table: "GroupZone",
                column: "GroupZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_OwnerId",
                table: "Zone",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_State_OwnerId",
                table: "State",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupZone_OwnerId",
                table: "GroupZone",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupZone_Destinations_OwnerId",
                table: "GroupZone",
                column: "OwnerId",
                principalTable: "Destinations",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Countries_OwnerId",
                table: "State",
                column: "OwnerId",
                principalTable: "Countries",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Destinations_OwnerId",
                table: "Zone",
                column: "OwnerId",
                principalTable: "Destinations",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupZone_Destinations_OwnerId",
                table: "GroupZone");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Countries_OwnerId",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Destinations_OwnerId",
                table: "Zone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zone",
                table: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Zone_OwnerId",
                table: "Zone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_OwnerId",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupZone",
                table: "GroupZone");

            migrationBuilder.DropIndex(
                name: "IX_GroupZone_OwnerId",
                table: "GroupZone");

            migrationBuilder.DropColumn(
                name: "name_content",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "description_content",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "State");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "State");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "GroupZone");

            migrationBuilder.RenameTable(
                name: "Zone",
                newName: "Zones");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "GroupZone",
                newName: "GroupZones");

            migrationBuilder.RenameColumn(
                name: "description_content",
                table: "Zones",
                newName: "DestinationCode");

            migrationBuilder.RenameColumn(
                name: "ZoneId",
                table: "Zones",
                newName: "GroupZoneID");

            migrationBuilder.RenameColumn(
                name: "name_content",
                table: "GroupZones",
                newName: "DestinationCode");

            migrationBuilder.RenameColumn(
                name: "GroupZoneId",
                table: "GroupZones",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "GroupZoneID",
                table: "Zones",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Zones",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "States",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "countryCode",
                table: "States",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zones",
                table: "Zones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupZones",
                table: "GroupZones",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Zones_DestinationCode",
                table: "Zones",
                column: "DestinationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_GroupZoneID",
                table: "Zones",
                column: "GroupZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_States_countryCode",
                table: "States",
                column: "countryCode");

            migrationBuilder.CreateIndex(
                name: "IX_GroupZones_DestinationCode",
                table: "GroupZones",
                column: "DestinationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupZones_Destinations_DestinationCode",
                table: "GroupZones",
                column: "DestinationCode",
                principalTable: "Destinations",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_countryCode",
                table: "States",
                column: "countryCode",
                principalTable: "Countries",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Destinations_DestinationCode",
                table: "Zones",
                column: "DestinationCode",
                principalTable: "Destinations",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_GroupZones_GroupZoneID",
                table: "Zones",
                column: "GroupZoneID",
                principalTable: "GroupZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
