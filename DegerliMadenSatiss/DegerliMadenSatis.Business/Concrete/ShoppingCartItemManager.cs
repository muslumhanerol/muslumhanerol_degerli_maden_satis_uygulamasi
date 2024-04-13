using DegerliMadenSatis.Business.Abstract;
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

        public Task<Response<NoContent>> ChangeQuantityAsync(int shoppingCartItemId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
