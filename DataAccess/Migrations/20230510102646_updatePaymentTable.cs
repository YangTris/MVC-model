using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatePaymentTable : Migration
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e61d386a-5548-453d-848f-9334c00f66b1", "AQAAAAIAAYagAAAAEG8fgOlyjOo8w/B8VaqjnLDhc5IaM/KTZfL6NLv0ZxRd45F0VKyu/DgEQ76sRnZ0rg==", "c6a13dd9-da6f-4848-8fef-d7a938a3197f" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productID", "brand", "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[,]
                {
                    { 1, "Adidas", 1, 20, "~/images/Dotabg.jpg", 200.0, "Test" },
                    { 2, "Nike", 0, 30, "~/images/nike_carousel.jpg", 100.0, "Test2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "method",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afee8836-fc10-4488-aca2-4a66cc9cbe3d", "AQAAAAIAAYagAAAAENbXCnxos32SXAo1ogQMeUKCKbfW5Vg4ETRW/Knx3MlPLbfLcq/dR54coFULlZiCWw==", "490416be-f48d-44ae-9020-8e8b91288e36" });
        }
    }
}
