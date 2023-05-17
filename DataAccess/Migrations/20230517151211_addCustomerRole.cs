using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCustomerRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6bc135f7-455c-4b04-b301-f32642221dea", null, "Customer", "CUSTOMER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d8a7406-ff34-4ca5-80bc-8183127f8333", "AQAAAAIAAYagAAAAEP/pJPEBB54un9u1yVdagr8Z9gbLEKJf/YVHqAJvylxbN2F98TUgdcPvFst191276A==", "a56db444-9ab3-4172-95fb-c41fb580d096" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bc135f7-455c-4b04-b301-f32642221dea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44b930f9-2564-4248-baea-eb1e282060f0", "AQAAAAIAAYagAAAAEMZCMVDilSZci+A9f6IzRbZuHw4WOMH3eay9jYOzB78//68MgwtFZS8RKeCSoSyusQ==", "559124b1-8cd6-43cc-adf0-3e923c0b2279" });
        }
    }
}
