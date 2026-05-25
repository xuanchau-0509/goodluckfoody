using Microsoft.AspNetCore.Mvc;
using MVClayout.Extensions;
using MVClayout.Models;
using MVClayout.Services;

namespace MVClayout.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "CART_ITEMS";
        private readonly CatalogService _catalogService;

        public CartController(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IActionResult Index()
        {
            var cartItems = GetCartItems();
            var viewModel = new CartViewModel
            {
                Items = cartItems
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int productId, int quantity = 1, string? returnUrl = null)
        {
            if (quantity < 1)
            {
                quantity = 1;
            }

            var product = await _catalogService.GetProductAsync(productId);
            if (product is null)
            {
                return NotFound();
            }

            var cartItems = GetCartItems();
            var existingItem = cartItems.FirstOrDefault(x => x.ProductId == productId);

            if (existingItem is null)
            {
                cartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ImageUrl = product.ImageUrl,
                    UnitPrice = product.Price,
                    Quantity = quantity
                });
            }
            else
            {
                existingItem.Quantity += quantity;
            }

            SaveCartItems(cartItems);

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var cartItems = GetCartItems();
            var item = cartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item is null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (quantity <= 0)
            {
                cartItems.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }

            SaveCartItems(cartItems);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int productId)
        {
            var cartItems = GetCartItems();
            var item = cartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item is not null)
            {
                cartItems.Remove(item);
                SaveCartItems(cartItems);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            HttpContext.Session.Remove(CartSessionKey);
            return RedirectToAction(nameof(Index));
        }

        private List<CartItem> GetCartItems()
        {
            return HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? [];
        }

        private void SaveCartItems(List<CartItem> items)
        {
            HttpContext.Session.SetObject(CartSessionKey, items);
        }
    }
}
