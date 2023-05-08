using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dbcart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12b7633d-ab74-403a-bf37-08a19b1a9554", "AQAAAAIAAYagAAAAEN12IusODVNHILETgC+0MBeJq+010vtVN4By9tCmzrloHIDGQvrX6Wb5om3QBbCmeg==", "b9ac83d0-54c2-426b-85c2-52e207ba49da" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c28305c3-93f5-4490-ae59-05d0401bcee3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdcede71-8e59-42ef-8a02-112eed6be92d", "AQAAAAIAAYagAAAAEIi2if4rsgr9pZJXO+FlmHin9BON78gTjb9p8QPszWIXp8beekuZns7SvRnN86+8Zw==", "03d372b2-856e-446a-ac85-c5cd6f4f2461" });
        }
    }
}
