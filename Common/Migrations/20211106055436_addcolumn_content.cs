using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class addcolumn_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "feedbacks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "feedbacks",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 793, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 795, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 796, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 12, 54, 35, 796, DateTimeKind.Local).AddTicks(3592));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "feedbacks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "feedbacks",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 304, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 307, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 307, DateTimeKind.Local).AddTicks(9017));
        }
    }
}
