using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ac53dc1-0428-4fdb-a721-706e71393713");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65467e2d-336b-48e4-90be-00dccdf6a16e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc25c23-59f1-4434-9ce7-286dd16d0746");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23028ac2-4360-444e-8a2c-c47bd89c90b3", "4e4b0dba-69de-4515-b673-2a9af003719d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23028ac2-4360-444e-8a2c-c47bd89c90b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e4b0dba-69de-4515-b673-2a9af003719d");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccess = table.Column<bool>(type: "bit", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "EventId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "EventId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "EventId",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5abe0537-8613-47e6-bbc4-6f23b396d72b", "0d7172dc-722d-4422-b3b9-2299f26f5d52" });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_EventId",
                table: "Languages",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Events_EventId",
                table: "Languages",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Events_EventId",
                table: "Languages");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Languages_EventId",
                table: "Languages");

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

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Languages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23028ac2-4360-444e-8a2c-c47bd89c90b3", null, "Member", "MEMBER" },
                    { "3ac53dc1-0428-4fdb-a721-706e71393713", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "65467e2d-336b-48e4-90be-00dccdf6a16e", null, "Admin", "ADMIN" },
                    { "8cc25c23-59f1-4434-9ce7-286dd16d0746", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e4b0dba-69de-4515-b673-2a9af003719d", 0, "9fc74a36-6a96-4f7c-a8a7-5defa822b384", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEPAXTQEsPRrkEdGuXC0AsHRyV0g0zop0tZPsPBootrKZ6ZWjToI06QgzrbRETDKK3g==", null, false, "a3a26cb4-609b-4388-8915-2c0e1ac4b086", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "23028ac2-4360-444e-8a2c-c47bd89c90b3", "4e4b0dba-69de-4515-b673-2a9af003719d" });
        }
    }
}
