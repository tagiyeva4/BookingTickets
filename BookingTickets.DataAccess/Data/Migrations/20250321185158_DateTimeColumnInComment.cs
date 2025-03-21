using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeColumnInComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe208d2-d164-4098-9f0d-809721a9e9a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2567524-be2f-4cfc-a67f-3940b6ba3343");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcdf3c23-b42a-4806-bb37-381599e08662");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aaa7bc0c-45a2-45ba-8323-8539baad832a", "1795ccb2-5658-425c-a4dc-b6fa9c650706" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaa7bc0c-45a2-45ba-8323-8539baad832a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1795ccb2-5658-425c-a4dc-b6fa9c650706");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "BlogsComment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c810b00-c6ba-4a84-b560-fb5f5a5a42a4", null, "Admin", "ADMIN" },
                    { "4ea1c19e-e96e-438d-a372-b7d9dd31ae0b", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "8d696b4a-6e5a-45f7-9ec0-b04e95b10fa5", null, "Member", "MEMBER" },
                    { "e40b440b-c049-4d40-9650-23ddc1c5cdb8", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1f2463e2-ae9c-4b51-a72c-be0f399b1f65", 0, "8a84c603-158c-4ed5-8742-ac742aec98ec", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEAKX8kHE2+twkjZ4OxpBaniT0MYnLVFHvs/l3mnqb7z3x2u5o35JY5ENZG5vWpvaxg==", null, false, "ac71141c-94ba-4e91-95ff-9f8b9c4e4f05", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8d696b4a-6e5a-45f7-9ec0-b04e95b10fa5", "1f2463e2-ae9c-4b51-a72c-be0f399b1f65" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c810b00-c6ba-4a84-b560-fb5f5a5a42a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ea1c19e-e96e-438d-a372-b7d9dd31ae0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e40b440b-c049-4d40-9650-23ddc1c5cdb8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d696b4a-6e5a-45f7-9ec0-b04e95b10fa5", "1f2463e2-ae9c-4b51-a72c-be0f399b1f65" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d696b4a-6e5a-45f7-9ec0-b04e95b10fa5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f2463e2-ae9c-4b51-a72c-be0f399b1f65");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "BlogsComment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe208d2-d164-4098-9f0d-809721a9e9a4", null, "VipMember", "VIPMEMBER" },
                    { "aaa7bc0c-45a2-45ba-8323-8539baad832a", null, "Member", "MEMBER" },
                    { "b2567524-be2f-4cfc-a67f-3940b6ba3343", null, "Admin", "ADMIN" },
                    { "fcdf3c23-b42a-4806-bb37-381599e08662", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1795ccb2-5658-425c-a4dc-b6fa9c650706", 0, "125e95be-e572-45fe-ab54-8d56d7487f8e", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEPu0EyvARw0/9CP474Z92n5o3IS8WwnH+xeYG6ow7/MMHWxdj3I7SaJQA3kKORqvfQ==", null, false, "c9d68134-f955-494c-80b4-263f80115494", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aaa7bc0c-45a2-45ba-8323-8539baad832a", "1795ccb2-5658-425c-a4dc-b6fa9c650706" });
        }
    }
}
