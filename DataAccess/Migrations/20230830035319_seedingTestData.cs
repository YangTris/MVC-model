using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedingTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "340ef53c-0f5b-4e0d-be33-3368d5e30ea4", null, null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEF8NpEw83y9FemIJn5GOsWTwPGkdPcW9FrbIVWneUscvqNxiv0xyq8YtN1BQsOJcjQ==", "246321e7-1493-4ac2-895c-266a75ca8c08" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Fristname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c28305c3-93f5-4490-ae59-05d0401bcee4", 0, "test", "1ec8f074-6c7a-4b40-86b7-a75171adb7bf", "ApplicationUser", null, false, "Duong", "Van Tri", false, null, null, "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEHxU/BeWBE1n1eYhlq5lIgjYCxMUkrUyY+PSeflqNL5P4G3cEJ58QJsoyUWoMzVGLw==", "123", null, false, "656304f2-0952-40c6-b6e1-43868ecef8aa", false, "test@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "223a6cd7-14c7-48a2-999a-1adbcdea9a68", "admin@gmail.com", "ADMIN@GMAIL.COM", "SUPER ADMIN", "AQAAAAIAAYagAAAAEB+ghF03+80piasSuPL1/HQzCZiZKlvI0KDuV5IFIY+YmewbByQObHS/CkpK4PXm/A==", "efa8d17e-61a3-4ff9-a807-990551095911" });
        }
    }
}
