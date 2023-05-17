using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e443133-554b-445d-ad13-4d5b02c202d5", "AQAAAAIAAYagAAAAEB8yms92VwA+vHHcu1hjFtPxbmmyZaRv0turzTxj1Duslkd6/tafJgOMmWs0cGCEHg==", "5b41609b-2073-4636-b602-876b232c15eb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7febd581-4234-4b47-9809-5fcf5f20acce", "AQAAAAIAAYagAAAAENaUOC43/YGCGIAXnYKQdG5M75IdN6wABOPgSsDnYZN1rS9/GznXi70cOB0dXc78pA==", "4196f66d-e134-4c48-9295-87db0f4d7426" });
        }
    }
}
