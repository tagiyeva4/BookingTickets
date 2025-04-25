using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "268817f0-e963-4b52-8bfa-7512184059bd", null, "Member", "MEMBER" },
                    { "7073c8ea-a6ce-4385-be31-62c2057a0937", null, "Admin", "ADMIN" },
                    { "89c281d0-dc12-4ad8-85e9-c944be0912a7", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "db297895-c0b5-4150-aecc-bdd53ae2afe0", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c9859979-e9af-4e20-ab24-94683ee9d391", 0, "293989e4-1fb9-43b7-8e9b-026250d7255b", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAECQd86aaKq0QPUsz1N7OfD3+zUaIb5fzBGhzBNGKgd4KyO9ex0618H+agN1WHV5Tpw==", null, false, "ff4e1d20-9442-4426-8ba0-0e328fc25c82", false, "_test" });

            migrationBuilder.UpdateData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A person who performs songs using their voice. They express emotions and tell stories through music");

            migrationBuilder.UpdateData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A person who speaks in public or delivers speeches. They aim to inform, inspire, or persuade an audience.");

            migrationBuilder.UpdateData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: " A person who designs, builds, and maintains computer programs. They solve problems using code and create digital solutions.");

            migrationBuilder.UpdateData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "A professional who gives legal advice and represents people in court. They help solve disputes and protect rights.");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "268817f0-e963-4b52-8bfa-7512184059bd", "c9859979-e9af-4e20-ab24-94683ee9d391" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7073c8ea-a6ce-4385-be31-62c2057a0937");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89c281d0-dc12-4ad8-85e9-c944be0912a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db297895-c0b5-4150-aecc-bdd53ae2afe0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "268817f0-e963-4b52-8bfa-7512184059bd", "c9859979-e9af-4e20-ab24-94683ee9d391" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "268817f0-e963-4b52-8bfa-7512184059bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9859979-e9af-4e20-ab24-94683ee9d391");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Services");

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
    }
}
