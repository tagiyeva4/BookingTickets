using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class newPropertiesVenueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Capacity",
                table: "Venues");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Venues",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Venues",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "095c2a78-a518-4aea-9cf6-b26ac0a42d94", null, "Member", "MEMBER" },
                    { "467d1a60-e239-4b3b-a892-009b2908d791", null, "Admin", "ADMIN" },
                    { "76261068-0cee-4b6f-a0a2-f1a5cda792e7", null, "VipMember", "VIPMEMBER" },
                    { "e8483ad4-8791-4eb4-b38d-667f7265ea80", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "68ab3be1-b876-4b8f-82a5-fcb8745185c1", 0, "90b68287-2dbd-4f78-9cb4-634a9afb0491", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEP3rb1Hl+VaEhbAHloSSUJ06dIG0/zlLMTwIE+uNHnbxr7Wwox+Am3a231FEsScQnw==", null, false, "72ede054-adaf-4b05-8ccd-e07f18c2e05d", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "095c2a78-a518-4aea-9cf6-b26ac0a42d94", "68ab3be1-b876-4b8f-82a5-fcb8745185c1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "467d1a60-e239-4b3b-a892-009b2908d791");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76261068-0cee-4b6f-a0a2-f1a5cda792e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8483ad4-8791-4eb4-b38d-667f7265ea80");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "095c2a78-a518-4aea-9cf6-b26ac0a42d94", "68ab3be1-b876-4b8f-82a5-fcb8745185c1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "095c2a78-a518-4aea-9cf6-b26ac0a42d94");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68ab3be1-b876-4b8f-82a5-fcb8745185c1");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Venues");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
