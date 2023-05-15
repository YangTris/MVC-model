using System;
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
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b91d49d2-cd4b-4634-b146-899578b7d1c9", "AQAAAAIAAYagAAAAEBdO1uV1qZmWOUmG2ys8DhMsg5y9dXRowdljFWEWv7cubNYL8NGWHpnW1OdE5BkxTw==", "5f7e8065-009e-4aea-b1f2-8b3e1d0a4286" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 1,
                columns: new[] { "category", "imgURL", "productName" },
                values: new object[] { 0, "~/images/adidas_shoes.jpg", "Adidas shoes" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 2,
                column: "productName",
                value: "Nike shoes");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 3,
                columns: new[] { "brand", "imgURL", "price", "productName" },
                values: new object[] { "Coolmate", "~/images/coolmate_mkt.jpg", 250.0, "Coolmate Box" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productID", "brand", "category", "discountPercentage", "imgURL", "price", "productName" },
                values: new object[,]
                {
                    { 4, "Nike", 1, 20, "~/images/nike_mkt.jpg", 400.0, "Nike Combo" },
                    { 5, "Other", 1, 30, "~/images/Uniqlo.jpg", 100.0, "Uniqlo" },
                    { 6, "Other", 2, 30, "~/images/OIP.jpg", 150.0, "No name" },
                    { 7, "Other", 1, 20, "~/images/T-shirt.jpg", 200.0, "1842 T-shirt" },
                    { 8, "Other", 0, 30, "~/images/giay.jpg", 100.0, "Hunter shoes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 8);

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Fristname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c873c34-0dd4-4c15-80e4-7a557187be47", "AQAAAAIAAYagAAAAEEUK65E4R6Xju7/oQuBIcd2ctqZsXDJxI34CwQG54wRM3BnBoqUMiSPFedPo0ZFH5w==", "227a3758-0a08-4b83-89fd-afc3d4b67150" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 1,
                columns: new[] { "category", "imgURL", "productName" },
                values: new object[] { 1, "~/images/Dotabg.jpg", "Test" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 2,
                column: "productName",
                value: "Test2");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 3,
                columns: new[] { "brand", "imgURL", "price", "productName" },
                values: new object[] { "Nike", "~/images/male_avt.jpg", 150.0, "ABC" });
        }
    }
}
