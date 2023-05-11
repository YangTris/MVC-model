using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewUserRegistrationCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e9d961b-07a1-4cef-aa82-42655f1ec43f", "AQAAAAIAAYagAAAAEFgERxqJhfdFukyCRs1P+qe8KDFnGi12K5PpS/ZlJxxksvapcap574CUjMmg+LG36g==", "64fced26-52b8-46cd-8aba-144392dfb3c0" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productID", "brand", "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[] { 3, "Nike", 2, 30, "~/images/male_avt.jpg", 150.0, "ABC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e61d386a-5548-453d-848f-9334c00f66b1", "AQAAAAIAAYagAAAAEG8fgOlyjOo8w/B8VaqjnLDhc5IaM/KTZfL6NLv0ZxRd45F0VKyu/DgEQ76sRnZ0rg==", "c6a13dd9-da6f-4848-8fef-d7a938a3197f" });
        }
    }
}
