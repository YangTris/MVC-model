using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateIdentityDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be3e451c-0914-443c-897e-cba2eb45b564", null, "Manager", "MANAGER" },
                    { "fff5caad-d740-48f7-abdc-03ae0635c08b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c28305c3-93f5-4490-ae59-05d0401bcee3", 0, "fcc6f3a8-c5b0-43f2-8761-734136bae770", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "SUPER ADMIN", "AQAAAAIAAYagAAAAEFpEbL54AXYkj1Xmzrimy05OGjwPAx0cGbhYjgI5ktNyDFBMoGVCMwmaUMiWJsg/3Q==", null, false, "ca5282af-4340-43fb-b798-d1f529e206ee", false, "Super Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "be3e451c-0914-443c-897e-cba2eb45b564", "c28305c3-93f5-4490-ae59-05d0401bcee3" },
                    { "fff5caad-d740-48f7-abdc-03ae0635c08b", "c28305c3-93f5-4490-ae59-05d0401bcee3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be3e451c-0914-443c-897e-cba2eb45b564", "c28305c3-93f5-4490-ae59-05d0401bcee3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fff5caad-d740-48f7-abdc-03ae0635c08b", "c28305c3-93f5-4490-ae59-05d0401bcee3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be3e451c-0914-443c-897e-cba2eb45b564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fff5caad-d740-48f7-abdc-03ae0635c08b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3");
        }
    }
}
