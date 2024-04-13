using DegerliMadenSatis.Shared.ResponseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Business.Abstract
{
    public interface IShoppingCartItemService
    {
        Task<Response<NoContent>> ChangeQuantityAsync(int shoppingCartItemId, int quantity);
    }
}
