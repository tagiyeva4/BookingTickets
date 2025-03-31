using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class TicketTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    QRCodePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidationToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dd6915f-53d4-4b90-81d6-e5bd6e048900", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "56d8859f-ffde-40cd-97a1-7655b74575c9", null, "Member", "MEMBER" },
                    { "db32338b-d27e-48f8-aaa0-fa630024c782", null, "Admin", "ADMIN" },
                    { "ea3ddfbe-286a-494d-8e74-2018ca3bc12e", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9636705a-ca59-4ded-806f-08f0e75f6820", 0, "da132ec8-9105-44e0-97da-2447a53a11f6", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEFldaXLcejQdKKCuzBWiucY5X8yGqKBV7WL1wjEUu1HLJE3g0mghl0gDDYkH6qPHKA==", null, false, "53c0128a-3616-472b-839f-bc4eb479dfb8", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "56d8859f-ffde-40cd-97a1-7655b74575c9", "9636705a-ca59-4ded-806f-08f0e75f6820" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AppUserId",
                table: "Tickets",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dd6915f-53d4-4b90-81d6-e5bd6e048900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db32338b-d27e-48f8-aaa0-fa630024c782");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea3ddfbe-286a-494d-8e74-2018ca3bc12e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "56d8859f-ffde-40cd-97a1-7655b74575c9", "9636705a-ca59-4ded-806f-08f0e75f6820" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56d8859f-ffde-40cd-97a1-7655b74575c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9636705a-ca59-4ded-806f-08f0e75f6820");

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
    }
}
