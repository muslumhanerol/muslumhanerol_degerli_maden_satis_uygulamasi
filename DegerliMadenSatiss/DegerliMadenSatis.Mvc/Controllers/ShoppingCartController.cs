using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Entity.Concrete.identity;
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
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var userId = _userManager.GetUserId(User);
            //await -_shoppingCartManager.AddToCartAsync();
            return View();

        }
    }
}
