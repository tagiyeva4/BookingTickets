using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class addDescColumProfession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23b3e056-4c0a-4dde-b6e3-9051d6bc3ea2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "242bf206-3477-4c8d-9f82-ec3c779dcdea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f4e1828-da6d-4325-a306-86caf4321da4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d27789ea-cbf8-456e-91f0-6eff7aba4b06", "e699faf9-bfe1-41cc-acd7-cd14e4efde33" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d27789ea-cbf8-456e-91f0-6eff7aba4b06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e699faf9-bfe1-41cc-acd7-cd14e4efde33");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Professions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5732fea0-9716-4d57-9fff-62724d01fc48", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "5b633b2d-45a5-404d-aded-0380fac54637", null, "VipMember", "VIPMEMBER" },
                    { "61032311-1bb7-4d68-94a6-3f0cec3ef308", null, "Member", "MEMBER" },
                    { "c066ef40-d84d-4839-aedb-33373000d7e9", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "12b6c71d-465a-4cec-b87e-4c202ba6d439", 0, "e9f1ff72-f2a2-431f-acb6-7c4c0646a926", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEGqhFIsqwrNzbBo5fllFQSsMWsTaF6a/eJ2CJ4t/isfLgxcLbeUZZmIQewLl5OH8fQ==", null, false, "2d0d95e1-2ead-43d8-8da5-34538b4e71af", false, "_test" });

            migrationBuilder.UpdateData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "61032311-1bb7-4d68-94a6-3f0cec3ef308", "12b6c71d-465a-4cec-b87e-4c202ba6d439" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5732fea0-9716-4d57-9fff-62724d01fc48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b633b2d-45a5-404d-aded-0380fac54637");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c066ef40-d84d-4839-aedb-33373000d7e9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "61032311-1bb7-4d68-94a6-3f0cec3ef308", "12b6c71d-465a-4cec-b87e-4c202ba6d439" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61032311-1bb7-4d68-94a6-3f0cec3ef308");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12b6c71d-465a-4cec-b87e-4c202ba6d439");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Professions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23b3e056-4c0a-4dde-b6e3-9051d6bc3ea2", null, "Admin", "ADMIN" },
                    { "242bf206-3477-4c8d-9f82-ec3c779dcdea", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "4f4e1828-da6d-4325-a306-86caf4321da4", null, "VipMember", "VIPMEMBER" },
                    { "d27789ea-cbf8-456e-91f0-6eff7aba4b06", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e699faf9-bfe1-41cc-acd7-cd14e4efde33", 0, "27e27632-9f26-4804-a592-304c86a766e4", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEEtSWRIsbCGUnNxPmqRptPMS+v0GKWPttl4p2lzHH9CXabZmITl0PuXAfuiN7KnqCg==", null, false, "28572fef-af73-4c51-a81d-42d45af06a8b", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d27789ea-cbf8-456e-91f0-6eff7aba4b06", "e699faf9-bfe1-41cc-acd7-cd14e4efde33" });
        }
    }
}
