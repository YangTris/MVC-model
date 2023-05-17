using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedingUser : Migration
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
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Fristname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c28305c3-93f5-4490-ae59-05d0401bcee3", 0, "SGU", "ca9b97cd-d129-467b-abf9-74391cbe3975", "ApplicationUser", "admin@gmail.com", false, "Duong", "Van Tri", false, null, "ADMIN@GMAIL.COM", "SUPER ADMIN", "AQAAAAIAAYagAAAAELlJmlSvafcr8YO92gc/Og6WGPA2LfsuDDrZfh6ERkdniPSfCxCOd4A30ynn/DoQGQ==", "123", null, false, "ca404668-2733-4560-9d33-cfdacff5b8ed", false, "Super Admin" });

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
