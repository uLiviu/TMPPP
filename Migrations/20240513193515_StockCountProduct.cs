using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class StockCountProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d1b0501-248c-4c2f-8fd6-bef588dc66e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a974117-bcd9-4a97-83d5-b2f6473be6ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dd0ee41-f1cb-485a-af3a-c00ef6a2c6ba");

            migrationBuilder.AddColumn<int>(
                name: "StockCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "181c5202-6e0d-4daf-996e-90577098fd65", null, "user", "user" },
                    { "92fa5443-bd57-46ac-95e2-a87bf94d0756", null, "buyer", "buyer" },
                    { "b47ce6d5-0d2d-4094-bc3b-ae887b4c448a", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "181c5202-6e0d-4daf-996e-90577098fd65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92fa5443-bd57-46ac-95e2-a87bf94d0756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b47ce6d5-0d2d-4094-bc3b-ae887b4c448a");

            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d1b0501-248c-4c2f-8fd6-bef588dc66e6", null, "user", "user" },
                    { "6a974117-bcd9-4a97-83d5-b2f6473be6ec", null, "admin", "admin" },
                    { "9dd0ee41-f1cb-485a-af3a-c00ef6a2c6ba", null, "buyer", "buyer" }
                });
        }
    }
}
