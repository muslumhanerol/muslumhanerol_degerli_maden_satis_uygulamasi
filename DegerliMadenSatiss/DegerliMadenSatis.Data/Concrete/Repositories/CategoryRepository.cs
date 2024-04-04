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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DegerliMadenSatisDbContext _context) : base(_context)
        {

        }

        private DegerliMadenSatisDbContext DegerliMadenSatisDbContext
        {
            get { return _dbContext as DegerliMadenSatisDbContext; }
        }

        public async Task<List<Category>> GetTopCategories(int n)
        {
            List<Category> categories = await DegerliMadenSatisDbContext //Conttex e idiyor
                .Categories //Kateforilere ulaşıyor
                .Where(c=>c.IsActive && !c.IsDeleted) //Aktif ve silinmemiş olanları getir.
                .Take(n) //Ulaştıklarından 5 tanesini alıyor
                .ToListAsync(); //Onları listeye dönüştürüyor.
            return categories;
        }
    }
}
