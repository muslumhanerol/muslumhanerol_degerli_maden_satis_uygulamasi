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

        public ShoppingCartController(UserManager<User> userManager, IShoppingCartService shoppingCartManager)
        {
            _userManager = userManager;
            _shoppingCartManager = shoppingCartManager;
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
                //
            }
        }
    }
}
