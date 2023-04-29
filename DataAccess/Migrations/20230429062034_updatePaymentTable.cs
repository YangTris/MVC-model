using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatePaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "Payment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdb39c07-da4f-4c4b-965f-a577232bb075", "AQAAAAIAAYagAAAAEJ13LZJw0BlI5stDrWAiEDiNhLSIDQnS2XAFSFOghHrjbqkAr/ejE3dekUTkGfyYrw==", "7f83fe95-cade-47b1-94b9-e1dcac1d14d6" });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_userID",
                table: "Payment",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_AspNetUsers_userID",
                table: "Payment",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_AspNetUsers_userID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_userID",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde9105d-9f43-4bb5-a17e-64c9529cc572", "AQAAAAIAAYagAAAAEOZiTxdbpRlfsR2x6PJ89d3qMcNM/zUqLt5Z4Xl4dMAykXHPFCo9I9VenQZiKluu3Q==", "8fce210d-8f4a-4eb9-b10d-b39ee588b1a1" });
        }
    }
}
