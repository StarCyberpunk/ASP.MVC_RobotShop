using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace second.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BasketAndOrders2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Orders",
                newName: "RobotId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RobotId",
                table: "Orders",
                newName: "CarId");

            migrationBuilder.UpdateData(
                table: "Robot",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 2, 6, 13, 34, 46, 238, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Robot",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2023, 2, 6, 13, 34, 46, 238, DateTimeKind.Local).AddTicks(3716));
        }
    }
}
