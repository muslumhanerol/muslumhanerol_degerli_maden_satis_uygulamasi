using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.ViewComponents
{
    public class MessageNotificationViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
