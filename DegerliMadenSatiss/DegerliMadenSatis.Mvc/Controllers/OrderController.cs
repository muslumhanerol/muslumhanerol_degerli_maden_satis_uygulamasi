using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Entity.Concrete.identity;
using DegerliMadenSatis.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IShoppingCartService _shoppingCartManager;
        private readonly IOrderService _orderManager;

        public OrderController(UserManager<User> userManager, IShoppingCartService shoppingCartManager, IOrderService orderManager)
        {
            _userManager = userManager;
            _shoppingCartManager = shoppingCartManager;
            _orderManager = orderManager;
        }

        //Kullanıcıya geçmiş siparişi gösterecek.
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var shoppingCart = await _shoppingCartManager.GetShoppingCartByUserIdAsync(userId);
            OrderViewModel orderViewModel = new OrderViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Note = "Lütfen yeni tarihli gönderiniz.",
                CardNumber="4987490000000002",
                CardName="Müslüm Han Erol",
                ExpirationMonth="12",
                ExpirationYear="2029",
                Cvc="111",
                ShoppingCart=shoppingCart.Data
                
            };
            //orderViewModel.ShoppingCart=shoppingCart.Data;
            return View(orderViewModel);
        }
    }
}
