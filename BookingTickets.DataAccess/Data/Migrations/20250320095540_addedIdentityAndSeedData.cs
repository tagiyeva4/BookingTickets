using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedIdentityAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubscribeEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribeEmails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c6ec3f8-f2c1-479e-8912-117282f7e991", null, "Admin", "ADMIN" },
                    { "d90120c6-2a12-4005-baeb-5f34ee816d9e", null, "VipMember", "VIPMEMBER" },
                    { "e75f72c5-f75a-4391-90b6-4107a3ad5a5b", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "ea750971-f479-4aad-afb2-6133ecae1fdc", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cb6be47f-6125-40a6-a237-ba5642963f26", 0, "4ef333d7-6f9c-46d5-a7af-ae81daa75607", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEEWtUGCbTP3qWuiszzW4oiUjJAE4ND+F7cWRXmiBciCBt2Hu8e4fGVuawK59GQIBNQ==", null, false, "cd1aa63a-96ce-4172-aaca-bd5902068690", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ea750971-f479-4aad-afb2-6133ecae1fdc", "cb6be47f-6125-40a6-a237-ba5642963f26" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscribeEmails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c6ec3f8-f2c1-479e-8912-117282f7e991");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d90120c6-2a12-4005-baeb-5f34ee816d9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e75f72c5-f75a-4391-90b6-4107a3ad5a5b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ea750971-f479-4aad-afb2-6133ecae1fdc", "cb6be47f-6125-40a6-a237-ba5642963f26" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea750971-f479-4aad-afb2-6133ecae1fdc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb6be47f-6125-40a6-a237-ba5642963f26");
        }
    }
}
