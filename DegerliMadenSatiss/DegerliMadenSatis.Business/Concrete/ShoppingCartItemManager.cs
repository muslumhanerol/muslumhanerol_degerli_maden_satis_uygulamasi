using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Entity.Concrete;
using DegerliMadenSatis.Shared.ResponseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Business.Concrete
{
    public class ShoppingCartItemManager : IShoppingCartItemService
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public ShoppingCartItemManager(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task<Response<NoContent>> ChangeQuantityAsync(int shoppingCartItemId, int quantity)
        {
            ShoppingCartItem shoppingCartItem = await _shoppingCartItemRepository.GetByIdAsync(x => x.Id == shoppingCartItemId);
            await _shoppingCartItemRepository.ChangeQuantityAsync(shoppingCartItem, quantity);
            return Response<NoContent>.Success();
        }

        public Task<Response<NoContent>> ClearShoppingCartAsync(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync(int shoppingCartId)
        {
            return await _shoppingCartItemRepository.GetCount(x=>x.ShoppingCartId==shoppingCartId);
        }

        public async Task<Response<NoContent>> DeleteFromShoppingCartAsync(int shoppingCartItemId)
        {
            var deletedCart = await _shoppingCartItemRepository.GetByIdAsync(x => x.Id == shoppingCartItemId);
            await _shoppingCartItemRepository.HardDeleteAsync(deletedCart);
        }
    }
}
