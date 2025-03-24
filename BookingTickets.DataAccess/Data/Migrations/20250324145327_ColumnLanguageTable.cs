using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColumnLanguageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e95837b-2126-471a-91c7-34f2044a15bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7090cb97-b048-4bd5-a892-073feee602b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "886398fa-0bf0-4257-bc46-796754327f56");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11fad5d0-2a25-44b0-898e-577769b4f014", "0f50aca4-440c-47df-aea9-5134f6d2ab0b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11fad5d0-2a25-44b0-898e-577769b4f014");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f50aca4-440c-47df-aea9-5134f6d2ab0b");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a2353bc-289e-4b76-94c9-743273d838ac", null, "Member", "MEMBER" },
                    { "3c55cb5b-b576-41aa-a768-92c455d0af87", null, "Admin", "ADMIN" },
                    { "6026c67c-a80c-49ce-b6d6-3fa723c57973", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "ce3055f6-0969-4246-b906-13152e3854d0", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c778a1c-c4b3-4b5f-9c5a-60ab51421e61", 0, "827dc407-c025-4131-bb2b-e30b68e3f361", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEPffqsJrRQCIbpqs6miM06fc5HVAX0GD35qnA+KsTl/4Jtdq7PJoUzKqR2NAiP7hBQ==", null, false, "a3fe4d54-0b4e-4a17-a575-09b3f66becfc", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2a2353bc-289e-4b76-94c9-743273d838ac", "9c778a1c-c4b3-4b5f-9c5a-60ab51421e61" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c55cb5b-b576-41aa-a768-92c455d0af87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6026c67c-a80c-49ce-b6d6-3fa723c57973");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce3055f6-0969-4246-b906-13152e3854d0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a2353bc-289e-4b76-94c9-743273d838ac", "9c778a1c-c4b3-4b5f-9c5a-60ab51421e61" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a2353bc-289e-4b76-94c9-743273d838ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c778a1c-c4b3-4b5f-9c5a-60ab51421e61");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Languages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11fad5d0-2a25-44b0-898e-577769b4f014", null, "Member", "MEMBER" },
                    { "4e95837b-2126-471a-91c7-34f2044a15bb", null, "Admin", "ADMIN" },
                    { "7090cb97-b048-4bd5-a892-073feee602b7", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "886398fa-0bf0-4257-bc46-796754327f56", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0f50aca4-440c-47df-aea9-5134f6d2ab0b", 0, "0224d520-06a2-4138-936e-267fe5a0a6ab", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEHlYcE0SWjdf5hAIVED2OZIJQ33isLq8GNp+n6ipjeMMUq9AqGat1OLQFwhEoVtqBg==", null, false, "e01e2e52-ddb5-43be-8e3f-c9bc5540745a", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11fad5d0-2a25-44b0-898e-577769b4f014", "0f50aca4-440c-47df-aea9-5134f6d2ab0b" });
        }
    }
}
