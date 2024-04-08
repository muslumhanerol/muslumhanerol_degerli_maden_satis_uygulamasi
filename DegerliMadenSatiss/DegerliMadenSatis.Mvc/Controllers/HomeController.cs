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

        public async Task<IActionResult> Index() //�r�nleri listeleme sepete eklemek i�in.
        {
            var products = await _productManager.GetAllNonDeletedAsync(); //Silinmemi� ve aktif kay�tlar� getir dedik.
            return View(products.Data);
        }
    }
}
