using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class micart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart_Items");

            migrationBuilder.DropTable(
                name: "ItemShoppingCart");

            migrationBuilder.AddColumn<int>(
                name: "cartID",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73b4d4d8-a9a6-4d31-bb87-0e5db629ecad", "AQAAAAIAAYagAAAAEDIrBtT6AFftKBHpQbjGhaKsR1jn44KHxl1CmKEi4WYPWZLrC4MeL7+qrVz00mOvCA==", "4b6a4ec3-52f1-44c1-b4c6-f298069156cd" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_cartID",
                table: "Item",
                column: "cartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ShoppingCart_cartID",
                table: "Item",
                column: "cartID",
                principalTable: "ShoppingCart",
                principalColumn: "shoppingCartID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ShoppingCart_cartID",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_cartID",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "cartID",
                table: "Item");

            migrationBuilder.CreateTable(
                name: "cart_Items",
                columns: table => new
                {
                    shoppingCartID = table.Column<int>(type: "int", nullable: false),
                    itemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_Items", x => new { x.shoppingCartID, x.itemID });
                    table.ForeignKey(
                        name: "FK_cart_Items_Item_itemID",
                        column: x => x.itemID,
                        principalTable: "Item",
                        principalColumn: "itemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_Items_ShoppingCart_shoppingCartID",
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
                values: new object[] { "68279b30-24b7-4390-a8ed-3d07b0cf525e", "AQAAAAIAAYagAAAAEBaTVS6YPP8TkO3GREufHEDXAdpzmtn7mThB5sq9gCCJu+++I6u88dBt6g7IE+Lbkw==", "6fed4d6c-41a0-4099-bca9-a0b89d500dc7" });

            migrationBuilder.CreateIndex(
                name: "IX_cart_Items_itemID",
                table: "cart_Items",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemShoppingCart_shoppingCartsshoppingCartID",
                table: "ItemShoppingCart",
                column: "shoppingCartsshoppingCartID");
        }
    }
}
