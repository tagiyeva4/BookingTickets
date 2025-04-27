using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedChatsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bfe4ad2-e2b9-4d3b-8307-3b3b5827115f", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "60560dc4-1c60-48c2-bdb4-25238b7a944b", null, "Admin", "ADMIN" },
                    { "7542485b-709e-4031-ba87-b418ee59dcb0", null, "Member", "MEMBER" },
                    { "f7486ded-b0e8-4f67-88be-2ab581715381", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "863374a1-eb33-42c7-8208-2950e4045501", 0, "0bb69bb5-a752-4ffa-b929-191ce3157e85", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEObJU6Ffb56nyMoz4955xaGsnaHDtoamqpCz0vGS7hIoXrrW9pn2tAv00uU+eI7X7w==", null, false, "625a7606-dee9-4914-8269-d9bf66464529", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7542485b-709e-4031-ba87-b418ee59dcb0", "863374a1-eb33-42c7-8208-2950e4045501" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bfe4ad2-e2b9-4d3b-8307-3b3b5827115f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60560dc4-1c60-48c2-bdb4-25238b7a944b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7486ded-b0e8-4f67-88be-2ab581715381");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7542485b-709e-4031-ba87-b418ee59dcb0", "863374a1-eb33-42c7-8208-2950e4045501" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7542485b-709e-4031-ba87-b418ee59dcb0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "863374a1-eb33-42c7-8208-2950e4045501");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chats");

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
        }
    }
}
