using DegerliMadenSatis.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productManager;

        //Dependency Injection
        public ProductController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index() //Ürünleri çekmek istiyoruz. Business katmanın erişmem lazım, Manager daki GetAll.
        {
            var product = _productManager.GetAll();
            return View(product);
        }
        
        public IActionResult Create() //Ekrana yeni ürün eklenecek formu açacak. ProductManager dan gelen Create.
        {
            return View();
        }
    }
}
