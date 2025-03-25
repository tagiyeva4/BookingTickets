using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EventsImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsImage_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27daca8f-7710-4e1c-bd8d-738467eb141d", null, "Admin", "ADMIN" },
                    { "6a257e26-db6b-47d2-a526-28101808392c", null, "Member", "MEMBER" },
                    { "8a727a7e-f658-48c1-90ad-19de6a6db18a", null, "VipMember", "VIPMEMBER" },
                    { "e4594b1c-3952-4dd8-8f30-024a8192b0d2", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "444ea813-b3cc-4d7a-8795-2eed5c3a105d", 0, "8397cb6a-54e4-4d6f-8aab-8a5244528ced", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEJez5c3rUC9CMFVfdjFtJyjy6MXXB7XzClwrcKfLDHrGcV6Ko9hOcB5drIML/bwetQ==", null, false, "2580091e-d0de-4ed3-b8b2-040d1958003d", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6a257e26-db6b-47d2-a526-28101808392c", "444ea813-b3cc-4d7a-8795-2eed5c3a105d" });

            migrationBuilder.CreateIndex(
                name: "IX_EventsImage_EventId",
                table: "EventsImage",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsImage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27daca8f-7710-4e1c-bd8d-738467eb141d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a727a7e-f658-48c1-90ad-19de6a6db18a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4594b1c-3952-4dd8-8f30-024a8192b0d2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a257e26-db6b-47d2-a526-28101808392c", "444ea813-b3cc-4d7a-8795-2eed5c3a105d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a257e26-db6b-47d2-a526-28101808392c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "444ea813-b3cc-4d7a-8795-2eed5c3a105d");

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
    }
}
