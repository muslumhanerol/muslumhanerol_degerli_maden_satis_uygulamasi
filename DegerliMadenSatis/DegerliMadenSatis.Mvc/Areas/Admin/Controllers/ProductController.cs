using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel) //Overloading = aynı isimli metodu farklı amaç için kullanma.
        {
            _productManager.Create(productViewModel); // Create.cshtml içerisindeki buton tetiklendiğinde çalışacak ve içerisindeki tüm bilgileri paket edip productViewModel içerisine verecek.
            return RedirectToAction("index"); //Ürün eklendikten sonra index e yönlendirecek.
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            ProductViewModel editedProduct = _productManager.GetById(id); //Edit sayfasında formlar dolu gelsin dedik.
            return View(editedProduct);
        }
        [HttpPost]
        public IActionResult Edit (ProductViewModel editedProduct)
        {
            _productManager.Update(editedProduct);
            return RedirectToAction("index");
        }
    }
}
