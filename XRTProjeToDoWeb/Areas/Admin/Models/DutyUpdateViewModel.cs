using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YSKProje.ToDo.Web.Areas.Admin.Models
{
    public class DutyUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Lütfen Bir Aciliyet Durumu Belirtiniz")]
        public int UrgencyId { get; set; }

    }
}
