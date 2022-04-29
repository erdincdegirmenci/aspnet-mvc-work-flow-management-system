using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Models
{
    public class ReportAddViewModel
    {
        [Required(ErrorMessage ="Tanım Alanı Boş Bırakılamaz.")]
        [Display(Name ="Tanım")]
        public string Tanım { get; set; }

        [Required(ErrorMessage = "Detay Alanı Boş Bırakılamaz.")]
        [Display(Name = "Detay")]
        public string Detay { get; set; }

        public Duty Gorev { get; set; }

        public int GorevId { get; set; }
    }
}
