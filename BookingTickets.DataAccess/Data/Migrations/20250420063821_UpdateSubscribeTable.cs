using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubscribeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23b3e056-4c0a-4dde-b6e3-9051d6bc3ea2", null, "Admin", "ADMIN" },
                    { "242bf206-3477-4c8d-9f82-ec3c779dcdea", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "4f4e1828-da6d-4325-a306-86caf4321da4", null, "VipMember", "VIPMEMBER" },
                    { "d27789ea-cbf8-456e-91f0-6eff7aba4b06", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e699faf9-bfe1-41cc-acd7-cd14e4efde33", 0, "27e27632-9f26-4804-a592-304c86a766e4", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEEtSWRIsbCGUnNxPmqRptPMS+v0GKWPttl4p2lzHH9CXabZmITl0PuXAfuiN7KnqCg==", null, false, "28572fef-af73-4c51-a81d-42d45af06a8b", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d27789ea-cbf8-456e-91f0-6eff7aba4b06", "e699faf9-bfe1-41cc-acd7-cd14e4efde33" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23b3e056-4c0a-4dde-b6e3-9051d6bc3ea2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "242bf206-3477-4c8d-9f82-ec3c779dcdea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f4e1828-da6d-4325-a306-86caf4321da4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d27789ea-cbf8-456e-91f0-6eff7aba4b06", "e699faf9-bfe1-41cc-acd7-cd14e4efde33" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d27789ea-cbf8-456e-91f0-6eff7aba4b06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e699faf9-bfe1-41cc-acd7-cd14e4efde33");

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
        }
    }
}
