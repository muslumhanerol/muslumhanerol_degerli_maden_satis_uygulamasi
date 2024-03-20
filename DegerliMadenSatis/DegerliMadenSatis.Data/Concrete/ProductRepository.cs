using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Concrete
{//Class lardan birden fazla miras alınamaz anca Interface den alına bilir.
    public class ProductRepository:GenericRepository<Product>, IProductRepository //GenericRepository deki altı metot ve IProductRepository ye ait özellikler miras alındı.
    {
        
    }
}
