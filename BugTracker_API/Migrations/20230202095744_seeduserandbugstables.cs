using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeduserandbugstables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BugId",
                table: "Bugs",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 1, "TestUsername1" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "DateCreated", "Description", "Status", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2023, 2, 2, 9, 57, 44, 640, DateTimeKind.Local).AddTicks(315), "TestDescription1", 0, "TestTitle1", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bugs",
                newName: "BugId");
        }
    }
}
