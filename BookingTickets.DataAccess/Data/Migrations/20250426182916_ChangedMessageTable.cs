using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages");

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

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserChats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserChats_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b9c12ed-7f26-495e-b989-3d626f5ebd85", null, "VipMember", "VIPMEMBER" },
                    { "9a85ac6d-f338-4d17-a6d2-d5d1a9bbc802", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "a07135d2-faae-4906-bab4-6b4f97eb14cb", null, "Admin", "ADMIN" },
                    { "adae2b77-c53a-478a-b0c3-bf2bd7eb5032", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f47de590-f476-417a-9feb-13d8b2ef6681", 0, "178171e5-12dc-4359-a0e9-c1dbf1547837", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEImwIhy0JS2Y8hR57yogDa+PVazBUWc3JNLIVNO6kyte2miIWxbRKFSH67NBPIbbzQ==", null, false, "818f18a8-171e-47d1-8c83-25200a78975d", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "adae2b77-c53a-478a-b0c3-bf2bd7eb5032", "f47de590-f476-417a-9feb-13d8b2ef6681" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserChats_AppUserId",
                table: "AppUserChats",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserChats_ChatId",
                table: "AppUserChats",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "AppUserChats");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b9c12ed-7f26-495e-b989-3d626f5ebd85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a85ac6d-f338-4d17-a6d2-d5d1a9bbc802");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a07135d2-faae-4906-bab4-6b4f97eb14cb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "adae2b77-c53a-478a-b0c3-bf2bd7eb5032", "f47de590-f476-417a-9feb-13d8b2ef6681" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adae2b77-c53a-478a-b0c3-bf2bd7eb5032");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f47de590-f476-417a-9feb-13d8b2ef6681");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
