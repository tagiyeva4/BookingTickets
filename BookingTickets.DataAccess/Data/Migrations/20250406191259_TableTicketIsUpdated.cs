using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class TableTicketIsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresAt",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedAt",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                    { "01e64b03-dbdb-4be1-9020-77210dfa55ca", null, "Member", "MEMBER" },
                    { "69958fc4-c087-4470-9103-0568d894adcf", null, "Admin", "ADMIN" },
                    { "8323ee11-d5bc-4bce-9b4e-b2e071db73ca", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "bd08f04a-f36b-4ed5-bfcc-997fc19d1543", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1b0049af-1db7-481b-9310-f498c8ea3c08", 0, "ef2abea3-4a2b-4347-9547-fea31b098df1", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEMswYLpAbx4aMbbPtegH2Vah7LaKZLlxkdiBU+lOpcTXz8ONqTkwKssD0tLjZKY0iA==", null, false, "45a4b6e3-9677-48d5-9cf3-992e23aa5cd8", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "01e64b03-dbdb-4be1-9020-77210dfa55ca", "1b0049af-1db7-481b-9310-f498c8ea3c08" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69958fc4-c087-4470-9103-0568d894adcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8323ee11-d5bc-4bce-9b4e-b2e071db73ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd08f04a-f36b-4ed5-bfcc-997fc19d1543");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01e64b03-dbdb-4be1-9020-77210dfa55ca", "1b0049af-1db7-481b-9310-f498c8ea3c08" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01e64b03-dbdb-4be1-9020-77210dfa55ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b0049af-1db7-481b-9310-f498c8ea3c08");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReservedAt",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "BasketItems");

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
    }
}
