using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0376fdce-75fb-4571-98d9-c8476512a830");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3007e2a7-0d62-4efc-b42e-70a240c13b6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d37d3d5d-78b7-4419-b1d4-f666a5ee42ed");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8296e782-f04c-427e-858a-7a0d5a0c3579", "c3031710-0dd5-4fca-b6e8-972381d3d24d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8296e782-f04c-427e-858a-7a0d5a0c3579");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3031710-0dd5-4fca-b6e8-972381d3d24d");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "TotalTickets",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventsSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsSchedules_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b624d2a-ee3e-4807-9e85-3eee23348253", null, "Admin", "ADMIN" },
                    { "4905666b-7223-470f-af23-336b22e69171", null, "VipMember", "VIPMEMBER" },
                    { "562ad5be-a848-4afe-9e2f-5abef4e89dc2", null, "Member", "MEMBER" },
                    { "f8d42d15-687d-4785-b5c9-092cbbc55aed", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4644362-8ab4-46ac-80ac-e4cc782deb02", 0, "1bedd11e-4140-4f32-a67d-12904a1bcdec", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEA1h+/8PU5sApOKPVizxQkUGGN2b2o4D7Caao3If+xtQ8laIekjSPZ8vlKhBPY/5JA==", null, false, "7c74a0b6-eaa8-41ef-8774-4c4665169cfa", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "562ad5be-a848-4afe-9e2f-5abef4e89dc2", "e4644362-8ab4-46ac-80ac-e4cc782deb02" });

            migrationBuilder.CreateIndex(
                name: "IX_EventsSchedules_EventId",
                table: "EventsSchedules",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsSchedules");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b624d2a-ee3e-4807-9e85-3eee23348253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4905666b-7223-470f-af23-336b22e69171");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8d42d15-687d-4785-b5c9-092cbbc55aed");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "562ad5be-a848-4afe-9e2f-5abef4e89dc2", "e4644362-8ab4-46ac-80ac-e4cc782deb02" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "562ad5be-a848-4afe-9e2f-5abef4e89dc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4644362-8ab4-46ac-80ac-e4cc782deb02");

            migrationBuilder.DropColumn(
                name: "TotalTickets",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Dates",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0376fdce-75fb-4571-98d9-c8476512a830", null, "VipMember", "VIPMEMBER" },
                    { "3007e2a7-0d62-4efc-b42e-70a240c13b6e", null, "Admin", "ADMIN" },
                    { "8296e782-f04c-427e-858a-7a0d5a0c3579", null, "Member", "MEMBER" },
                    { "d37d3d5d-78b7-4419-b1d4-f666a5ee42ed", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c3031710-0dd5-4fca-b6e8-972381d3d24d", 0, "e743d64f-d435-4147-b6b2-ad45ddb97812", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAECk3Ipi2t9U1qfh8kgWqIWIoroV6nQASYeKdiw74yCQYOCOzXdoNdFMyWiXszxP+9A==", null, false, "43ae7de0-7b00-446f-9ec5-84ddcfa3dff2", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8296e782-f04c-427e-858a-7a0d5a0c3579", "c3031710-0dd5-4fca-b6e8-972381d3d24d" });
        }
    }
}
