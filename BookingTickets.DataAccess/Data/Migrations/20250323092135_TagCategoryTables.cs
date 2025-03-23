using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class TagCategoryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cc2a692-3a91-4b3a-956c-25b328d5f619");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cf3b860-66d3-4bff-9645-414d9d6a7a5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5e8fe35-2982-4f05-9c2c-d68c2a953ec9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fbe0ae21-0794-4616-adf6-e5e421400809", "1f05bbd4-4c65-4448-913a-b64b82791a9f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbe0ae21-0794-4616-adf6-e5e421400809");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f05bbd4-4c65-4448-913a-b64b82791a9f");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57e116e4-0d33-4330-b1e0-a0742039140b", null, "Member", "MEMBER" },
                    { "58e34d72-822d-4619-9a36-2e74993222a6", null, "VipMember", "VIPMEMBER" },
                    { "b13d9921-7df4-4352-82a6-0c1dd0850d4d", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "d6f88d06-eea4-4c52-a3f8-ad6b80fd164d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce5a9007-de25-4f73-9911-56f704a0ac40", 0, "d7a72649-7c06-479e-848c-0a1aeeec241d", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEMBO/dRKrQMIsw1zTWKlhsmPu+mlbWPO0xcTyIuoyTbem5SuWZCuUm03yqhPiiU0nw==", null, false, "82a8a9e3-2a8b-431e-a83b-ab7d158d3363", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "57e116e4-0d33-4330-b1e0-a0742039140b", "ce5a9007-de25-4f73-9911-56f704a0ac40" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58e34d72-822d-4619-9a36-2e74993222a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b13d9921-7df4-4352-82a6-0c1dd0850d4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6f88d06-eea4-4c52-a3f8-ad6b80fd164d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57e116e4-0d33-4330-b1e0-a0742039140b", "ce5a9007-de25-4f73-9911-56f704a0ac40" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57e116e4-0d33-4330-b1e0-a0742039140b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce5a9007-de25-4f73-9911-56f704a0ac40");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cc2a692-3a91-4b3a-956c-25b328d5f619", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "8cf3b860-66d3-4bff-9645-414d9d6a7a5e", null, "Admin", "ADMIN" },
                    { "e5e8fe35-2982-4f05-9c2c-d68c2a953ec9", null, "VipMember", "VIPMEMBER" },
                    { "fbe0ae21-0794-4616-adf6-e5e421400809", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1f05bbd4-4c65-4448-913a-b64b82791a9f", 0, "9144152a-1419-42c2-b1cc-1ac3ed578848", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEHMscrnvnk4MRIKzcwYSpFFjYVUTgWuYX4K6PJrDKJekna4WdQZ2ASDxbVppd2rxqQ==", null, false, "66e27037-8448-4b92-ba5e-e3d5461f1299", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fbe0ae21-0794-4616-adf6-e5e421400809", "1f05bbd4-4c65-4448-913a-b64b82791a9f" });
        }
    }
}
