using DegerliMadenSatis.Entity.Concrete.identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DegerliMadenSatis.MVC.Areas.Admin.Controllers
{
    
        [Authorize(Roles = "SuperAdmin")]
        [Area("Admin")]
        public class RoleController : Controller
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;


            public RoleController(UserManager<User> userManager, RoleManager<Role> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }
         
            public async Task<IActionResult> Index() => View(await _roleManager.Roles.ToListAsync()); //2. Yöntem kullanıcı listeleme.
        }
}
