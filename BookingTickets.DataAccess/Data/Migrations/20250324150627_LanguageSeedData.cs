using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class LanguageSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c55cb5b-b576-41aa-a768-92c455d0af87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6026c67c-a80c-49ce-b6d6-3fa723c57973");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce3055f6-0969-4246-b906-13152e3854d0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a2353bc-289e-4b76-94c9-743273d838ac", "9c778a1c-c4b3-4b5f-9c5a-60ab51421e61" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a2353bc-289e-4b76-94c9-743273d838ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c778a1c-c4b3-4b5f-9c5a-60ab51421e61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23028ac2-4360-444e-8a2c-c47bd89c90b3", null, "Member", "MEMBER" },
                    { "3ac53dc1-0428-4fdb-a721-706e71393713", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "65467e2d-336b-48e4-90be-00dccdf6a16e", null, "Admin", "ADMIN" },
                    { "8cc25c23-59f1-4434-9ce7-286dd16d0746", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e4b0dba-69de-4515-b673-2a9af003719d", 0, "9fc74a36-6a96-4f7c-a8a7-5defa822b384", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEPAXTQEsPRrkEdGuXC0AsHRyV0g0zop0tZPsPBootrKZ6ZWjToI06QgzrbRETDKK3g==", null, false, "a3a26cb4-609b-4388-8915-2c0e1ac4b086", false, "_test" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "az", "Azərbaycan" },
                    { 2, "tr", "Türkçe" },
                    { 3, "en", "English" },
                    { 4, "fr", "Français" },
                    { 5, "de", "Deutsch" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "23028ac2-4360-444e-8a2c-c47bd89c90b3", "4e4b0dba-69de-4515-b673-2a9af003719d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ac53dc1-0428-4fdb-a721-706e71393713");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65467e2d-336b-48e4-90be-00dccdf6a16e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc25c23-59f1-4434-9ce7-286dd16d0746");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23028ac2-4360-444e-8a2c-c47bd89c90b3", "4e4b0dba-69de-4515-b673-2a9af003719d" });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23028ac2-4360-444e-8a2c-c47bd89c90b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e4b0dba-69de-4515-b673-2a9af003719d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a2353bc-289e-4b76-94c9-743273d838ac", null, "Member", "MEMBER" },
                    { "3c55cb5b-b576-41aa-a768-92c455d0af87", null, "Admin", "ADMIN" },
                    { "6026c67c-a80c-49ce-b6d6-3fa723c57973", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "ce3055f6-0969-4246-b906-13152e3854d0", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c778a1c-c4b3-4b5f-9c5a-60ab51421e61", 0, "827dc407-c025-4131-bb2b-e30b68e3f361", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEPffqsJrRQCIbpqs6miM06fc5HVAX0GD35qnA+KsTl/4Jtdq7PJoUzKqR2NAiP7hBQ==", null, false, "a3fe4d54-0b4e-4a17-a575-09b3f66becfc", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2a2353bc-289e-4b76-94c9-743273d838ac", "9c778a1c-c4b3-4b5f-9c5a-60ab51421e61" });
        }
    }
}
