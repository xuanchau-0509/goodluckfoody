using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVClayout.Data;
using MVClayout.Extensions;
using MVClayout.Models;

namespace MVClayout.Controllers
{
    public class CheckoutController : Controller
    {
        private const string CartSessionKey = "CART_ITEMS";
        private readonly AppDbContext _dbContext;

        public CheckoutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cartItems = GetCartItems();

            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            var viewModel = new CheckoutViewModel
            {
                Items = cartItems
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel viewModel)
        {
            var cartItems = GetCartItems();

            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            viewModel.Items = cartItems;

            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            var order = new Order
            {
                CustomerName = viewModel.CustomerName,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                Email = viewModel.Email,
                Note = viewModel.Note,
                OrderDate = DateTime.Now,
                TotalAmount = cartItems.Sum(x => x.LineTotal),
                OrderDetails = cartItems.Select(item => new OrderDetail
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                }).ToList()
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            HttpContext.Session.Remove(CartSessionKey);

            return RedirectToAction(nameof(Confirmation), new { id = order.Id });
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var order = await _dbContext.Orders
                .Where(o => o.Id == id)
                .Select(o => new Order
                {
                    Id = o.Id,
                    CustomerName = o.CustomerName,
                    Phone = o.Phone,
                    Address = o.Address,
                    Email = o.Email,
                    Note = o.Note,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    OrderDetails = o.OrderDetails.ToList()
                })
                .FirstOrDefaultAsync();

            if (order is null)
            {
                return NotFound();
            }

            return View(order);
        }

        private List<CartItem> GetCartItems()
        {
            return HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? [];
        }
    }
}
