using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e69313b-3edc-46a0-bcce-90331921e3d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41e58a8a-2745-4493-a00e-2c81ac8e3ca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc59304-33f5-42b4-9772-8529d463f949");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "230ebbb5-f396-4c0a-bf10-6f8e2c57cd9a", "a80efdc8-6976-4196-a9ad-53b3bf4ed5b6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "230ebbb5-f396-4c0a-bf10-6f8e2c57cd9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a80efdc8-6976-4196-a9ad-53b3bf4ed5b6");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "EventsSchedules");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "EventsSchedules");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "EventsSchedules");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "EventsSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c11e08c8-2fd7-4006-9094-587598590da9", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "d8118e08-c856-45e9-a0b9-87020489778c", null, "VipMember", "VIPMEMBER" },
                    { "f156aea4-b3c0-4511-8166-81d4cc22597e", null, "Admin", "ADMIN" },
                    { "fc65704c-d85a-45c4-a53f-af1e73b9da7e", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c707a126-9552-4f12-a182-7e7d7b989926", 0, "437cc454-37d0-4999-a71a-479978d5f785", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEIdZaCBdNuMrR1J78z9vIvssJCQim32nTreYkL9ohBMihDZOQATJ/+qxsMbvZxI5dg==", null, false, "d841be67-0563-4fba-bc6d-299915abf8a1", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc65704c-d85a-45c4-a53f-af1e73b9da7e", "c707a126-9552-4f12-a182-7e7d7b989926" });

            migrationBuilder.CreateIndex(
                name: "IX_EventsSchedules_ScheduleId",
                table: "EventsSchedules",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsSchedules_Schedules_ScheduleId",
                table: "EventsSchedules",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsSchedules_Schedules_ScheduleId",
                table: "EventsSchedules");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_EventsSchedules_ScheduleId",
                table: "EventsSchedules");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c11e08c8-2fd7-4006-9094-587598590da9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8118e08-c856-45e9-a0b9-87020489778c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f156aea4-b3c0-4511-8166-81d4cc22597e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc65704c-d85a-45c4-a53f-af1e73b9da7e", "c707a126-9552-4f12-a182-7e7d7b989926" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc65704c-d85a-45c4-a53f-af1e73b9da7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c707a126-9552-4f12-a182-7e7d7b989926");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "EventsSchedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "EventsSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "EventsSchedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "EventsSchedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e69313b-3edc-46a0-bcce-90331921e3d9", null, "VipMember", "VIPMEMBER" },
                    { "230ebbb5-f396-4c0a-bf10-6f8e2c57cd9a", null, "Member", "MEMBER" },
                    { "41e58a8a-2745-4493-a00e-2c81ac8e3ca8", null, "Admin", "ADMIN" },
                    { "ffc59304-33f5-42b4-9772-8529d463f949", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a80efdc8-6976-4196-a9ad-53b3bf4ed5b6", 0, "4f4d4585-5ef2-4484-a55b-3291a6d26a55", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEF/b5TBB5jN821yZL4ASrAN+fOJFz9IoH4hEOEUH4XvcX5cUj8nN5IJFzVhkjFeMnw==", null, false, "0ba1c35f-ad96-4118-b95a-b6dacbb96159", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "230ebbb5-f396-4c0a-bf10-6f8e2c57cd9a", "a80efdc8-6976-4196-a9ad-53b3bf4ed5b6" });
        }
    }
}
