using Microsoft.AspNetCore.Mvc;
using MVClayout.Models;
using MVClayout.Services;

namespace MVClayout.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly CatalogService _catalogService;

        public HangHoaController(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Index(int? loai)
        {
            var viewModel = new ProductListViewModel
            {
                Categories = await _catalogService.GetCategoriesAsync(),
                Products = await _catalogService.GetProductsAsync(loai),
                CurrentCategoryId = loai
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _catalogService.GetProductAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
