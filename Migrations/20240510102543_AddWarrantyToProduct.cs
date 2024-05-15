using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class AddWarrantyToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3470c22-9b94-45c7-824b-84b381038e1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef97d0e-2049-4a9c-a0cf-f0627c2302c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efca55f3-a57a-423a-b783-f46bf1365f82");

            migrationBuilder.AddColumn<int>(
                name: "Warranty",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e63bbe9-31c8-48c6-a5d6-5e97c92760d2", null, "buyer", "buyer" },
                    { "c95336fc-3552-46ad-b56a-7b76dd607b86", null, "user", "user" },
                    { "eb3f4e97-40e3-45d7-81b4-68c055ff2791", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e63bbe9-31c8-48c6-a5d6-5e97c92760d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c95336fc-3552-46ad-b56a-7b76dd607b86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb3f4e97-40e3-45d7-81b4-68c055ff2791");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3470c22-9b94-45c7-824b-84b381038e1c", null, "user", "user" },
                    { "aef97d0e-2049-4a9c-a0cf-f0627c2302c8", null, "admin", "admin" },
                    { "efca55f3-a57a-423a-b783-f46bf1365f82", null, "buyer", "buyer" }
                });
        }
    }
}
