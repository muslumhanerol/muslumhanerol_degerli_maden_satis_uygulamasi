using DegerliMadenSatis.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Entity.Concrete
{
    public class ShoppingCart:IMainEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItem { get;}

    }
}
