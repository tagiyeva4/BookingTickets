using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderAndOrderItemTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fceb1a9-9a93-49a3-bc55-cee75d28791b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cebe24c8-35d6-4bcb-95b2-c0d151331392");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4affbe4-bc6f-433c-b032-bd97859a2af3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8da1a34f-62e4-4266-9166-c8687bdaff13", "66da0aa7-2192-41b6-9cc8-6894a1b03094" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8da1a34f-62e4-4266-9166-c8687bdaff13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66da0aa7-2192-41b6-9cc8-6894a1b03094");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripePaymentIntentId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripeSessionId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SeatDescription",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5a4148-29e2-4795-b767-ae250d2b8f72", null, "Admin", "ADMIN" },
                    { "c693cdb6-f7d7-42b7-a9eb-aa37a37f5a2e", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "d8a9e6f6-d4ba-4752-928c-0e2b1ae6247b", null, "Member", "MEMBER" },
                    { "fe52c765-94dc-435a-9d89-e4a2bc1f84bc", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "70688381-6906-44a5-b6f6-a6c1c5f0ec5c", 0, "ccfe339a-ae8d-4e67-9d9d-38dd521f823a", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEH5Caqas185+E77PxKnniZijBzHn1hVZ+sIEYZ+P9zWddK4JxBmJtJGzGCItluy2Hg==", null, false, "6ecd3bed-57fc-4433-bb47-895d92d7b153", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d8a9e6f6-d4ba-4752-928c-0e2b1ae6247b", "70688381-6906-44a5-b6f6-a6c1c5f0ec5c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5a4148-29e2-4795-b767-ae250d2b8f72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c693cdb6-f7d7-42b7-a9eb-aa37a37f5a2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe52c765-94dc-435a-9d89-e4a2bc1f84bc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d8a9e6f6-d4ba-4752-928c-0e2b1ae6247b", "70688381-6906-44a5-b6f6-a6c1c5f0ec5c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a9e6f6-d4ba-4752-928c-0e2b1ae6247b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70688381-6906-44a5-b6f6-a6c1c5f0ec5c");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaidAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StripePaymentIntentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StripeSessionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SeatDescription",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fceb1a9-9a93-49a3-bc55-cee75d28791b", null, "VipMember", "VIPMEMBER" },
                    { "8da1a34f-62e4-4266-9166-c8687bdaff13", null, "Member", "MEMBER" },
                    { "cebe24c8-35d6-4bcb-95b2-c0d151331392", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "e4affbe4-bc6f-433c-b032-bd97859a2af3", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66da0aa7-2192-41b6-9cc8-6894a1b03094", 0, "791e4851-1123-41fa-83b0-5834064c6726", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEO7v5ZyhoKJdCFz8NaWqv7X01zTZilqFsULNm3btVl0+ecPh/6s9sIrPXwW0nxfNCg==", null, false, "fb87ef3c-b16c-4e2c-ace4-4b0e233f502f", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8da1a34f-62e4-4266-9166-c8687bdaff13", "66da0aa7-2192-41b6-9cc8-6894a1b03094" });
        }
    }
}
