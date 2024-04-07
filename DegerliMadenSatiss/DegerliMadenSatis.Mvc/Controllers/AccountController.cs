using DegerliMadenSatis.Entity.Concrete.identity;
using DegerliMadenSatis.Shared.ViewModels.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager; //İçinde login, logout gibi işlemleri yaptıran metotları barındıracak.

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) // Register formdan gelen verileri karşılayacak.
        {
            if (ModelState.IsValid) //Formdaki veriler RegisterViewModel da belirtilen kurallara uygun girilmiş mi girilmemiş mi kontrolü yapılır.
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    
                };
                var result = await _userManager.CreateAsync(user,registerViewModel.Password); //Kullanıcını girdiği şifreyi şifrelen algaritmayı çalıştırmak.
                if (result.Succeeded)
                {
                    /*return RedirectToAction("Index","Home");*/ //HomeControllerın indexine git.
                    return Redirect("~/"); //İkinci yöntem
                }
            }
            return View(registerViewModel);
        }
        


        [HttpGet] //Login işlemi 2. adım burası. 3.adım sağ IActionResult Login için view oluştur ismi Login olsun.//MVC>Views>Account içerisine oluşacak.
        public IActionResult Login(string returnUrl=null)  
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) //5.Adım burası. Login işlemini yaptıracak komutlar
        {
            if (!ModelState.IsValid) //Kurallara uygun giriş yapılmamışsa.
            {
                return View(loginViewModel); //tekrar aynı viewi döndür.
            }
            User user = await _userManager.FindByNameAsync(loginViewModel.UserName); //Giriş yapan kullanıcı var mı kontrolu yapar.
            if (user == null)
            {
                ModelState.AddModelError("", "Kulanıcı Bulunamadı");
                return View(loginViewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Şifre Hatalı");
                return View(loginViewModel);
            }
            
            var returnUrl = TempData["ReturnUrl"] ?.ToString(); //Null stringe çevirebilir buda hataya sebeb verir. ?.ToString diyerek null değilse çalışsın dedik.            
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl); //Herhangi bir yere girildiğinde bunu yapmak için login olman gerke derse bu çalışır. Ör:Bu kod detay a tıklandığında giriş yap sayfasına yönlendirecek.
            }
            return RedirectToAction("Index", "Home"); //Kendisi giriş yap a tıklayarak login olmuşsa bu çalışacak.          
        }

        public async Task<IActionResult> Logout() //Çıkış yap metodu.
        {
            await _signInManager.SignOutAsync();
            TempData["ReturnUrl"] = null;
            return Redirect("~/");
        }

        public async Task<IActionResult> AccessDenied() //Kullanıcı erişmemesi gereken bir yere tıkladığında ona uyaracak.mvc>views>account>accessdenied
        {
            return View();
        }
    }
}
