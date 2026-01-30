using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.API.Migrations
{
    /// <inheritdoc />
    public partial class AddBusketAndBusketItemsModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MyProperty = table.Column<int>(type: "INTEGER", nullable: false),
                    BusketId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerBusketId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Buskets_CustomerBusketId",
                        column: x => x.CustomerBusketId,
                        principalTable: "Buskets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buskets_CustomerId",
                table: "Buskets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CustomerBusketId",
                table: "Items",
                column: "CustomerBusketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Buskets");
        }
    }
}
