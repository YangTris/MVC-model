using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "223a6cd7-14c7-48a2-999a-1adbcdea9a68", "AQAAAAIAAYagAAAAEB+ghF03+80piasSuPL1/HQzCZiZKlvI0KDuV5IFIY+YmewbByQObHS/CkpK4PXm/A==", "efa8d17e-61a3-4ff9-a807-990551095911", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productID", "brand", "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[,]
                {
                    { 8, "Other", 0, 30, "~/images/giay.jpg", 100.0, "giay Hunter" },
                    { 9, "Other", 0, 30, "~/images/giay.jpg", 100.0, "Hunter shoesssss" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8d8a7406-ff34-4ca5-80bc-8183127f8333", "AQAAAAIAAYagAAAAEP/pJPEBB54un9u1yVdagr8Z9gbLEKJf/YVHqAJvylxbN2F98TUgdcPvFst191276A==", "a56db444-9ab3-4172-95fb-c41fb580d096", "Super Admin" });
        }
    }
}
