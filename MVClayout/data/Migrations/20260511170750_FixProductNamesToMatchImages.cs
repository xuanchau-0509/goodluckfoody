using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVClayout.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixProductNamesToMatchImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 2, "Sweet and juicy pineapple, great for dessert and juice.", "Fresh Pineapple", 65000m, 49000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Fresh organic chili for spicy and flavorful cooking.", "Organic Chili" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Fresh strawberries with natural sweetness and aroma.", "Sweet Strawberry" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 1, "Crunchy cucumber for salads and healthy snacks.", "Fresh Cucumber", 45000m, 32000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 1, "Bright red vine tomato for daily family meals.", "Vine Tomato", 52000m, 37000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 1, "Soft and creamy baby potatoes for roasting and soup.", "Baby Potato", 62000m, 46000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 2, "Naturally sweet bananas for snacks and smoothies.", "Garden Banana", 56000m, 42000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 1, "Crisp cabbage grown with clean farming methods.", "Green Cabbage", 45000m, 29000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Sweet carrots with natural color and crunch.", "Organic Carrot" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Juicy oranges rich in vitamin C.", "Sweet Orange" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 2, "Crisp apples selected for freshness and taste.", "Fresh Apple", 99000m, 79000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 2, "Naturally sweet bananas for snacks and smoothies.", "Garden Banana", 56000m, 42000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 3, "Fresh broccoli packed for healthy family meals.", "Healthy Broccoli", 73000m, 55000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description", "Name", "OldPrice", "Price" },
                values: new object[] { 3, "A balanced mix of organic vegetables and fruits.", "Mixed Organic Box", 189000m, 149000m });
        }
    }
}
