using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete.Contexts;
using DegerliMadenSatis.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            get { return _dbContext as DegerliMadenSatisDbContext; }
        }
       
        public async Task ClearShoppingCartAsync(int shoppingCartId) //Kullanıı alışverişi tamamladığında yada kendi isteğiyle sepetindeki ürünleri silme işlemi için.
        {   //1.Yöntem
            //var query = @$"DELETE FROM ShoppingCcartItems WHERE ShoppingCartId={shoppingCartId}"; //Güvenlik açığına sebebiyet veriri. ShoppingCartId={shoppingCartId} yazarsak bunun içindeki verilere erişebilirler
            //var query = @"DELETE FROM ShoppingCcartItems WHERE ShoppingCartId=@p0";
            //await DegerliMadenSatisDbContext.Database.ExecuteSqlRawAsync(query, shoppingCartId); //query= hangi sorguyu çalıştırmak istiyorsun. shoppingCartId =Gönderilecek bilgi yani p0. Birden fazla parametre olsaydı virgül konulup yazılırdı.
          
            
            //2.Yöntem
            var deletedShoppingCartItems = await DegerliMadenSatisDbContext //Silinmek istenen cart itemları aldık.
                .ShoppingCartItems
                .Where(x=>x.ShoppingCartId==shoppingCartId)
                .ToListAsync();
            DegerliMadenSatisDbContext.ShoppingCartItems.RemoveRange(deletedShoppingCartItems);
            await DegerliMadenSatisDbContext.SaveChangesAsync();
        }

        public async Task DeleteFromShoppingCartAsync(int shoppingCartId, int productId) //Sepetteki bir tane ürünü silmek istediğimizde.
        {
            //Farklı bir yazım tekniği.
            //var query = @"DELETE FROM ShoppingCcartItems WHERE ShoppingCartId=@p0 AND ProductId=@p1";
            //await DegerliMadenSatisDbContext.Database.ExecuteSqlRawAsync(query, shoppingCartId, productId);

            var deletedShoppingCartItem = await DegerliMadenSatisDbContext
                .ShoppingCartItems
                .Where(x => x.ShoppingCartId == shoppingCartId && x.ProductId == productId)
                .FirstOrDefaultAsync();
            DegerliMadenSatisDbContext.ShoppingCartItems.Remove(deletedShoppingCartItem);
            await DegerliMadenSatisDbContext.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId)
        {
            var shoppingCart = await DegerliMadenSatisDbContext
                .ShoppingCarts
                //.AsNoTracking()
                .Where(sc => sc.UserId == userId)
                .Include(sc => sc.ShoppingCartItems)
                .ThenInclude(sci => sci.Product)
                .FirstOrDefaultAsync();
            return shoppingCart;
                
        }
    }
}
