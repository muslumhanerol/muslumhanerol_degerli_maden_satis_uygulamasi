using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Entity.Concrete;
using DegerliMadenSatis.Entity.Concrete.identity;
using DegerliMadenSatis.Shared.ComplexTypes;
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
            options.ApiKey = "sandbox-ZZTLjszzsjFq7ovrnsOYSfkGP08AYbmQ";
            options.SecretKey = "sandbox-a685D300jgjczi0dz586vtkgGqGntKgs";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            
            //Yapılacak ödeme isteği için nesne yaratılıyor.
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString(); // tr yada en seçebiliriz.
            request.ConversationId = "123456789"; //özel filtreleme yapabilmek için kullanılan id üretmemizi söylüyor
            request.Price = orderViewModel.ShoppingCart.TotalPrice().ToString().Replace(",","."); //Sepetin toplam tutarı.
            request.PaidPrice = orderViewModel.ShoppingCart.TotalPrice().ToString().Replace(",", ".");
            request.Currency = Currency.TRY.ToString(); //Para birimi.
            request.Installment = 1; //Taksit sayısı.
            request.BasketId = orderViewModel.ShoppingCart.Id.ToString(); //iyzico da ilgili satışın bir id si oluşacak o basket id.
            request.PaymentChannel = PaymentChannel.WEB.ToString(); //Ödeme kanalı. Şuan sadece web sitesi üzerinden alışveriş yapmayı salıyoruz.
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString(); //Ödemenin ne için yapıldığı. Burada ürün satışı.


            //Ödemenin yapılacağı kart için nesne yaratma.
            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = orderViewModel.CardName; //Kart üzerindeki isim.
            paymentCard.CardNumber = orderViewModel.CardNumber; //Kart üzerindeki kart numarası.
            paymentCard.ExpireMonth = orderViewModel.ExpirationMonth; //Son geçerlilik ayı.
            paymentCard.ExpireYear = orderViewModel.ExpirationYear; //Son geçerlilik yılı.
            paymentCard.Cvc = orderViewModel.Cvc; //Güvenlik numarası.
            paymentCard.RegisterCard = 0; //Kart kayıt etme. Burada o yani kayıtlı değil.
            request.PaymentCard = paymentCard;


            //Alıcı bilgileri için nesne yaratma.
            Buyer buyer = new Buyer();
            buyer.Id = userId;
            buyer.Name = orderViewModel.FirstName;//Formda doldurulan isim.
            buyer.Surname = orderViewModel.LastName;//Formda doldurulan soyisim.
            buyer.GsmNumber = orderViewModel.PhoneNumber;//Formda doldurulan telefon numarası.
            buyer.Email = orderViewModel.Email;
            buyer.IdentityNumber = "74300864791"; //Kimlik numarası, fatura kestiğimiz için.
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = orderViewModel.Address;
            buyer.Ip = "85.34.78.112";
            buyer.City = orderViewModel.City;
            buyer.Country = "Türkiye";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            //Adre bilgileri için nesneler yaratılıyor.
            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;


            //Sepet ürünleri için nesne yaratılıyor.
            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;
            foreach(var item in orderViewModel.ShoppingCart.ShoppingCartItems) //Bunların herbirini sırasıyla BasketItem isimli nesnenin içine koycaz.
            {
                basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.ProductName;
                basketItem.Category1 = "Külçe Altın";
                basketItem.Category2 = "";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString(); //sanal ürün mü fiziksel ürün mü?
                basketItem.Price = (item.Quantity * item.ProductPrice).ToString().Replace(",","."); //sepettiki ürünün fiyatı. sadece o ürüne ait fiyat varsa 2 adet *2 olacak şekilde. tüm sepet tutarı değil.
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems; //Sepet itemlarımızı basketitem içerisine yazdık.

            Payment payment = Payment.Create(request, options);            
            if(payment.Status == "success")
            {
                //Ödeme başarılıysa siparişi veritabanına kaydediyoruz.
                Order order = new Order
                {
                    OrderNumber = payment.PaymentId,
                    UserId = userId,
                    FirstName = orderViewModel.FirstName,
                    LastName = orderViewModel.LastName,
                    Address = orderViewModel.Address,
                    City = orderViewModel.City,
                    PhoneNumber = orderViewModel.PhoneNumber,
                    Email = orderViewModel.Email,
                    Note = orderViewModel.Note,
                    PaymentType = PaymentType.CreditCard,
                    OrderState = OrderState.Waiting,
                    ConversationId = payment.ConversationId
                };
            }
            
            
            
            
            
            
            
            return Redirect("~/");
        }

    }
}
