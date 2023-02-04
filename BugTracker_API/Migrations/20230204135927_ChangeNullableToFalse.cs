using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullableToFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4243));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 2, 4, 13, 59, 27, 337, DateTimeKind.Local).AddTicks(4294));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 2, 2, 10, 12, 54, 607, DateTimeKind.Local).AddTicks(2168));
        }
    }
}
