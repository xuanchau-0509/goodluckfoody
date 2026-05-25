using Microsoft.AspNetCore.Mvc;
using MVClayout.Services;

namespace MVClayout.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly CatalogService _catalogService;

        public MenuLoaiViewComponent(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? currentCategoryId)
        {
            ViewBag.CurrentCategoryId = currentCategoryId;

            return View(await _catalogService.GetCategoriesAsync());
        }
    }
}
