using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MueblesDiamante.Migrations
{
    public partial class modifingmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreationDate", "ModificationDate", "Name", "UserCreator", "UserModifier" },
                values: new object[] { 1, new DateTime(2023, 5, 5, 23, 22, 46, 213, DateTimeKind.Local).AddTicks(9475), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activo", "DefaultUser", null });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreationDate", "ModificationDate", "Name", "UserCreator", "UserModifier" },
                values: new object[] { 2, new DateTime(2023, 5, 5, 23, 22, 46, 213, DateTimeKind.Local).AddTicks(9480), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inactivo", "DefaultUser", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationDate", "ModificationDate", "Name", "StatusId", "UserCreator", "UserModifier" },
                values: new object[] { 1, new DateTime(2023, 5, 5, 23, 22, 46, 212, DateTimeKind.Local).AddTicks(9549), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muebles", 1, "DefaultUser", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "CreationDate", "Description", "Image", "ModificationDate", "Name", "Price", "StatusId", "UserCreator", "UserModifier" },
                values: new object[] { 1, 1, "Naranja", new DateTime(2023, 5, 5, 23, 22, 46, 213, DateTimeKind.Local).AddTicks(5802), "Divan elegante de color naranja grande", "NO DISPONIBLE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Divan De Ceda", 4999.99m, 1, "DefaultUser", null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_StatusId",
                table: "Categories",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatusId",
                table: "Products",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.Id);
                });
        }
    }
}
