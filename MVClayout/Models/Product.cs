namespace MVClayout.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        public string Badge { get; set; } = "New";

        public ProductCategory? Category { get; set; }
    }
}
