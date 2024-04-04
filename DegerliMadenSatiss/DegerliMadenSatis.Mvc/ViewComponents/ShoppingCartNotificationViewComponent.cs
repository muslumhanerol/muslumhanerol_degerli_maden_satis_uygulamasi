using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.ViewComponents
{
    public class ShoppingCartNotificationViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
