using DegerliMadenSatis.Core.ViewModels;
using DegerliMadenSatis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Business.Abstract
{
    public interface IProductService
    {
        //Interface özeliği gereği sadece metot imzaları alır, gövdesi yer almaz. Burda miras alınan class ta yazılır.
        //Produck CRUD işlemlerinin metotları burada yazılır.
        void Create(ProduckViewModel model);
        List<ProduckViewModel> GetAll(bool? isHome = null, bool? isActive = null, bool? isDelete = null); //? nullable yapıyor.
        ProduckViewModel GetById(int id);        
        void Update(ProduckViewModel model);
        void HardDelete(int id);
        void SoftDelete(int id);
    }
}
