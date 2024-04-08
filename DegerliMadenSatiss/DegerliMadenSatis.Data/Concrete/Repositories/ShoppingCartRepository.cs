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
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(DegerliMadenSatisDbContext _context):base(_context) //DegerliMadenSatisDbContext tipinde _context gelecek, bunu base ye yollayacaksın. 
        {

        }
        private DegerliMadenSatisDbContext DegerliMadenSatisDbContext
        {
            get {return _dbContext as DegerliMadenSatisDbContext}
        }
       
        public Task ClearShoppingCartAsync(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFromShoppingCartAsync(int cartId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
