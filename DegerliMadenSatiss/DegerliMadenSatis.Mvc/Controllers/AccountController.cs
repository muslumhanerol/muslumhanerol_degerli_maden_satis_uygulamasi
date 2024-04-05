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
            return View();
        }
        


        [HttpGet] //Login işlemi 2. adım burası. 3.adım sağ IActionResult Login için view oluştur ismi Login olsun.
        public IActionResult Login()  //MVC>Views>Account içerisine oluşacak.
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel) //5.Adım burası. Login işlemini yaptıracak komutlar
        {
            if (!ModelState.IsValid) //Kurallara uygun giriş yapılmamışsa.
            {
                return View(loginViewModel); //tekrar onu gönder.

            }
            return View();
        }
    }
}
