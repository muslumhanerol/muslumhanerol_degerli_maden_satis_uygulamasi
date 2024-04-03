using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.ViewComponents
{
    public class ShoppingNotificationViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
