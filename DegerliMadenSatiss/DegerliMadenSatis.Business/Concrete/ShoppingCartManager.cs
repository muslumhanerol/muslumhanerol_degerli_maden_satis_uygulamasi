﻿using AutoMapper;
using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Entity.Concrete;
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
            ShoppingCart shoppingCart = await _shoppingCartRepository.GetShoppingCartByUserIdAsync(userId);
            
            if (shoppingCart != null)
            {
                //Ürün daha önce sepete eklenmişse sıra numarası bulunur ve ındex içine eklenir.
                //Eğer ürün daha önce sepette yoksa  sıra numarası -1 döner, index -1 olur.
                var index = shoppingCart.ShoppingCartItems.FindIndex(x => x.ProductId == productId);
                if (index<0)
                {
                    shoppingCart.ShoppingCartItems.Add(new ShoppingCartItem
                    {
                        ProductId = productId, //Sepete eklenen ürün.
                        Quantity = quantity,   //Adet
                        ShoppingCartId = shoppingCart.Id //Hangi sepete eklendiği.
                    });
                }else
                {
                    shoppingCart.ShoppingCartItems[index].Quantity += quantity;
                }
                await _shoppingCartRepository.UpdateAsync(shoppingCart);
                return Response<NoContent>.Success();
            }
            return Response<NoContent>.Fail("Bir hata oluştu");
        }
              
        public async Task<Response<ShoppingCartViewModel>> GetShoppingCartByUserIdAsync(string userId)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartByUserIdAsync(userId);
            if (shoppingCart == null)
            {
                return Response<ShoppingCartViewModel>.Fail("İlgili kullanıcının sepetinde sorun var, yöneticiyle görüşünüz");
            }
            var result = _mapper.Map<ShoppingCartViewModel>(shoppingCart);
            return Response<ShoppingCartViewModel>.Success(result);
            
        }

        public Task<Response<NoContent>> InitializeShoppingCartAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
