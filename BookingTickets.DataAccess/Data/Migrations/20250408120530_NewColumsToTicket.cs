using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingTickets.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewColumsToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69958fc4-c087-4470-9103-0568d894adcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8323ee11-d5bc-4bce-9b4e-b2e071db73ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd08f04a-f36b-4ed5-bfcc-997fc19d1543");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01e64b03-dbdb-4be1-9020-77210dfa55ca", "1b0049af-1db7-481b-9310-f498c8ea3c08" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01e64b03-dbdb-4be1-9020-77210dfa55ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b0049af-1db7-481b-9310-f498c8ea3c08");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fceb1a9-9a93-49a3-bc55-cee75d28791b", null, "VipMember", "VIPMEMBER" },
                    { "8da1a34f-62e4-4266-9166-c8687bdaff13", null, "Member", "MEMBER" },
                    { "cebe24c8-35d6-4bcb-95b2-c0d151331392", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "e4affbe4-bc6f-433c-b032-bd97859a2af3", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66da0aa7-2192-41b6-9cc8-6894a1b03094", 0, "791e4851-1123-41fa-83b0-5834064c6726", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEO7v5ZyhoKJdCFz8NaWqv7X01zTZilqFsULNm3btVl0+ecPh/6s9sIrPXwW0nxfNCg==", null, false, "fb87ef3c-b16c-4e2c-ace4-4b0e233f502f", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8da1a34f-62e4-4266-9166-c8687bdaff13", "66da0aa7-2192-41b6-9cc8-6894a1b03094" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fceb1a9-9a93-49a3-bc55-cee75d28791b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cebe24c8-35d6-4bcb-95b2-c0d151331392");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4affbe4-bc6f-433c-b032-bd97859a2af3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8da1a34f-62e4-4266-9166-c8687bdaff13", "66da0aa7-2192-41b6-9cc8-6894a1b03094" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8da1a34f-62e4-4266-9166-c8687bdaff13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66da0aa7-2192-41b6-9cc8-6894a1b03094");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01e64b03-dbdb-4be1-9020-77210dfa55ca", null, "Member", "MEMBER" },
                    { "69958fc4-c087-4470-9103-0568d894adcf", null, "Admin", "ADMIN" },
                    { "8323ee11-d5bc-4bce-9b4e-b2e071db73ca", null, "EventOrganizer", "EVENTORGANIZER" },
                    { "bd08f04a-f36b-4ed5-bfcc-997fc19d1543", null, "VipMember", "VIPMEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1b0049af-1db7-481b-9310-f498c8ea3c08", 0, "ef2abea3-4a2b-4347-9547-fea31b098df1", null, false, "Test testov", false, null, null, "_TEST", "AQAAAAIAAYagAAAAEMswYLpAbx4aMbbPtegH2Vah7LaKZLlxkdiBU+lOpcTXz8ONqTkwKssD0tLjZKY0iA==", null, false, "45a4b6e3-9677-48d5-9cf3-992e23aa5cd8", false, "_test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "01e64b03-dbdb-4be1-9020-77210dfa55ca", "1b0049af-1db7-481b-9310-f498c8ea3c08" });
        }
    }
}
