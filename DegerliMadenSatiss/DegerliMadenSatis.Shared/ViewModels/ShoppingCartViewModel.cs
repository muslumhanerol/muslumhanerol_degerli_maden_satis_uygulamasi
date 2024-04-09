using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Shared.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int ShoppingCcartId { get; set; }
        public List<ShoppingCartItemViewModel> Items { get; set; }
        public decimal TotalPrice()
        {
            return Items.Sum(x=>x.ProductPrice * x.Quantity);
        }
    }
}
