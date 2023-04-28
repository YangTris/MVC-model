using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_by",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "modified_at",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ammount",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "paidDate",
                table: "Payment",
                newName: "expiration");

            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "cardNumber",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nameOnCard",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde9105d-9f43-4bb5-a17e-64c9529cc572", "AQAAAAIAAYagAAAAEOZiTxdbpRlfsR2x6PJ89d3qMcNM/zUqLt5Z4Xl4dMAykXHPFCo9I9VenQZiKluu3Q==", "8fce210d-8f4a-4eb9-b10d-b39ee588b1a1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "cardNumber",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "nameOnCard",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "expiration",
                table: "Payment",
                newName: "paidDate");

            migrationBuilder.AddColumn<string>(
                name: "create_by",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_at",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "ammount",
                table: "Payment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcc6f3a8-c5b0-43f2-8761-734136bae770", "AQAAAAIAAYagAAAAEFpEbL54AXYkj1Xmzrimy05OGjwPAx0cGbhYjgI5ktNyDFBMoGVCMwmaUMiWJsg/3Q==", "ca5282af-4340-43fb-b798-d1f529e206ee" });
        }
    }
}
