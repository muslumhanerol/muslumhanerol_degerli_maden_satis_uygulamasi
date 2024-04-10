using AutoMapper;
using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Shared.ResponseViewModels;
using DegerliMadenSatis.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Business.Concrete
{
    public class ShoppingCartManager : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public ShoppingCartManager(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> AddToCartAsync(string userId, int productId, int quantity)
        {
            var shoppingCart = await GetShoppingCartByUserIdAsync(userId);
            if (shoppingCart != null)
            {
                var index = shoppingCart.Data.ShoppingCartItems.FindIndex(x=>x.ProductId==productId)
            }
        }

        public Task<Response<NoContent>> ClearShoppingCartAsync(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteFromShoppingCartAsync(int shoppingCartId, int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ShoppingCartViewModel>> GetShoppingCartByUserIdAsync(string userId)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartByUserIdAsync(userId);
            if (shoppingCart == null)
            {
                return Response<ShoppingCartViewModel>.Fail("İlgili kullanıcının sepetinde sorun var, yöneticiyle görüşünüz");
            }
            var result = _mapper.Map<ShoppingCartItemViewModel>(shoppingCart);
            return Response<ShoppingCartViewModel>.Success(result);
            
        }

        public Task<Response<NoContent>> InitializeShoppingCartAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
