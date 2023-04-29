using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subTotal",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Order");

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
                name: "created_date",
                table: "Order",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "confirmed_by",
                table: "Order",
                newName: "paymentID");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "Product",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "OrderDetail",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "decimal(18,2)",
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
                name: "Email",
                table: "Order",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<int>(
                name: "paymentID1",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a502daf5-9b88-4bf8-90f0-df3984391aa5", "AQAAAAIAAYagAAAAELs3/Z3FzNCMuir/ar83Nh0GFpXINdXu5Zhdn1M6vllnQPWJE2E3+hc4+3tvVhYFpw==", "ca8127ca-4e6a-45c4-af4c-49ec447b4a65" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_paymentID1",
                table: "Order",
                column: "paymentID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_paymentID1",
                table: "Order",
                column: "paymentID1",
                principalTable: "Payment",
                principalColumn: "paymentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_paymentID1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_paymentID1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
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
                name: "Email",
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

            migrationBuilder.DropColumn(
                name: "paymentID1",
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
                newName: "confirmed_by");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Order",
                newName: "created_date");

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

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
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdb39c07-da4f-4c4b-965f-a577232bb075", "AQAAAAIAAYagAAAAEJ13LZJw0BlI5stDrWAiEDiNhLSIDQnS2XAFSFOghHrjbqkAr/ejE3dekUTkGfyYrw==", "7f83fe95-cade-47b1-94b9-e1dcac1d14d6" });
        }
    }
}
