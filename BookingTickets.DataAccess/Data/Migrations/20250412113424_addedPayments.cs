using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5a4148-29e2-4795-b767-ae250d2b8f72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c693cdb6-f7d7-42b7-a9eb-aa37a37f5a2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe52c765-94dc-435a-9d89-e4a2bc1f84bc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d8a9e6f6-d4ba-4752-928c-0e2b1ae6247b", "70688381-6906-44a5-b6f6-a6c1c5f0ec5c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a9e6f6-d4ba-4752-928c-0e2b1ae6247b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70688381-6906-44a5-b6f6-a6c1c5f0ec5c");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ReceptId = table.Column<int>(type: "int", nullable: false),
                    SecretId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

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

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5a4148-29e2-4795-b767-ae250d2b8f72", null, "Admin", "ADMIN" },
                    { "c693cdb6-f7d7-42b7-a9eb-aa37a37f5a2e", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "d8a9e6f6-d4ba-4752-928c-0e2b1ae6247b", null, "Member", "MEMBER" },
                    { "fe52c765-94dc-435a-9d89-e4a2bc1f84bc", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "70688381-6906-44a5-b6f6-a6c1c5f0ec5c", 0, "ccfe339a-ae8d-4e67-9d9d-38dd521f823a", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEH5Caqas185+E77PxKnniZijBzHn1hVZ+sIEYZ+P9zWddK4JxBmJtJGzGCItluy2Hg==", null, false, "6ecd3bed-57fc-4433-bb47-895d92d7b153", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d8a9e6f6-d4ba-4752-928c-0e2b1ae6247b", "70688381-6906-44a5-b6f6-a6c1c5f0ec5c" });
        }
    }
}
