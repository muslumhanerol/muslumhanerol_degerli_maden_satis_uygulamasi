using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
