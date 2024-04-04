using Microsoft.AspNetCore.Mvc;

namespace DegerliMadenSatis.MVC.ViewComponents
{
    public class MessageNotificationViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //COMPONENT İÇİN BU ADIMLARI İZLE
            //Component yapma= Kod onunabilirliğini artırma adınana yapılır. İlk ViewComponent içerisine class eklenir isim ViewComponent olarak bitmek zorundaç
            //iki views > shared > components içerisine yeni folder eklenir ismi component ismiyle uyumlu olmaı.
            //üç klasör içinde bir view eklenir adı Default olmalı. Default içine kodlar ör:index ten kesilip yapıştırılır.
            //dört kodların kesildiği yere @await Component.InvokeAsync("buraya viewcomponent te ne isim verdiysek onu sonunda viewcomponent olmayacak şekilde yazmalıyız") yazılır.
            //ör: @await Component.InvokeAsync("Categories")
            return View();
        }
    }
}
