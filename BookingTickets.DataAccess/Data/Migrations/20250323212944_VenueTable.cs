using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class VenueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58e34d72-822d-4619-9a36-2e74993222a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b13d9921-7df4-4352-82a6-0c1dd0850d4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6f88d06-eea4-4c52-a3f8-ad6b80fd164d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57e116e4-0d33-4330-b1e0-a0742039140b", "ce5a9007-de25-4f73-9911-56f704a0ac40" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57e116e4-0d33-4330-b1e0-a0742039140b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce5a9007-de25-4f73-9911-56f704a0ac40");

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45a33bfc-f46c-415d-bfce-8e7ead46b2c1", null, "Member", "MEMBER" },
                    { "71e3d6b6-3bcb-4541-ab47-f0bd31977130", null, "VipMember", "VIPMEMBER" },
                    { "b7842420-9db6-4523-b679-5ab625c148be", null, "Admin", "ADMIN" },
                    { "d62f6fa7-68ef-4aa4-83fd-501247fe1011", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "565090c0-f444-4fdf-8a87-3909ae1a55c0", 0, "3229e076-aba8-4bee-a638-43e7e24565a5", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEE8G1cGhSdMRm1a2uS4KHFCxFBFPbP1spxxMDtdhQS1BAdDvIPqNMrtvoCLAfzR57A==", null, false, "47f72941-b6be-4035-8485-1c77f18ba78b", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "45a33bfc-f46c-415d-bfce-8e7ead46b2c1", "565090c0-f444-4fdf-8a87-3909ae1a55c0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e3d6b6-3bcb-4541-ab47-f0bd31977130");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7842420-9db6-4523-b679-5ab625c148be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d62f6fa7-68ef-4aa4-83fd-501247fe1011");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45a33bfc-f46c-415d-bfce-8e7ead46b2c1", "565090c0-f444-4fdf-8a87-3909ae1a55c0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45a33bfc-f46c-415d-bfce-8e7ead46b2c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "565090c0-f444-4fdf-8a87-3909ae1a55c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57e116e4-0d33-4330-b1e0-a0742039140b", null, "Member", "MEMBER" },
                    { "58e34d72-822d-4619-9a36-2e74993222a6", null, "VipMember", "VIPMEMBER" },
                    { "b13d9921-7df4-4352-82a6-0c1dd0850d4d", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "d6f88d06-eea4-4c52-a3f8-ad6b80fd164d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce5a9007-de25-4f73-9911-56f704a0ac40", 0, "d7a72649-7c06-479e-848c-0a1aeeec241d", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEMBO/dRKrQMIsw1zTWKlhsmPu+mlbWPO0xcTyIuoyTbem5SuWZCuUm03yqhPiiU0nw==", null, false, "82a8a9e3-2a8b-431e-a83b-ab7d158d3363", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "57e116e4-0d33-4330-b1e0-a0742039140b", "ce5a9007-de25-4f73-9911-56f704a0ac40" });
        }
    }
}
