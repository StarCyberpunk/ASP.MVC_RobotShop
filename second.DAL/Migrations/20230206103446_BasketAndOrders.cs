using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace second.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BasketAndOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasketId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1L, 1L });

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

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketId",
                table: "Orders",
                column: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.UpdateData(
                table: "Robot",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 1, 25, 20, 6, 48, 419, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "Robot",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2023, 1, 25, 20, 6, 48, 419, DateTimeKind.Local).AddTicks(3889));
        }
    }
}
