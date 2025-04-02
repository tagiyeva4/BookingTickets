using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class TicketTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AppUserId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13f93610-0ff9-45fc-aed4-8228c1c2fb6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7008ecd3-db51-4ea3-8e42-d5b419284c23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92749da9-c8ec-4dbe-91c0-245677ce5307");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16ad9993-ab0c-47e8-aac9-ae286a1772cf", "544206ab-ecd6-4eb2-8f95-1f72d20462cf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16ad9993-ab0c-47e8-aac9-ae286a1772cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "544206ab-ecd6-4eb2-8f95-1f72d20462cf");

            migrationBuilder.AlterColumn<string>(
                name: "QRCodePath",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AppUserId",
                table: "Tickets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AppUserId",
                table: "Tickets");

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

            migrationBuilder.AlterColumn<string>(
                name: "QRCodePath",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13f93610-0ff9-45fc-aed4-8228c1c2fb6d", null, "Admin", "ADMIN" },
                    { "16ad9993-ab0c-47e8-aac9-ae286a1772cf", null, "Member", "MEMBER" },
                    { "7008ecd3-db51-4ea3-8e42-d5b419284c23", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "92749da9-c8ec-4dbe-91c0-245677ce5307", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "544206ab-ecd6-4eb2-8f95-1f72d20462cf", 0, "84a2f4db-a026-48c5-9ec5-81d4dcbd847b", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEEd/SVrJrLqtwFIl5M5ChfSo25xMaf6EMzPFFrBBuDTSQ63IkrAc8JsDf8NmO+ywWA==", null, false, "7fa131ea-5c94-43d1-8054-e11c04512396", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16ad9993-ab0c-47e8-aac9-ae286a1772cf", "544206ab-ecd6-4eb2-8f95-1f72d20462cf" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AppUserId",
                table: "Tickets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
