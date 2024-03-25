using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Concrete
{//Class lardan birden fazla miras alınamaz anca Interface den alına bilir.
    public class ProductRepository:GenericRepository<Product>, IProductRepository //GenericRepository deki altı metot ve IProductRepository ye ait özellikler miras alındı.
    {
        public ProductRepository(AppDbContext _appDbContext):base(_appDbContext) //base aslında GenericRepository.
        {

        }

        AppDbContext AppContext {
            get
            {
                return _dbContext as AppDbContext;
            } 
        }

        public List<Product> GetHomePageProducts()
        {
            var product = AppContext //Linq sorgu tekniği.
                .Products //products = p
                .Where(p=>p.IsHome && p.IsActive && !p.IsDelete) //p=> Her bir p yi tektek eline al demek.
                .ToList();                
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
