using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class PriceColumnToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab1d2a4a-07fb-4dbd-ad77-c699a5de070f", null, "Admin", "ADMIN" },
                    { "d5d6d1bb-d168-4e96-a217-9ee47ef4adfb", null, "Member", "MEMBER" },
                    { "ef55104a-3120-4acf-923b-6910bce1f08f", null, "VipMember", "VIPMEMBER" },
                    { "f7b83f9b-698a-4d22-9f07-23c5ffa4231d", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f048ad95-223a-4c98-9d3a-e7f2b49fdb9e", 0, "56870fa1-7aae-4263-b8ad-86ebd903c9b0", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEGY7mF21TYdJWQWd1QD+1A6l3XCL3veISk0FQc7/gfloN4HuUVkSgV4b7tcBkdneZw==", null, false, "eec07950-5d11-4150-a558-7ab39b6d9d6a", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d5d6d1bb-d168-4e96-a217-9ee47ef4adfb", "f048ad95-223a-4c98-9d3a-e7f2b49fdb9e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab1d2a4a-07fb-4dbd-ad77-c699a5de070f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef55104a-3120-4acf-923b-6910bce1f08f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7b83f9b-698a-4d22-9f07-23c5ffa4231d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d5d6d1bb-d168-4e96-a217-9ee47ef4adfb", "f048ad95-223a-4c98-9d3a-e7f2b49fdb9e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d6d1bb-d168-4e96-a217-9ee47ef4adfb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f048ad95-223a-4c98-9d3a-e7f2b49fdb9e");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

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
        }
    }
}
