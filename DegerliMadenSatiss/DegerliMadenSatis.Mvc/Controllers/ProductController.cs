using DegerliMadenSatis.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productManager;
        private readonly ICategoryService _categoryManager;

        public ProductController(IProductService productManager, ICategoryService categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index(int? id=null)
        {
            var products = id == null ?
                await _productManager.GetAllNonDeletedAsync() :
                await _productManager.GetProductsByCategoryIdAsync(Convert.ToInt32(id));
            var category = id != null ? await _categoryManager.GetByIdAsync(Convert.ToInt32(id)) : null;
            ViewBag.CategoryName = category.Data != null ? category.Data.Name : null; 
            return View(products.Data);
        }
    }
}
