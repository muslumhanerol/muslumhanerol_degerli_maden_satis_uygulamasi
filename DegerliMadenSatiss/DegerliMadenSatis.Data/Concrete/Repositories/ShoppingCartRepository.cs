using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete.Contexts;
using DegerliMadenSatis.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
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
            get { return _dbContext as DegerliMadenSatisDbContext; }
        }
       
        public async Task ClearShoppingCartAsync(int shoppingCartId)
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
