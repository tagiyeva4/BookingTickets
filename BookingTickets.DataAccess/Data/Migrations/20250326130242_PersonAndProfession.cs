using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonAndProfession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "MaxPrice",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinPrice",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPeron",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPeron", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPeron_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPeron_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "029b083d-23e9-46fc-a8e4-448cbcd313e9", null, "VipMember", "VIPMEMBER" },
                    { "0e8abaf7-bfb4-4fcc-a6d5-34103e15f6a1", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "9f1f3a5a-b14b-43b6-8ffa-13169c2b2672", null, "Member", "MEMBER" },
                    { "fc3d8ee9-53a4-452f-bd46-e545e4c66a63", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "90c1e2f0-8cbd-4d19-85e4-80eddea74beb", 0, "59114cce-a611-43ff-8aab-9c5da42daaf1", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEImZj1FJTMVXkRpU4JLjnil7+pxntpLsFqAdTNyRDTkeneoVB+cyZU5U/YeLkNsp1w==", null, false, "9e460ee5-cbf8-405c-92b6-62d34618b0f6", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f1f3a5a-b14b-43b6-8ffa-13169c2b2672", "90c1e2f0-8cbd-4d19-85e4-80eddea74beb" });

            migrationBuilder.CreateIndex(
                name: "IX_EventPeron_EventId",
                table: "EventPeron",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPeron_PersonId",
                table: "EventPeron",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_ProfessionId",
                table: "People",
                column: "ProfessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPeron");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "029b083d-23e9-46fc-a8e4-448cbcd313e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8abaf7-bfb4-4fcc-a6d5-34103e15f6a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc3d8ee9-53a4-452f-bd46-e545e4c66a63");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f1f3a5a-b14b-43b6-8ffa-13169c2b2672", "90c1e2f0-8cbd-4d19-85e4-80eddea74beb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f1f3a5a-b14b-43b6-8ffa-13169c2b2672");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90c1e2f0-8cbd-4d19-85e4-80eddea74beb");

            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "Events");

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
        }
    }
}
