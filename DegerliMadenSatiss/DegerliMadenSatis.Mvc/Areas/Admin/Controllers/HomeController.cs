using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")] //Y�netim paneline giri� i�in SuperAdmin,Admin izin verildi, custumer e verilmedi. Rol tan�mlamay� Data>Entensions>ModelBuilder i�inde.
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
