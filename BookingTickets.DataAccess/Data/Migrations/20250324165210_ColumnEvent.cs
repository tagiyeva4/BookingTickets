using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColumnEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52b8f6bc-1909-4cbe-8a03-9b28eedef1e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bacff70-5e47-471d-ae7e-415e1e771b42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2384d67-3556-4be6-afa7-c30bcb55816e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5abe0537-8613-47e6-bbc4-6f23b396d72b", "0d7172dc-722d-4422-b3b9-2299f26f5d52" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5abe0537-8613-47e6-bbc4-6f23b396d72b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d7172dc-722d-4422-b3b9-2299f26f5d52");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cd7eb47-2781-4873-b00e-3349dc7e5c1f", null, "Member", "MEMBER" },
                    { "43df6d7d-5649-456c-ba8c-7b0b91b727e7", null, "Admin", "ADMIN" },
                    { "48e5847d-1459-4e09-90f6-bd28b3c593af", null, "VipMember", "VIPMEMBER" },
                    { "db651470-6fe2-481c-b061-3d0a46143210", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6e07e1bb-3882-485d-841c-7459862a5d77", 0, "6e6fefd1-3c5c-4e53-8684-c4754566ef5c", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEPlPbzxiPgiJEb/l2ZNVwsMxLkddnV/6v+Qw2wR8R4W8RJtmXI6I9RDVVgRrqN2wVg==", null, false, "782eaa75-e0f5-4a05-a560-9554090a8228", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3cd7eb47-2781-4873-b00e-3349dc7e5c1f", "6e07e1bb-3882-485d-841c-7459862a5d77" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43df6d7d-5649-456c-ba8c-7b0b91b727e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48e5847d-1459-4e09-90f6-bd28b3c593af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db651470-6fe2-481c-b061-3d0a46143210");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3cd7eb47-2781-4873-b00e-3349dc7e5c1f", "6e07e1bb-3882-485d-841c-7459862a5d77" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cd7eb47-2781-4873-b00e-3349dc7e5c1f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e07e1bb-3882-485d-841c-7459862a5d77");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52b8f6bc-1909-4cbe-8a03-9b28eedef1e3", null, "Admin", "ADMIN" },
                    { "5abe0537-8613-47e6-bbc4-6f23b396d72b", null, "Member", "MEMBER" },
                    { "6bacff70-5e47-471d-ae7e-415e1e771b42", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "a2384d67-3556-4be6-afa7-c30bcb55816e", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0d7172dc-722d-4422-b3b9-2299f26f5d52", 0, "2442e0cb-2338-47b5-b545-f99b985d6201", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEHJ5UOc8j3u/K2jfRnyseEjhWc+0RHZp0lulbAK/L0OB/FAfZIgs9x6GVXuBMSRLbA==", null, false, "b5182858-04e2-4a7e-91a7-abd7074c9b0a", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5abe0537-8613-47e6-bbc4-6f23b396d72b", "0d7172dc-722d-4422-b3b9-2299f26f5d52" });
        }
    }
}
