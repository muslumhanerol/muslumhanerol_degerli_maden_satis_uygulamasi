﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Shared.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCartViewModel ShoppingCart { get; set; }
    }
}
