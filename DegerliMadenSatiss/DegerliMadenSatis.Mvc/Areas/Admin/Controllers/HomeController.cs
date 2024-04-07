using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")] //Yönetim paneline giriþ için SuperAdmin,Admin izin verildi, custumer e verilmedi. Rol tanýmlamayý Data>Entensions>ModelBuilder içinde.
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
