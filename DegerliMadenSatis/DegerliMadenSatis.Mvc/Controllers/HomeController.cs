using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Core.ViewModels;
using DegerliMadenSatis.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DegerliMadenSatis.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productManager;

        public HomeController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var products = _productManager.GetAll(true); //1.adım _productManager daki GetAll a true yollanıyor.(ProductManager a git.)
            return View(products); //Çektiğimiz veriyi view e gönderdik.
        }
        public IActionResult GetById(int id) 
        {
            ProductViewModel product= _productManager.GetById(id);
            return View();
        }
    }
}