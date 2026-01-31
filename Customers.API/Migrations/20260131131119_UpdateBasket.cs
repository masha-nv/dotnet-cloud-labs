using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Buskets_CustomerBusketId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Buskets");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Items",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "CustomerBusketId",
                table: "Items",
                newName: "CustomerBasketId");

            migrationBuilder.RenameColumn(
                name: "BusketId",
                table: "Items",
                newName: "BasketId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CustomerBusketId",
                table: "Items",
                newName: "IX_Items_CustomerBasketId");

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CustomerId",
                table: "Baskets",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Baskets_CustomerBasketId",
                table: "Items",
                column: "CustomerBasketId",
                principalTable: "Baskets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Baskets_CustomerBasketId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Items",
                newName: "MyProperty");

            migrationBuilder.RenameColumn(
                name: "CustomerBasketId",
                table: "Items",
                newName: "CustomerBusketId");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Items",
                newName: "BusketId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CustomerBasketId",
                table: "Items",
                newName: "IX_Items_CustomerBusketId");

            migrationBuilder.CreateTable(
                name: "Buskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buskets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buskets_CustomerId",
                table: "Buskets",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Buskets_CustomerBusketId",
                table: "Items",
                column: "CustomerBusketId",
                principalTable: "Buskets",
                principalColumn: "Id");
        }
    }
}
