using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fix_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderLine",
                table: "orderLine");

            migrationBuilder.DropColumn(
                name: "detail",
                table: "payment");

            migrationBuilder.DropColumn(
                name: "orderLineID",
                table: "orderLine");

            migrationBuilder.DropColumn(
                name: "ordered",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "product",
                newName: "discountPercentage");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "product",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "inDate",
                table: "product",
                newName: "modified_at");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "product",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "payment",
                newName: "ammount");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "orderLine",
                newName: "subTotal");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "order",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "shipped",
                table: "order",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "orderAddress",
                table: "order",
                newName: "userName");

            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "orderLine",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "confirmed_by",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderLine",
                table: "orderLine",
                column: "orderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderLine",
                table: "orderLine");

            migrationBuilder.DropColumn(
                name: "category",
                table: "product");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "product");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "product");

            migrationBuilder.DropColumn(
                name: "description",
                table: "payment");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "payment");

            migrationBuilder.DropColumn(
                name: "confirmed_by",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "product",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "modified_at",
                table: "product",
                newName: "inDate");

            migrationBuilder.RenameColumn(
                name: "discountPercentage",
                table: "product",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "product",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ammount",
                table: "payment",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "subTotal",
                table: "orderLine",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "order",
                newName: "orderAddress");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "order",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "order",
                newName: "shipped");

            migrationBuilder.AddColumn<string>(
                name: "detail",
                table: "payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "orderLine",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "orderLineID",
                table: "orderLine",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ordered",
                table: "order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderLine",
                table: "orderLine",
                column: "orderLineID");
        }
    }
}
