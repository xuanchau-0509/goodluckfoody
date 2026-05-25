namespace MVClayout.Models
{
    public class CartViewModel
    {
        public IList<CartItem> Items { get; set; } = new List<CartItem>();

        public int TotalItems => Items.Sum(x => x.Quantity);

        public decimal TotalAmount => Items.Sum(x => x.LineTotal);
    }
}
