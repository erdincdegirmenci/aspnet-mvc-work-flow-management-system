using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YSKProje.ToDo.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage ="Kullanı Adı Alanı Boş Bırakılamaz")]
        [Display(Name="Kullanıcı Adı:")]
        public string UserName { get; set; }

        [Display(Name = "Parola:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola Alanı Boş Bırakılamaz")]
        public string Password { get; set; }

        [Display(Name = "Parola Tekrar:")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Parolalar Eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage ="Geçersiz Email")]
        [Required(ErrorMessage = "Email Alanı Boş Bırakılamaz")]
        public string Email { get; set; }

        [Display(Name = "Adınız:")]
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz")]
        public string Name { get; set; }

        [Display(Name = "Soyadınız:")]
        [Required(ErrorMessage = "Soyad Alanı Boş Bırakılamaz")]
        public string SurName { get; set; }
    }
}
