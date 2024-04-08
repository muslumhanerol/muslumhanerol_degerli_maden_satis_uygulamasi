using DegerliMadenSatis.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Abstract
{
    internal interface IShoppingCartRepository:IGenericRepository<ShoppingCart>
    {
        Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId);
        Task DeleteFromShoppingCartAsync(int cartId, int productId); //Hangi carttan silecek, o carttan hangi productı silecek.
        Task ClearShoppingCartAsync(int shoppingCartId); 
    }
}
