using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class bruh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "paymentID",
                table: "Payment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "paymentID",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "paymentID",
                table: "Item",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7249d5f4-c206-42c1-bc61-7be77b0aef21", "AQAAAAIAAYagAAAAEL44HWoDU/S7AYXcuwkIGd2NDY2OgjEBX+qnhkdSU5C9dhbsFsQnA27GvmWARUWO1g==", "9f413a7d-e39f-4e03-a288-47ae2f24b614" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 5,
                columns: new[] { "category", "imgURL", "price", "productName" },
                values: new object[] { 2, "~/images/OIP.jpg", 150.0, "No name" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 6,
                columns: new[] { "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[] { 1, 20, "~/images/T-shirt.jpg", 200.0, "1842 T-shirt" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 7,
                columns: new[] { "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[] { 0, 30, "~/images/giay.jpg", 100.0, "Hunter shoes" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_paymentID",
                table: "Item",
                column: "paymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Payment_paymentID",
                table: "Item",
                column: "paymentID",
                principalTable: "Payment",
                principalColumn: "paymentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Payment_paymentID",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_paymentID",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "paymentID",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "paymentID",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "paymentID",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b91d49d2-cd4b-4634-b146-899578b7d1c9", "AQAAAAIAAYagAAAAEBdO1uV1qZmWOUmG2ys8DhMsg5y9dXRowdljFWEWv7cubNYL8NGWHpnW1OdE5BkxTw==", "5f7e8065-009e-4aea-b1f2-8b3e1d0a4286" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 5,
                columns: new[] { "category", "imgURL", "price", "productName" },
                values: new object[] { 1, "~/images/Uniqlo.jpg", 100.0, "Uniqlo" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 6,
                columns: new[] { "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[] { 2, 30, "~/images/OIP.jpg", 150.0, "No name" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 7,
                columns: new[] { "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[] { 1, 20, "~/images/T-shirt.jpg", 200.0, "1842 T-shirt" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productID", "brand", "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[] { 8, "Other", 0, 30, "~/images/giay.jpg", 100.0, "Hunter shoes" });
        }
    }
}
