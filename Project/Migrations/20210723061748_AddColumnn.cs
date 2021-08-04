using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class AddColumnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "products",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 380, DateTimeKind.Local).AddTicks(2692), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8801), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8835), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8839), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8842), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8845), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8851), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8853), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8856), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8858), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8862), 299 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 17, 47, 381, DateTimeKind.Local).AddTicks(8864), 299 });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 23, 13, 17, 47, 386, DateTimeKind.Local).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 23, 13, 17, 47, 386, DateTimeKind.Local).AddTicks(2664));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 682, DateTimeKind.Local).AddTicks(328), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8808), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8883), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8890), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8896), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8900), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8905), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8910), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8915), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8920), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8926), 299m });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Price" },
                values: new object[] { new DateTime(2021, 7, 23, 13, 13, 58, 683, DateTimeKind.Local).AddTicks(8931), 299m });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 23, 13, 13, 58, 684, DateTimeKind.Local).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 7, 23, 13, 13, 58, 684, DateTimeKind.Local).AddTicks(7733));
        }
    }
}
