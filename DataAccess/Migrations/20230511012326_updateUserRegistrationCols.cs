using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateUserRegistrationCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba1ab1fb-b357-4ce7-9161-24353da53b70", "AQAAAAIAAYagAAAAEKATk+QUUm++qOiP1LCh+2AMpNG50ZPkzv6HVxhjYWLnkj9qqqSYOcUMqseaSBRGLQ==", "64ca8279-f517-4ff3-a997-c790917c63c9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e9d961b-07a1-4cef-aa82-42655f1ec43f", "AQAAAAIAAYagAAAAEFgERxqJhfdFukyCRs1P+qe8KDFnGi12K5PpS/ZlJxxksvapcap574CUjMmg+LG36g==", "64fced26-52b8-46cd-8aba-144392dfb3c0" });
        }
    }
}
