using DegerliMadenSatis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Abstract
{
    public interface IProductRepository:IGenericRepository<Product> //IGenericRepository de product la ilgili ne varsa tamamı IProductRepository için de var.
    {
        //Product'a özgü metot imzaları buraya yazacağız.
        List<Product> GetProductsByCategoryId(int categoryId);
    }
}
