using Microsoft.EntityFrameworkCore;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete.Contexts;
using DegerliMadenSatis.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Concrete.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DegerliMadenSatisDbContext _context) : base(_context)
        {

        }
        private DegerliMadenSatisDbContext DegerliMadenSatisDbContext
        {
            get { return _dbContext as DegerliMadenSatisDbContext; }
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            List<Product> products = await DegerliMadenSatisDbContext
                .Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
                .ToListAsync();
            return products;
        }

        public async Task ClearProductCategory(int productId, List<int> categoryIds)
        {
            List<ProductCategory> productCategories = await DegerliMadenSatisDbContext
                .ProductCategories
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
            DegerliMadenSatisDbContext.ProductCategories.RemoveRange(productCategories);
            await DegerliMadenSatisDbContext.SaveChangesAsync();
        }
    }
}
