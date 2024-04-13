using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Entity.Concrete.identity;
using DegerliMadenSatis.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IShoppingCartService _shoppingCartManager;
        private readonly IShoppingCartItemService _shoppingCartItemManager;


        public ShoppingCartController(UserManager<User> userManager, IShoppingCartService shoppingCartManager, IShoppingCartItemService shoppingCartItemManager)
        {
            _userManager = userManager;
            _shoppingCartManager = shoppingCartManager;
            _shoppingCartItemManager = shoppingCartItemManager;
        }

        //Kullanıcının sepeti.
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User); //O an login olan kullanıcının bana Id sini ver.
            var shoppingcart = await _shoppingCartManager.GetShoppingCartByUserIdAsync(userId); //shoppingCart ı getirdi.

            return View(shoppingcart.Data);
        }
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var userId = _userManager.GetUserId(User);
            await _shoppingCartManager.AddToCartAsync(userId,productId,quantity);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangeQuantity(ShoppingCartItemViewModel shoppingCartItemViewModel)
        {
            if (ModelState.IsValid)
            {
                await _shoppingCartItemManager.ChangeQuantityAsync(shoppingCartItemViewModel.Id, shoppingCartItemViewModel.Quantity);
                return RedirectToAction("Index");
            }
            return View(shoppingCartItemViewModel);
        }
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _shoppingCartItemManager.DeleteFromShoppingCartAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearCart(int id)
        {
            await _shoppingCartItemManager.ClearShoppingCartAsync(id);
            return RedirectToAction("Index");
        }
    }
}
