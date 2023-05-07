using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    cartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.cartID);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8e0786d-d111-4664-9b5a-20296e8458b7", "AQAAAAIAAYagAAAAEI7Fs7b4cnZzjSBLftJrEe1tCM+b7RT9sgRdXX+S7arRc8YEDj9oHUeT7J8IcBskxQ==", "97895c17-0fe1-434e-a66d-7c4053f18f31" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_productId",
                table: "CartItems",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_userId",
                table: "CartItems",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "Product",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "OrderDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e0ee7d0-1af2-4a28-a374-8df1d7021a7b", "AQAAAAIAAYagAAAAEPnu1MxKcBhN+nNoj0hzmr9mZ+posqSKp545iQ4RVlI/MIZK+RtyVfslDBDFCFywAg==", "ca6b973c-97aa-4d9e-b527-1f0c280e116b" });
        }
    }
}
