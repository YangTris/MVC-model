using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c5292a3-8db7-43c9-99f8-4f3a0d15b1d2", "AQAAAAIAAYagAAAAEEoWfUD1/vAKgsG3A1Xgdm1MArftYm3T2IbfWKrrwHbWjq/TBydHe6K01+xeq6xbTA==", "e6b88a36-3b35-445c-a9fd-932e8acaa089" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8e0786d-d111-4664-9b5a-20296e8458b7", "AQAAAAIAAYagAAAAEI7Fs7b4cnZzjSBLftJrEe1tCM+b7RT9sgRdXX+S7arRc8YEDj9oHUeT7J8IcBskxQ==", "97895c17-0fe1-434e-a66d-7c4053f18f31" });
        }
    }
}
