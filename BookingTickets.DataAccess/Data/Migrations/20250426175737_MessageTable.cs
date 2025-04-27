using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class MessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7073c8ea-a6ce-4385-be31-62c2057a0937");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89c281d0-dc12-4ad8-85e9-c944be0912a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db297895-c0b5-4150-aecc-bdd53ae2afe0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "268817f0-e963-4b52-8bfa-7512184059bd", "c9859979-e9af-4e20-ab24-94683ee9d391" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "268817f0-e963-4b52-8bfa-7512184059bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9859979-e9af-4e20-ab24-94683ee9d391");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a94df43-0c51-4b82-b354-ee6970da4ba5", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "94f6e507-8c3e-4ac6-aa2f-ec422d903e3a", null, "Admin", "ADMIN" },
                    { "f4b3aae9-680c-48af-b4d3-1fba8c3c262c", null, "Member", "MEMBER" },
                    { "fda24795-a93e-4238-8994-b7789b1391e1", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f0ef9ff5-cf80-4a25-8e43-b672e206dd6f", 0, "060f209f-f588-4b15-9c68-afe80053ec1f", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEMIloTPyUpeTN3NdHPaSuCtxI/twrFq+wVj+zRM6ch25PIcHZ6BU9X8ktmV8V3fdaQ==", null, false, "ee46342f-32e6-4729-877e-538b335b479a", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f4b3aae9-680c-48af-b4d3-1fba8c3c262c", "f0ef9ff5-cf80-4a25-8e43-b672e206dd6f" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a94df43-0c51-4b82-b354-ee6970da4ba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94f6e507-8c3e-4ac6-aa2f-ec422d903e3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fda24795-a93e-4238-8994-b7789b1391e1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f4b3aae9-680c-48af-b4d3-1fba8c3c262c", "f0ef9ff5-cf80-4a25-8e43-b672e206dd6f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b3aae9-680c-48af-b4d3-1fba8c3c262c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0ef9ff5-cf80-4a25-8e43-b672e206dd6f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "268817f0-e963-4b52-8bfa-7512184059bd", null, "Member", "MEMBER" },
                    { "7073c8ea-a6ce-4385-be31-62c2057a0937", null, "Admin", "ADMIN" },
                    { "89c281d0-dc12-4ad8-85e9-c944be0912a7", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "db297895-c0b5-4150-aecc-bdd53ae2afe0", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c9859979-e9af-4e20-ab24-94683ee9d391", 0, "293989e4-1fb9-43b7-8e9b-026250d7255b", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAECQd86aaKq0QPUsz1N7OfD3+zUaIb5fzBGhzBNGKgd4KyO9ex0618H+agN1WHV5Tpw==", null, false, "ff4e1d20-9442-4426-8ba0-0e328fc25c82", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "268817f0-e963-4b52-8bfa-7512184059bd", "c9859979-e9af-4e20-ab24-94683ee9d391" });
        }
    }
}
