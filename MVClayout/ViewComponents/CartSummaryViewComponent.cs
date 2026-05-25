using Microsoft.AspNetCore.Mvc;
using MVClayout.Extensions;
using MVClayout.Models;

namespace MVClayout.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private const string CartSessionKey = "CART_ITEMS";

        public IViewComponentResult Invoke()
        {
            var items = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? [];
            var totalQuantity = items.Sum(x => x.Quantity);
            return View(totalQuantity);
        }
    }
}
