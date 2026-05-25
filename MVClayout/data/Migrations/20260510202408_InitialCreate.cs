using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVClayout.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Badge = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Fresh vegetables for daily meals.", "Vegetables" },
                    { 2, "Seasonal fruits selected from trusted farms.", "Fruits" },
                    { 3, "Healthy organic products ready for your kitchen.", "Fresh Food" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Badge", "CategoryId", "Description", "ImageUrl", "Name", "OldPrice", "Price" },
                values: new object[,]
                {
                    { 1, "New", 1, "Ripe tomatoes with bright flavor, perfect for salads and sauces.", "~/img/product-1.jpg", "Fresh Tomato", 59000m, 39000m },
                    { 2, "New", 1, "Crisp cabbage grown with clean farming methods.", "~/img/product-2.jpg", "Green Cabbage", 45000m, 29000m },
                    { 3, "New", 1, "Sweet carrots with natural color and crunch.", "~/img/product-3.jpg", "Organic Carrot", 50000m, 35000m },
                    { 4, "New", 2, "Juicy oranges rich in vitamin C.", "~/img/product-4.jpg", "Sweet Orange", 89000m, 69000m },
                    { 5, "New", 2, "Crisp apples selected for freshness and taste.", "~/img/product-5.jpg", "Fresh Apple", 99000m, 79000m },
                    { 6, "New", 2, "Naturally sweet bananas for snacks and smoothies.", "~/img/product-6.jpg", "Garden Banana", 56000m, 42000m },
                    { 7, "New", 3, "Fresh broccoli packed for healthy family meals.", "~/img/product-7.jpg", "Healthy Broccoli", 73000m, 55000m },
                    { 8, "New", 3, "A balanced mix of organic vegetables and fruits.", "~/img/product-8.jpg", "Mixed Organic Box", 189000m, 149000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
