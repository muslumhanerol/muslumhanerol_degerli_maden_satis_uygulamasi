using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Core.ViewModels;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Business.Concrete //bu bölümde IProductService den miras alan class oluşturduk.
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(ProductViewModel model) 
        {
            var product = new Product //Veri tabanında Id otomatik oluştuğu için Id yi almadık.
            {
                Name = model.Name,
                Price = model.Price,
                Properties = model.Properties,
                Url = model.Url,
                ImageUrl = model.ImageUrl,
                CreatedDdate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                IsHome = model.IsHome
            };
            _productRepository.Create(product); //_productRepository deki Create metoduna yollayabiliriz.
        }

        public List<ProductViewModel> GetAll(bool? isHome = null, bool? isActive = null, bool? isDelete = null) //HomeControllerdan isHome true geldi.
        {
            List<Product> products;
            if(isHome == null) 
            { 
                products = _productRepository.GetAll();
            }else 
            {
                products= _productRepository.GetHomePageProducts(isHome); //2.adım GetHomePageProducts a true gidiyor.(ProductRepository ye git.)
            }
            List<ProductViewModel> productViewModels = products //productViewModels i oluştururken products ların içinde Select ile dön dolaş.
                .Select(p=>new ProductViewModel
                {
                    Id=p.Id,
                    Name=p.Name,
                    Price=p.Price,
                    Url=p.Url,
                    ImageUrl=p.ImageUrl,
                    Properties=p.Properties
                }).ToList();
            return productViewModels; //Döngü bittiğinde içinde productViewModel tipinde değer taşıyan produckViewModels listesi olacak.
        }

        public ProductViewModel GetById(int id) //GenericRepository den buraya geldik. Bunu da Mvc içindeki Actiondan çağıracağız.
        {
            Product product = _productRepository.GetById(id);
            ProductViewModel productViewModel = new ProductViewModel //Elimizdeki product ı productViewModel nesnesine çevirdik.
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Url = product.Url,
                ImageUrl = product.ImageUrl,
                Properties = product.Properties
            };
            return productViewModel; //Bunu Mvc deki Controller Action da çağırabiliriz.

        }

        public void HardDelete(int id) //2.Adım 3.Adım Mvc>Admin>ProductController
        {
            Product deletedProduct = _productRepository.GetById(id);
            _productRepository.HardDelete(deletedProduct);
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductViewModel model)
        {
            Product editedProduct = _productRepository.GetById(model.Id);
            editedProduct.Name = model.Name;                         
            editedProduct.Price = model.Price;
            editedProduct.Url = model.Url;
            editedProduct.ImageUrl = model.ImageUrl;
            editedProduct.Properties = model.Properties;
            editedProduct.IsHome = model.IsHome;
            _productRepository.Update(editedProduct);
        }
    }
}



//LİNQ sorgusu olmadan önce yazılan kod.
//Aşağıdaki kodların yerine LİNQ sorgusu kullanılarak 38 46 kodları yazıldı.
//List<ProductViewModel> productViewModels = new List<ProductViewModel>();
//ProductViewModel productViewModel;            
//foreach (var product in products)            {

//        productViewModel = new ProductViewModel
//        {
//            Id = product.Id,
//            Name = product.Name,
//            Price = product.Price,
//            ImageUrl = product.ImageUrl,
//            Properties = product.Properties,
//            Url = product.Url
//        };
//        productViewModels.Add(productViewModel); //1. Product produckViewModel e dönüştürülüp listeye eklendi. Döngü bitince aynı şeyleri 2,3 ... producklar için yapılacak.

//}