using System.Diagnostics;
using DegerliMadenSatis.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productManager;

        public HomeController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index() //Ürünleri listeleme sepete eklemek için.
        {
            var products = await _productManager.GetAllNonDeletedAsync(); //Silinmemiþ ve aktif kayýtlarý getir dedik.
            return View(products.Data);
        }
    }
}
