using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class Other : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad92efb-7b72-4d75-bd32-a3eda6a95d28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37daa3bf-2d3f-4217-bb93-bce8dec80fe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfaf9564-7efb-4c05-8123-6ef2781eb156");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ad92efb-7b72-4d75-bd32-a3eda6a95d28", null, "user", "user" },
                    { "37daa3bf-2d3f-4217-bb93-bce8dec80fe4", null, "admin", "admin" },
                    { "cfaf9564-7efb-4c05-8123-6ef2781eb156", null, "buyer", "buyer" }
                });
        }
    }
}
