using DegerliMadenSatis.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DegerliMadenSatis.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}