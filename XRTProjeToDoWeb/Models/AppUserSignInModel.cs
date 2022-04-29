using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YSKProje.ToDo.Web.Models
{
    public class AppUserSignInModel
    {
        [Required(ErrorMessage = "Kullanı Adı Alanı Boş Bırakılamaz")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }

        [Display(Name = "Parola:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola Alanı Boş Bırakılamaz")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
