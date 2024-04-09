using DegerliMadenSatis.Shared.ResponseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Business.Abstract
{
    public interface IShoppingCartService
    {
        Task<Response<NoContent>> InitializeShoppingCartAsync(string userId);
        Task<Response<ShoppingCartViewModel>> GetShoppingCartUserIdAsync(string userId);
        Task<Response<NoContent>> AddToCartAsync(string userId, string shoppingCartId);
        Task<Response<NoContent>> DeleteFromCartAsync(int shoppingCartId, int productId);
        Task<Response<NoContent>> ClearShoppingCartAsync (int shoppingCartId);

    }
}
