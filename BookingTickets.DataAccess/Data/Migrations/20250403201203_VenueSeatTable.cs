using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class VenueSeatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bc11d2a-e261-4b2d-8e88-bc821375aa77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5135111e-92bb-4d9d-9235-82939c7c6a57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61e05029-a1a1-4c18-a70e-780798dd730e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc344681-975d-450a-9903-650db1171ff0", "4b0b1f15-3e5b-42b8-8330-3622fea94b50" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc344681-975d-450a-9903-650db1171ff0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b0b1f15-3e5b-42b8-8330-3622fea94b50");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "BasketItems");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VenueSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    RowName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    SeatLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenueSeats_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e27fe10-4d65-48b8-9b77-65d2e0a64526", null, "Member", "MEMBER" },
                    { "5807684a-8008-4ee0-9fdb-99f447402503", null, "Admin", "ADMIN" },
                    { "dc43c9df-aecb-4be9-8612-5a32014cbd2b", null, "VipMember", "VIPMEMBER" },
                    { "ea8e813c-9371-4a5a-a2c3-26c123b83aca", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e31a8c6-c81e-4ec4-87ea-d2ac700595bd", 0, "953cefff-4ad9-4057-980d-f9e1cd12ee82", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEC8x50/1Ep4dI4JSC6mto/IHM9XlB8XAtJpUCEkpqzFlQzK2CDH+4lolVuPF1EGJjQ==", null, false, "b987e457-3f09-4c64-9cb4-c5ba61f660ec", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2e27fe10-4d65-48b8-9b77-65d2e0a64526", "4e31a8c6-c81e-4ec4-87ea-d2ac700595bd" });

            migrationBuilder.CreateIndex(
                name: "IX_VenueSeats_VenueId",
                table: "VenueSeats",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VenueSeats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5807684a-8008-4ee0-9fdb-99f447402503");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc43c9df-aecb-4be9-8612-5a32014cbd2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea8e813c-9371-4a5a-a2c3-26c123b83aca");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e27fe10-4d65-48b8-9b77-65d2e0a64526", "4e31a8c6-c81e-4ec4-87ea-d2ac700595bd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e27fe10-4d65-48b8-9b77-65d2e0a64526");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e31a8c6-c81e-4ec4-87ea-d2ac700595bd");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Venues");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4bc11d2a-e261-4b2d-8e88-bc821375aa77", null, "Admin", "ADMIN" },
                    { "5135111e-92bb-4d9d-9235-82939c7c6a57", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "61e05029-a1a1-4c18-a70e-780798dd730e", null, "VipMember", "VIPMEMBER" },
                    { "cc344681-975d-450a-9903-650db1171ff0", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4b0b1f15-3e5b-42b8-8330-3622fea94b50", 0, "9069af65-b837-48c0-8a29-ebe9d7b06a53", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEPyrFF0q/iNdobq+/z9Q/Hv6B1Kh01AtK7RacBH/XofkoolOXuPO8tH6kcSr36evQw==", null, false, "bfb34c05-e97d-409b-b171-aa864893fa81", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cc344681-975d-450a-9903-650db1171ff0", "4b0b1f15-3e5b-42b8-8330-3622fea94b50" });
        }
    }
}
