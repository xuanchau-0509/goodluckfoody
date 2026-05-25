using System.ComponentModel.DataAnnotations;

namespace MVClayout.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your delivery address.")]
        [MaxLength(300)]
        public string Address { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Note { get; set; } = string.Empty;

        public IList<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalAmount => Items.Sum(x => x.LineTotal);
    }
}
