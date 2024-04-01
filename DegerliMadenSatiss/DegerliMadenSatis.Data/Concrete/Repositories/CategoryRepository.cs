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
    }
}
