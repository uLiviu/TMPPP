using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3edddefe-804a-4ed5-8fbe-b90b754377ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6641fe47-b0c9-488e-aa5c-a93b9f4b844b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82390f77-e17b-4f4c-afad-e13e53d53b51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0729ebbc-8fbe-4272-bf76-46394e62bc98", null, "buyer", "buyer" },
                    { "91d4d85b-faa5-4182-a425-c290869f4535", null, "admin", "admin" },
                    { "d3101fec-5d06-4cca-9119-bd6164259280", null, "user", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0729ebbc-8fbe-4272-bf76-46394e62bc98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91d4d85b-faa5-4182-a425-c290869f4535");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3101fec-5d06-4cca-9119-bd6164259280");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3edddefe-804a-4ed5-8fbe-b90b754377ec", null, "admin", "admin" },
                    { "6641fe47-b0c9-488e-aa5c-a93b9f4b844b", null, "user", "user" },
                    { "82390f77-e17b-4f4c-afad-e13e53d53b51", null, "buyer", "buyer" }
                });
        }
    }
}
