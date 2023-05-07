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
                name: "Item",
                columns: table => new
                {
                    itemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.itemID);
                    table.ForeignKey(
                        name: "FK_Item_Product_productID",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    shoppingCartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.shoppingCartID);
                });

            migrationBuilder.CreateTable(
                name: "Cart_Item",
                columns: table => new
                {
                    shoppingCartID = table.Column<int>(type: "int", nullable: false),
                    itemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Item", x => new { x.shoppingCartID, x.itemID });
                    table.ForeignKey(
                        name: "FK_Cart_Item_Item_itemID",
                        column: x => x.itemID,
                        principalTable: "Item",
                        principalColumn: "itemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Item_ShoppingCart_shoppingCartID",
                        column: x => x.shoppingCartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "shoppingCartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemShoppingCart",
                columns: table => new
                {
                    ItemsitemID = table.Column<int>(type: "int", nullable: false),
                    shoppingCartsshoppingCartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemShoppingCart", x => new { x.ItemsitemID, x.shoppingCartsshoppingCartID });
                    table.ForeignKey(
                        name: "FK_ItemShoppingCart_Item_ItemsitemID",
                        column: x => x.ItemsitemID,
                        principalTable: "Item",
                        principalColumn: "itemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemShoppingCart_ShoppingCart_shoppingCartsshoppingCartID",
                        column: x => x.shoppingCartsshoppingCartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "shoppingCartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdcede71-8e59-42ef-8a02-112eed6be92d", "AQAAAAIAAYagAAAAEIi2if4rsgr9pZJXO+FlmHin9BON78gTjb9p8QPszWIXp8beekuZns7SvRnN86+8Zw==", "03d372b2-856e-446a-ac85-c5cd6f4f2461" });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Item_itemID",
                table: "Cart_Item",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_productID",
                table: "Item",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemShoppingCart_shoppingCartsshoppingCartID",
                table: "ItemShoppingCart",
                column: "shoppingCartsshoppingCartID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_Item");

            migrationBuilder.DropTable(
                name: "ItemShoppingCart");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

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
