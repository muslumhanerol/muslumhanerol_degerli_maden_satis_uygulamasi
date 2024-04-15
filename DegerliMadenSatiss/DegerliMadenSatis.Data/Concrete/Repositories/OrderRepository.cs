using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete.Contexts;
using DegerliMadenSatis.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Concrete.Repositories
{
    public class OrderRepository:GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DegerliMadenSatisDbContext _context):base(_context)
        {

        }
        DegerliMadenSatisDbContext DegerliMadenSatisDbContext { 
            get{return _dbContext as DegerliMadenSatisDbContext; } }              
                
            
    }
}
