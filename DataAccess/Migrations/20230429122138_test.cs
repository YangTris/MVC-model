using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_paymentID1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_paymentID1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "paymentID1",
                table: "Order");

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "OrderDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "paymentID",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e0ee7d0-1af2-4a28-a374-8df1d7021a7b", "AQAAAAIAAYagAAAAEPnu1MxKcBhN+nNoj0hzmr9mZ+posqSKp545iQ4RVlI/MIZK+RtyVfslDBDFCFywAg==", "ca6b973c-97aa-4d9e-b527-1f0c280e116b" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_paymentID",
                table: "Order",
                column: "paymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_paymentID",
                table: "Order",
                column: "paymentID",
                principalTable: "Payment",
                principalColumn: "paymentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_paymentID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_paymentID",
                table: "Order");

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "OrderDetail",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "paymentID",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

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
    }
}
