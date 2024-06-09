using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Entity.Concrete.identity;
using DegerliMadenSatis.Shared.ViewModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
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
        
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel orderViewModel)
        {
            var userId = _userManager.GetUserId(User);
            var shoppingCart = await _shoppingCartManager.GetShoppingCartByUserIdAsync(userId);
            orderViewModel.ShoppingCart = shoppingCart.Data;

            //Ödeme yöntemi iyzico başlar.

            //Yapılacak ödeme isteğinin Authorization seçenekleri için nesne yaratılıyor.            
            Options options = new Options();
            options.ApiKey = "your api key";
            options.SecretKey = "your secret key";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            
            //Yapılacak ödeme isteği için nesne yaratılıyor.
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString(); // tr yada en seçebiliriz.
            request.ConversationId = "123456789"; //özel filtreleme yapabilmek için kullanılan id üretmemizi söylüyor
            request.Price = orderViewModel.ShoppingCart.TotalPrice().ToString().Replace(".",","); //Sepetin toplam tutarı.
            request.PaidPrice = orderViewModel.ShoppingCart.TotalPrice().ToString().Replace(".", ",");
            request.Currency = Currency.TRY.ToString(); //Para birimi.
            request.Installment = 1; //Taksit sayısı.
            request.BasketId = orderViewModel.ShoppingCart.Id.ToString(); //iyzico da ilgili satışın bir id si oluşacak o basket id.
            request.PaymentChannel = PaymentChannel.WEB.ToString(); //Ödeme kanalı.
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            
            
            return Redirect("~/");
        }

    }
}
