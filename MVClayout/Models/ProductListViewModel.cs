namespace MVClayout.Models
{
    public class ProductListViewModel
    {
        public IReadOnlyList<ProductCategory> Categories { get; set; } = [];

        public IReadOnlyList<Product> Products { get; set; } = [];

        public int? CurrentCategoryId { get; set; }

        public string CurrentCategoryName =>
            CurrentCategoryId is null
                ? "All Products"
                : Categories.FirstOrDefault(category => category.Id == CurrentCategoryId)?.Name ?? "Products";
    }
}
