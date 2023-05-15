using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "method",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                values: new object[] { "ea5ea69f-8244-416d-b545-9b09e0d68334", "AQAAAAIAAYagAAAAEK4V7QSL625Qwq5/HCe8eKAQnCnhE49m04IeMN3aCpkpMF3TXoU+zynmgHHQs09LIA==", "d47917e2-7816-4978-bfc2-cbaa0a24dfb8" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productID", "brand", "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[,]
                {
                    { 1, "Adidas", 0, 20, "~/images/adidas_shoes.jpg", 200.0, "Adidas shoes" },
                    { 2, "Nike", 0, 30, "~/images/nike_carousel.jpg", 100.0, "Nike shoes" },
                    { 3, "Coolmate", 2, 30, "~/images/coolmate_mkt.jpg", 250.0, "Coolmate Box" },
                    { 4, "Nike", 1, 20, "~/images/nike_mkt.jpg", 400.0, "Nike Combo" },
                    { 5, "Other", 2, 30, "~/images/OIP.jpg", 150.0, "No name" },
                    { 6, "Other", 1, 20, "~/images/T-shirt.jpg", 200.0, "1842 T-shirt" },
                    { 7, "Other", 0, 30, "~/images/giay.jpg", 100.0, "Hunter shoes" }
                });

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

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "paymentID",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "method",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                values: new object[] { "afee8836-fc10-4488-aca2-4a66cc9cbe3d", "AQAAAAIAAYagAAAAENbXCnxos32SXAo1ogQMeUKCKbfW5Vg4ETRW/Knx3MlPLbfLcq/dR54coFULlZiCWw==", "490416be-f48d-44ae-9020-8e8b91288e36" });
        }
    }
}
