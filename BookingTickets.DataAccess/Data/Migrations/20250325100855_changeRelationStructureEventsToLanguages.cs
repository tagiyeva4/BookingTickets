using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeRelationStructureEventsToLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Events_EventId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_EventId",
                table: "Languages");

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

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Languages");

            migrationBuilder.CreateTable(
                name: "EventLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLanguage_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f4ec701-3402-4de1-96b1-11756b07158c", null, "VipMember", "VIPMEMBER" },
                    { "8d492ffd-57f0-4863-8591-6762d690bf12", null, "Admin", "ADMIN" },
                    { "b4470974-0e2b-4773-9136-3ed2808e08f6", null, "Member", "MEMBER" },
                    { "ea458758-49d7-45fb-bde7-2e951a1c53b4", null, "EventOrganizer", "EVENTORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ced5150-4db6-4eb2-b627-f05a1c2d4841", 0, "3ff22c1e-5469-4406-8414-d4eddc1e5e7c", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAECchsmnwtueY083T0kx6E7B7U28LQRJ09EYliMldjG0IvT3wQv1ckMBDgYKuT+yugQ==", null, false, "2d265279-0391-4d46-81eb-cd963a60d016", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b4470974-0e2b-4773-9136-3ed2808e08f6", "4ced5150-4db6-4eb2-b627-f05a1c2d4841" });

            migrationBuilder.CreateIndex(
                name: "IX_EventLanguage_EventId",
                table: "EventLanguage",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLanguage_LanguageId",
                table: "EventLanguage",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f4ec701-3402-4de1-96b1-11756b07158c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d492ffd-57f0-4863-8591-6762d690bf12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea458758-49d7-45fb-bde7-2e951a1c53b4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4470974-0e2b-4773-9136-3ed2808e08f6", "4ced5150-4db6-4eb2-b627-f05a1c2d4841" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4470974-0e2b-4773-9136-3ed2808e08f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ced5150-4db6-4eb2-b627-f05a1c2d4841");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Languages",
                type: "int",
                nullable: true);

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
                values: new object[] { "6a257e26-db6b-47d2-a526-28101808392c", "444ea813-b3cc-4d7a-8795-2eed5c3a105d" });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_EventId",
                table: "Languages",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Events_EventId",
                table: "Languages",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
