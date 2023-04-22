using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropColumn(
                name: "id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "accountId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "productID",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "order",
                newName: "orderID");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "order",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "order",
                newName: "orderAddress");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "account",
                newName: "orderID");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "account",
                newName: "customerID");

            migrationBuilder.AddColumn<int>(
                name: "productID",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ordered",
                table: "order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "shipped",
                table: "order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "totalPrice",
                table: "order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "account",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "billingAddress",
                table: "account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "closed",
                table: "account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isClosed",
                table: "account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "open",
                table: "account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "productID");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orderLine",
                columns: table => new
                {
                    orderLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderLine", x => x.orderLineID);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    paymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    method = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.paymentID);
                });

            migrationBuilder.CreateTable(
                name: "webUser",
                columns: table => new
                {
                    loginID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_webUser", x => x.loginID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "orderLine");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "webUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropColumn(
                name: "productID",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ordered",
                table: "order");

            migrationBuilder.DropColumn(
                name: "shipped",
                table: "order");

            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "order");

            migrationBuilder.DropColumn(
                name: "billingAddress",
                table: "account");

            migrationBuilder.DropColumn(
                name: "closed",
                table: "account");

            migrationBuilder.DropColumn(
                name: "isClosed",
                table: "account");

            migrationBuilder.DropColumn(
                name: "open",
                table: "account");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "order",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "order",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "orderAddress",
                table: "order",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "account",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "customerID",
                table: "account",
                newName: "password");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "orderId",
                table: "order",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "accountId",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "productID",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "account",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");
        }
    }
}
