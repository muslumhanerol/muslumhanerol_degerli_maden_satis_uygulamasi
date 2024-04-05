using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Shared.ViewModels.IdentityModels
{//Login işlemi 1. adım burası. İkinci adım MVC>Controller>AccountController
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı alanı boş bırakılamaz.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        
        
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [DisplayName("Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
