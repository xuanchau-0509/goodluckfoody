using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVClayout.Models;
using MVClayout.Services;

namespace MVClayout.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CatalogService _catalogService;

        public HomeController(ILogger<HomeController> logger, CatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Index()
        {
            var featuredProducts = (await _catalogService.GetProductsAsync()).Take(4).ToList();
            var viewModel = new HomeIndexViewModel
            {
                FeaturedProducts = featuredProducts
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
