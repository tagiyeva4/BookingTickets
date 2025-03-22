using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c810b00-c6ba-4a84-b560-fb5f5a5a42a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ea1c19e-e96e-438d-a372-b7d9dd31ae0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e40b440b-c049-4d40-9650-23ddc1c5cdb8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d696b4a-6e5a-45f7-9ec0-b04e95b10fa5", "1f2463e2-ae9c-4b51-a72c-be0f399b1f65" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d696b4a-6e5a-45f7-9ec0-b04e95b10fa5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f2463e2-ae9c-4b51-a72c-be0f399b1f65");

            migrationBuilder.DropColumn(
                name: "WriteOn",
                table: "Blogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Blogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "WriteOn",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c810b00-c6ba-4a84-b560-fb5f5a5a42a4", null, "Admin", "ADMIN" },
                    { "4ea1c19e-e96e-438d-a372-b7d9dd31ae0b", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "8d696b4a-6e5a-45f7-9ec0-b04e95b10fa5", null, "Member", "MEMBER" },
                    { "e40b440b-c049-4d40-9650-23ddc1c5cdb8", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1f2463e2-ae9c-4b51-a72c-be0f399b1f65", 0, "8a84c603-158c-4ed5-8742-ac742aec98ec", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEAKX8kHE2+twkjZ4OxpBaniT0MYnLVFHvs/l3mnqb7z3x2u5o35JY5ENZG5vWpvaxg==", null, false, "ac71141c-94ba-4e91-95ff-9f8b9c4e4f05", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8d696b4a-6e5a-45f7-9ec0-b04e95b10fa5", "1f2463e2-ae9c-4b51-a72c-be0f399b1f65" });
        }
    }
}
