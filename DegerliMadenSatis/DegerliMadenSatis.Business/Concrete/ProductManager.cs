using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Core.ViewModels;
using DegerliMadenSatis.Data.Abstract;
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

        public List<ProduckViewModel> GetAll(bool? isHome, bool? isActive, bool? isDelete) //isHome u true olanları göstermek.
        {

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
