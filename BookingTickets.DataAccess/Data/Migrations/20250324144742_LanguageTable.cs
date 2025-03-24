using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class LanguageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e3d6b6-3bcb-4541-ab47-f0bd31977130");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7842420-9db6-4523-b679-5ab625c148be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d62f6fa7-68ef-4aa4-83fd-501247fe1011");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45a33bfc-f46c-415d-bfce-8e7ead46b2c1", "565090c0-f444-4fdf-8a87-3909ae1a55c0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45a33bfc-f46c-415d-bfce-8e7ead46b2c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "565090c0-f444-4fdf-8a87-3909ae1a55c0");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45a33bfc-f46c-415d-bfce-8e7ead46b2c1", null, "Member", "MEMBER" },
                    { "71e3d6b6-3bcb-4541-ab47-f0bd31977130", null, "VipMember", "VIPMEMBER" },
                    { "b7842420-9db6-4523-b679-5ab625c148be", null, "Admin", "ADMIN" },
                    { "d62f6fa7-68ef-4aa4-83fd-501247fe1011", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "565090c0-f444-4fdf-8a87-3909ae1a55c0", 0, "3229e076-aba8-4bee-a638-43e7e24565a5", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEE8G1cGhSdMRm1a2uS4KHFCxFBFPbP1spxxMDtdhQS1BAdDvIPqNMrtvoCLAfzR57A==", null, false, "47f72941-b6be-4035-8485-1c77f18ba78b", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "45a33bfc-f46c-415d-bfce-8e7ead46b2c1", "565090c0-f444-4fdf-8a87-3909ae1a55c0" });
        }
    }
}
