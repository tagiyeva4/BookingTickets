using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProfessionSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "029b083d-23e9-46fc-a8e4-448cbcd313e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8abaf7-bfb4-4fcc-a6d5-34103e15f6a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc3d8ee9-53a4-452f-bd46-e545e4c66a63");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f1f3a5a-b14b-43b6-8ffa-13169c2b2672", "90c1e2f0-8cbd-4d19-85e4-80eddea74beb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f1f3a5a-b14b-43b6-8ffa-13169c2b2672");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90c1e2f0-8cbd-4d19-85e4-80eddea74beb");

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
                table: "Professions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Singer" },
                    { 2, "Speaker" },
                    { 3, "Software Developer" },
                    { 4, "Lawyer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8296e782-f04c-427e-858a-7a0d5a0c3579", "c3031710-0dd5-4fca-b6e8-972381d3d24d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8296e782-f04c-427e-858a-7a0d5a0c3579");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3031710-0dd5-4fca-b6e8-972381d3d24d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "029b083d-23e9-46fc-a8e4-448cbcd313e9", null, "VipMember", "VIPMEMBER" },
                    { "0e8abaf7-bfb4-4fcc-a6d5-34103e15f6a1", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "9f1f3a5a-b14b-43b6-8ffa-13169c2b2672", null, "Member", "MEMBER" },
                    { "fc3d8ee9-53a4-452f-bd46-e545e4c66a63", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "90c1e2f0-8cbd-4d19-85e4-80eddea74beb", 0, "59114cce-a611-43ff-8aab-9c5da42daaf1", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEImZj1FJTMVXkRpU4JLjnil7+pxntpLsFqAdTNyRDTkeneoVB+cyZU5U/YeLkNsp1w==", null, false, "9e460ee5-cbf8-405c-92b6-62d34618b0f6", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f1f3a5a-b14b-43b6-8ffa-13169c2b2672", "90c1e2f0-8cbd-4d19-85e4-80eddea74beb" });
        }
    }
}
