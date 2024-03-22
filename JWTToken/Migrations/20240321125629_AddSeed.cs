using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JWTToken.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e9b0148-ff3a-457e-bf81-ca81a02a9e03", "3", "HR", "HR" },
                    { "97ebe06c-ef04-47c8-a6f0-cb97376e5e6b", "1", "Admin", "Admin" },
                    { "c37987a8-f676-4996-b367-320cc8244161", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e9b0148-ff3a-457e-bf81-ca81a02a9e03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ebe06c-ef04-47c8-a6f0-cb97376e5e6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37987a8-f676-4996-b367-320cc8244161");
        }
    }
}
