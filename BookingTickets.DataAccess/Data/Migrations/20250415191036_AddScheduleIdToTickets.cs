using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduleIdToTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f2f577-c9f0-46cc-98ab-681e3ba1fc65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed036ca0-ae88-4dd9-a174-974b4bf75a9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f164d462-aa44-4a11-a696-e06bda0b5177");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01ef7b32-64b9-4c7d-9593-0fe242977a6c", "26c01f9a-acde-48b4-8d08-0cf669ef4547" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01ef7b32-64b9-4c7d-9593-0fe242977a6c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c01f9a-acde-48b4-8d08-0cf669ef4547");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b21e3bb-1eab-41fd-a24a-9e707c6575cb", null, "VipMember", "VIPMEMBER" },
                    { "5c1a37be-0600-424e-9d12-544ebc9fae5e", null, "Member", "MEMBER" },
                    { "9999a08c-172c-4d90-8548-e21ed8482fd1", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "dd1cb31f-687b-4458-87a5-61d21dd680db", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "58f7572a-c2aa-4468-bb89-057a5ab690b3", 0, "a2431f8b-225b-48ac-80c5-a4ff87133121", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEE2mX0WzlVu+nIs1jkJEOf2NqvcZB4UW1RWkhmiGdDGW9Av6r/VFJp029nCgNhJnJA==", null, false, "b6ed1d14-0429-4a02-8fca-c894a93c9e61", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5c1a37be-0600-424e-9d12-544ebc9fae5e", "58f7572a-c2aa-4468-bb89-057a5ab690b3" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScheduleId",
                table: "Tickets",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Schedules_ScheduleId",
                table: "Tickets",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Schedules_ScheduleId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ScheduleId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b21e3bb-1eab-41fd-a24a-9e707c6575cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9999a08c-172c-4d90-8548-e21ed8482fd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd1cb31f-687b-4458-87a5-61d21dd680db");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5c1a37be-0600-424e-9d12-544ebc9fae5e", "58f7572a-c2aa-4468-bb89-057a5ab690b3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c1a37be-0600-424e-9d12-544ebc9fae5e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "58f7572a-c2aa-4468-bb89-057a5ab690b3");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01ef7b32-64b9-4c7d-9593-0fe242977a6c", null, "Member", "MEMBER" },
                    { "80f2f577-c9f0-46cc-98ab-681e3ba1fc65", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "ed036ca0-ae88-4dd9-a174-974b4bf75a9d", null, "Admin", "ADMIN" },
                    { "f164d462-aa44-4a11-a696-e06bda0b5177", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "26c01f9a-acde-48b4-8d08-0cf669ef4547", 0, "2152aa5b-7fb8-4fa5-8ff8-a38ff369ea35", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEG1j4w07dMJB7WHoBiff/obpegxXi/gkH26Le1Z46n0u8aXV5wLFu4MPgkRA5LRUhg==", null, false, "77b4542f-fabc-4325-9f76-ef7db0b2cc2e", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "01ef7b32-64b9-4c7d-9593-0fe242977a6c", "26c01f9a-acde-48b4-8d08-0cf669ef4547" });
        }
    }
}
