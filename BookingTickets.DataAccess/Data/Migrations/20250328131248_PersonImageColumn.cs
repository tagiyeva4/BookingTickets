using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonImageColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b624d2a-ee3e-4807-9e85-3eee23348253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4905666b-7223-470f-af23-336b22e69171");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8d42d15-687d-4785-b5c9-092cbbc55aed");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "562ad5be-a848-4afe-9e2f-5abef4e89dc2", "e4644362-8ab4-46ac-80ac-e4cc782deb02" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "562ad5be-a848-4afe-9e2f-5abef4e89dc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4644362-8ab4-46ac-80ac-e4cc782deb02");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e69313b-3edc-46a0-bcce-90331921e3d9", null, "VipMember", "VIPMEMBER" },
                    { "230ebbb5-f396-4c0a-bf10-6f8e2c57cd9a", null, "Member", "MEMBER" },
                    { "41e58a8a-2745-4493-a00e-2c81ac8e3ca8", null, "Admin", "ADMIN" },
                    { "ffc59304-33f5-42b4-9772-8529d463f949", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a80efdc8-6976-4196-a9ad-53b3bf4ed5b6", 0, "4f4d4585-5ef2-4484-a55b-3291a6d26a55", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEF/b5TBB5jN821yZL4ASrAN+fOJFz9IoH4hEOEUH4XvcX5cUj8nN5IJFzVhkjFeMnw==", null, false, "0ba1c35f-ad96-4118-b95a-b6dacbb96159", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "230ebbb5-f396-4c0a-bf10-6f8e2c57cd9a", "a80efdc8-6976-4196-a9ad-53b3bf4ed5b6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e69313b-3edc-46a0-bcce-90331921e3d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41e58a8a-2745-4493-a00e-2c81ac8e3ca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc59304-33f5-42b4-9772-8529d463f949");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "230ebbb5-f396-4c0a-bf10-6f8e2c57cd9a", "a80efdc8-6976-4196-a9ad-53b3bf4ed5b6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "230ebbb5-f396-4c0a-bf10-6f8e2c57cd9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a80efdc8-6976-4196-a9ad-53b3bf4ed5b6");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "People");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b624d2a-ee3e-4807-9e85-3eee23348253", null, "Admin", "ADMIN" },
                    { "4905666b-7223-470f-af23-336b22e69171", null, "VipMember", "VIPMEMBER" },
                    { "562ad5be-a848-4afe-9e2f-5abef4e89dc2", null, "Member", "MEMBER" },
                    { "f8d42d15-687d-4785-b5c9-092cbbc55aed", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4644362-8ab4-46ac-80ac-e4cc782deb02", 0, "1bedd11e-4140-4f32-a67d-12904a1bcdec", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEA1h+/8PU5sApOKPVizxQkUGGN2b2o4D7Caao3If+xtQ8laIekjSPZ8vlKhBPY/5JA==", null, false, "7c74a0b6-eaa8-41ef-8774-4c4665169cfa", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "562ad5be-a848-4afe-9e2f-5abef4e89dc2", "e4644362-8ab4-46ac-80ac-e4cc782deb02" });
        }
    }
}
