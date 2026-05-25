using Microsoft.EntityFrameworkCore;
using MVClayout.Data;
using MVClayout.Models;

namespace MVClayout.Services
{
    public class CatalogService
    {
        private readonly AppDbContext _dbContext;

        public CatalogService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<ProductCategory>> GetCategoriesAsync()
        {
            return await _dbContext.Categories
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(int? categoryId = null)
        {
            IQueryable<Product> query = _dbContext.Products.AsNoTracking();

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            return await query
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
