using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5699a98e-c6cd-4b27-8670-812a9a4ff55e", null, "admin", "admin" },
                    { "a06e92b7-4de3-4715-aaea-e6055927246f", null, "user", "user" },
                    { "e7dabab7-e976-4e0c-a3f6-02783d39824b", null, "buyer", "buyer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5699a98e-c6cd-4b27-8670-812a9a4ff55e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06e92b7-4de3-4715-aaea-e6055927246f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7dabab7-e976-4e0c-a3f6-02783d39824b");
        }
    }
}
