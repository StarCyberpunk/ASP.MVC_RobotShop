using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace second.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BasketAndOrders3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Robot",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 2, 6, 15, 26, 52, 860, DateTimeKind.Local).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Robot",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2023, 2, 6, 15, 26, 52, 860, DateTimeKind.Local).AddTicks(3474));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Robot",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 2, 6, 13, 37, 7, 818, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "Robot",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2023, 2, 6, 13, 37, 7, 818, DateTimeKind.Local).AddTicks(1052));
        }
    }
}
