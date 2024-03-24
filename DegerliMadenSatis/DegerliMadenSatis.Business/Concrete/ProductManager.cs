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

        public void Create(ProduckViewModel model)
        {
            throw new NotImplementedException();
        }

        public List<ProduckViewModel> GetAll(bool? isHome = null, bool? isActive = null, bool? isDelete = null) //isHome u true olanları göstermek.
        {
            var products = _productRepository.GetAll();
            List<ProduckViewModel> produckViewModels = new List<ProduckViewModel>();
            ProduckViewModel produckViewModel;            
            foreach (var product in products)
            {
                produckViewModel = new ProduckViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Properties = product.Properties,
                    Url = product.Url
                };
                produckViewModels.Add(produckViewModel); //1. Product produckViewModel e dönüştürülüp listeye eklendi. Döngü bitince aynı şeyleri 2,3 ... producklar için yapılacak.
            }
            return produckViewModels;//Döngü bittiğinde içinde productViewModel tipinde değer taşıyan produckViewModels listesi olacak.
        }

        public ProduckViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProduckViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
