using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DockService.Infrastructure.Migrations
{
    public partial class AddMissingContainersToShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SerialShippingContainerCode = table.Column<string>(nullable: true),
                    ShipDBKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Container_Ships_ShipDBKey",
                        column: x => x.ShipDBKey,
                        principalTable: "Ships",
                        principalColumn: "DBKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContainerId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProductType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Container_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Container",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Container_ShipDBKey",
                table: "Container",
                column: "ShipDBKey");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ContainerId",
                table: "Product",
                column: "ContainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Container");
        }
    }
}
