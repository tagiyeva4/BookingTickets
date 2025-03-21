using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class BlogTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriteOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogsComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    CommentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogsComment_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogsComment_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogsImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogsImage_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe208d2-d164-4098-9f0d-809721a9e9a4", null, "VipMember", "VIPMEMBER" },
                    { "aaa7bc0c-45a2-45ba-8323-8539baad832a", null, "Member", "MEMBER" },
                    { "b2567524-be2f-4cfc-a67f-3940b6ba3343", null, "Admin", "ADMIN" },
                    { "fcdf3c23-b42a-4806-bb37-381599e08662", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1795ccb2-5658-425c-a4dc-b6fa9c650706", 0, "125e95be-e572-45fe-ab54-8d56d7487f8e", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEPu0EyvARw0/9CP474Z92n5o3IS8WwnH+xeYG6ow7/MMHWxdj3I7SaJQA3kKORqvfQ==", null, false, "c9d68134-f955-494c-80b4-263f80115494", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aaa7bc0c-45a2-45ba-8323-8539baad832a", "1795ccb2-5658-425c-a4dc-b6fa9c650706" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogsComment_AppUserId",
                table: "BlogsComment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsComment_BlogId",
                table: "BlogsComment",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsImage_BlogId",
                table: "BlogsImage",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogsComment");

            migrationBuilder.DropTable(
                name: "BlogsImage");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe208d2-d164-4098-9f0d-809721a9e9a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2567524-be2f-4cfc-a67f-3940b6ba3343");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcdf3c23-b42a-4806-bb37-381599e08662");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aaa7bc0c-45a2-45ba-8323-8539baad832a", "1795ccb2-5658-425c-a4dc-b6fa9c650706" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaa7bc0c-45a2-45ba-8323-8539baad832a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1795ccb2-5658-425c-a4dc-b6fa9c650706");

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
    }
}
