using System;
using System.Collections.Generic;
using System.Text;

namespace XRTProje.ToDo.DTO.DTOs.AppUserDTOs
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz.")]
        //[Display(Name = "Ad")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Soyad Alanı Boş Bırakılamaz.")]
        //[Display(Name = "Soyad")]
        public string SurName { get; set; }

        //[Display(Name = "Email")]
        public string Email { get; set; }

        //[Display(Name = "Resim")]
        public string Picture { get; set; }
    }
}
