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
                name: "subTotal",
                table: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderDetail",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Order",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "Order",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Order",
                newName: "paymentID");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Order",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "confirmed_by",
                table: "Order",
                newName: "Email");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "Product",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Order",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Order",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Order",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Order",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Order",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Order",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Order",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Order",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    itemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.itemID);
                    table.ForeignKey(
                        name: "FK_Item_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.shoppingCartID);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afee8836-fc10-4488-aca2-4a66cc9cbe3d", "AQAAAAIAAYagAAAAENbXCnxos32SXAo1ogQMeUKCKbfW5Vg4ETRW/Knx3MlPLbfLcq/dR54coFULlZiCWw==", "490416be-f48d-44ae-9020-8e8b91288e36" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_paymentID",
                table: "Order",
                column: "paymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_productID",
                table: "Item",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_userID",
                table: "Item",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_userID",
                table: "ShoppingCart",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_paymentID",
                table: "Order",
                column: "paymentID",
                principalTable: "Payment",
                principalColumn: "paymentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_paymentID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Order_paymentID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetail",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Order",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Order",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "paymentID",
                table: "Order",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Order",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Order",
                newName: "confirmed_by");

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "subTotal",
                table: "OrderDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "total",
                table: "Order",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdb39c07-da4f-4c4b-965f-a577232bb075", "AQAAAAIAAYagAAAAEJ13LZJw0BlI5stDrWAiEDiNhLSIDQnS2XAFSFOghHrjbqkAr/ejE3dekUTkGfyYrw==", "7f83fe95-cade-47b1-94b9-e1dcac1d14d6" });
        }
    }
}
