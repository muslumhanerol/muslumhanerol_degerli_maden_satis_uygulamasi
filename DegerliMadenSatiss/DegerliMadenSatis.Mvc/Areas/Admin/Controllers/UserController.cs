using DegerliMadenSatis.Entity.Concrete.identity;
using DegerliMadenSatis.Shared.ViewModels.IdentityModels;
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

        [HttpGet]
        public async Task<IActionResult> AssignRoles(string ıd) //Rol atama metodu
        {
            var user = await _userManager.FindByIdAsync(ıd); //Rol ataması yapmak için user ı bulur.Admın ve SuperAdmın listesi var
            
            var userRoles = await _userManager.GetRolesAsync(user); //Var olan user ın var olan rolünü alıyoruz.

            var roles = await _roleManager.Roles.Select(r => new AssignRoleViewModel //Rol listesi yarakma.
            {
                RoleId=r.Id,
                RoleName=r.Name, 
                IsAssigned=userRoles.Any(x=>x==r.Name) //SuperAdmin sıradaki rolün adına eşitse IsAssiigned true olacak, değilse false olur.

            }).ToListAsync();

            var userRolesViewModel = new UserRolesViewModel //View in ihtiyacı olan user id ve rol listesi medeli oluşturuldu.
            {
                Id = user.Id,
                Name = $"{user.FirstName} {user.LastName}",
                UserName = user.UserName,
                Roles = roles
            };
            return View(userRolesViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoles(UserRolesViewModel userRolesViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userRolesViewModel.Id);
                foreach (var role in userRolesViewModel.Roles)
                {
                    if (role.IsAssigned)
                    {
                        await _userManager.AddToRoleAsync(user, role.RoleName);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(userRolesViewModel);
        }
    }
}
