using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "VenueSeats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "VenueSeatId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19b5c469-e1fb-47bb-b0a6-8daef1203868", null, "VipMember", "VIPMEMBER" },
                    { "36b110ab-8a39-4960-83d4-a3ac73e884cd", null, "Member", "MEMBER" },
                    { "456fc3e0-9457-4e79-9d03-0ccf353f3f39", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "c014d1e1-35c5-436d-99bb-61abf622abb6", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "763ecb0a-a226-4e89-ad4a-fda218c50349", 0, "3c7a06f9-02ea-4a48-b163-d242a4f4a42d", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEEsZrvPxjl8M++8Ij8weSLcRYEr88Po59IjClI+RGtAaZxDhHpIeWQamfNwUfPsxqQ==", null, false, "b173ee28-139c-4fae-8bc7-49b14dd89243", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "36b110ab-8a39-4960-83d4-a3ac73e884cd", "763ecb0a-a226-4e89-ad4a-fda218c50349" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_VenueSeatId",
                table: "Tickets",
                column: "VenueSeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_VenueSeats_VenueSeatId",
                table: "Tickets",
                column: "VenueSeatId",
                principalTable: "VenueSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_VenueSeats_VenueSeatId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_VenueSeatId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19b5c469-e1fb-47bb-b0a6-8daef1203868");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "456fc3e0-9457-4e79-9d03-0ccf353f3f39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c014d1e1-35c5-436d-99bb-61abf622abb6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "36b110ab-8a39-4960-83d4-a3ac73e884cd", "763ecb0a-a226-4e89-ad4a-fda218c50349" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36b110ab-8a39-4960-83d4-a3ac73e884cd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "763ecb0a-a226-4e89-ad4a-fda218c50349");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "VenueSeats");

            migrationBuilder.DropColumn(
                name: "VenueSeatId",
                table: "Tickets");

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
        }
    }
}
