using DegerliMadenSatis.Entity.Concrete.identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DegerliMadenSatis.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;


        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //public async Task<IActionResult> Index() //1.Yöntem kullanıcı listeleme.
        //{
        //    var users = await _userManager.Users.ToListAsync();
        //    return View(users);
        //}
        public async Task<IActionResult> Index() => View(await _userManager.Users.ToListAsync()); //2. Yöntem kullanıcı listeleme.
    }
}
