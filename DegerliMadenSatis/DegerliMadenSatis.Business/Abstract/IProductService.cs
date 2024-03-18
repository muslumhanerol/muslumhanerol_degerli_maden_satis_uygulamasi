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
        List<Product> GetAll(bool? isHome, bool? isActive, bool? isDelete); //? nullable yapıyor.
    }
}
