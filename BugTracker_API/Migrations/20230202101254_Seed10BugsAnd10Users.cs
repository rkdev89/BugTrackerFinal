using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seed10BugsAnd10Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 2, "TestUsername2" },
                    { 3, "TestUsername3" },
                    { 4, "TestUsername4" },
                    { 5, "TestUsername5" },
                    { 6, "TestUsername6" },
                    { 7, "TestUsername7" },
                    { 8, "TestUsername8" },
                    { 9, "TestUsername9" },
                    { 10, "TestUsername10" }
                });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "DateCreated", "Description", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(1992), "TestDescription2", 0, "TestTitle2", 2 },
                    { 3, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2009), "TestDescription3", 0, "TestTitle3", 3 },
                    { 4, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2027), "TestDescription4", 0, "TestTitle4", 4 },
                    { 5, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2046), "TestDescription5", 0, "TestTitle5", 5 },
                    { 6, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2064), "TestDescription6", 0, "TestTitle6", 6 },
                    { 7, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2080), "TestDescription7", 0, "TestTitle7", 7 },
                    { 8, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2132), "TestDescription8", 0, "TestTitle8", 8 },
                    { 9, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2150), "TestDescription9", 0, "TestTitle9", 9 },
                    { 10, new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2168), "TestDescription10", 0, "TestTitle10", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 3, 7, 126, DateTimeKind.Local).AddTicks(8026));
        }
    }
}
