using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatecart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Item_Item_itemID",
                table: "Cart_Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Item_ShoppingCart_shoppingCartID",
                table: "Cart_Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart_Item",
                table: "Cart_Item");

            migrationBuilder.RenameTable(
                name: "Cart_Item",
                newName: "cart_Items");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Item_itemID",
                table: "cart_Items",
                newName: "IX_cart_Items_itemID");

            migrationBuilder.AddColumn<string>(
                name: "userID",
                table: "ShoppingCart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cart_Items",
                table: "cart_Items",
                columns: new[] { "shoppingCartID", "itemID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68279b30-24b7-4390-a8ed-3d07b0cf525e", "AQAAAAIAAYagAAAAEBaTVS6YPP8TkO3GREufHEDXAdpzmtn7mThB5sq9gCCJu+++I6u88dBt6g7IE+Lbkw==", "6fed4d6c-41a0-4099-bca9-a0b89d500dc7" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_userID",
                table: "ShoppingCart",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_Items_Item_itemID",
                table: "cart_Items",
                column: "itemID",
                principalTable: "Item",
                principalColumn: "itemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_Items_ShoppingCart_shoppingCartID",
                table: "cart_Items",
                column: "shoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "shoppingCartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_userID",
                table: "ShoppingCart",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_Items_Item_itemID",
                table: "cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_Items_ShoppingCart_shoppingCartID",
                table: "cart_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_userID",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_userID",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cart_Items",
                table: "cart_Items");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "cart_Items",
                newName: "Cart_Item");

            migrationBuilder.RenameIndex(
                name: "IX_cart_Items_itemID",
                table: "Cart_Item",
                newName: "IX_Cart_Item_itemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart_Item",
                table: "Cart_Item",
                columns: new[] { "shoppingCartID", "itemID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12b7633d-ab74-403a-bf37-08a19b1a9554", "AQAAAAIAAYagAAAAEN12IusODVNHILETgC+0MBeJq+010vtVN4By9tCmzrloHIDGQvrX6Wb5om3QBbCmeg==", "b9ac83d0-54c2-426b-85c2-52e207ba49da" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Item_Item_itemID",
                table: "Cart_Item",
                column: "itemID",
                principalTable: "Item",
                principalColumn: "itemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Item_ShoppingCart_shoppingCartID",
                table: "Cart_Item",
                column: "shoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "shoppingCartID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
