using Microsoft.AspNetCore.Mvc;
using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Shared.ResponseViewModels;
using DegerliMadenSatis.Shared.ViewModels;
using DegerliMadenSatis.MVC.Extensions;
using DegerliMadenSatis.MVC.Helpers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using DegerliMadenSatis.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace DegerliMadenSatis.MVC.Areas.Admin.Controllers
{   /*[Authorize(Roles ="SuperAdmin")]*/
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productManager;
        private readonly ICategoryService _categoryManager;
        private readonly IImageHelper _imageHelper;

        public ProductController(IProductService productManager, ICategoryService categoryManager, IImageHelper imageHelper)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _imageHelper = imageHelper;
        }

        [AllowAnonymous] //Giriş yapmış herkes buraya ulaşabilecek demek.
        public async Task<IActionResult> Index(bool id = false) //eğer false gelirse silinmemişler gözükecek, true gelirse silinmişler gözükecek.
        {
            Response<List<ProductViewModel>> result = await _productManager.GetAllNonDeletedAsync(id);  
            ViewBag.ShowDeleted = id;            
            return View(result.Data);  
        }
        public async Task<IActionResult> UpdateIsHome(int id)
        {
           var result = await _productManager.UpdateIsHomeAsync(id);
           return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var result = await _productManager.UpdateIsActiveAsync(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Create() //Yeni ürün eklemek için açılan sayfayı barındıran action.
        {
            var categories = await _categoryManager.GetActiveCategories();
            AddProductViewModel model = new AddProductViewModel
            {
                Categories = categories.Data
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductViewModel model, IFormFile image)
        {

            if (ModelState.IsValid && model.CategoryIds.Count > 0 && image != null)
            {
                model.ImageUrl = await _imageHelper.UploadImage(image, "products"); //Yükleme tamamlanınca string tipte ImageUrl veriliyor. Bizde onu model içindeki imgUrl içine ekledik.
                model.Url = Jobs.GetUrl(model.Name);
                await _productManager.CreateAsync(model);
                return RedirectToAction("index");
            }
            //Hata olduğunda bu kısım çalışacak.
            ViewBag.CategoryErrorMessage = model.CategoryIds.Count == 0 ? "Herhangi bir kategori seçmeden, ürün kaydı yapılamaz" : null; //Hata olduğunda bu kısım çalışacak.
            ViewBag.ImageErrorMessage = model.ImageUrl == null || model.ImageUrl == "" ? "Resim hatalı!" : null;
            var categories = await _categoryManager.GetActiveCategories();
            model.Categories = categories.Data;
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productManager.GetProductWithCategoriesAsync(id);
            ProductViewModel productViewModel = product.Data;
            var categories = await _categoryManager.GetActiveCategories();
            EditProductViewModel model = new EditProductViewModel
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                ImageUrl = productViewModel.ImageUrl,
                IsActive = productViewModel.IsActive,
                IsHome = productViewModel.IsHome,
                Price = productViewModel.Price,
                Properties = productViewModel.Properties,
                Url = productViewModel.Url,
                CategoryIds = productViewModel.CategoryList.Select(c => c.Id).ToList(),
                Categories = categories.Data,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model, IFormFile image)
        {
            if (ModelState.IsValid && model.CategoryIds.Count > 0) //Veriler doğruysa, 1 den fazla kategori seçilmişse if e girildi.
            {
               if(image != null) //Resim boş gelmediyse yükle.
               {
                    model.ImageUrl = await _imageHelper.UploadImage(image, "products"); //İlgili resmi products içine yükle, rastgele oluşan dosya uzantısınıda ImageUrl içine koy.                   
               }
                model.Url = Jobs.GetUrl(model.Name); //Url yi tekrar oluştur.
                await _productManager.UpdateAsync(model);
                return RedirectToAction("index");
            }
            ViewBag.CategoryErrorMessage = model.CategoryIds.Count == 0 ? "Herhangi bir kategori seçmeden, ürün kaydı yapılamaz" : null;
            var categories = await _categoryManager.GetActiveCategories();
            model.Categories = categories.Data;
            return View(model);        
        }        
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productManager.GetByIdAsync(id);
            ProductViewModel productViewModel = product.Data;
            DeleteProductViewModel model = new DeleteProductViewModel
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                CreatedDate = productViewModel.CreatedDate,
                ModifiedDate = productViewModel.ModifiedDate,
                IsDeleted = productViewModel.IsDeleted,
                ImageUrl = productViewModel.ImageUrl,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            await _productManager.HardDeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _productManager.SoftDeleteAsync(id);
            var productViewModel = await _productManager.GetByIdAsync(id);
            return Redirect($"/Admin/Product/Index/{!productViewModel.Data.IsDeleted}");
        }
    }

}
