using System;
using System.Collections.Generic;
using System.Text;

namespace XRTProje.ToDo.DTO.DTOs.DutyDTOs
{
   public class DutyAddDto
    {
        //[Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Lütfen Bir Aciliyet Durumu Belirtiniz")]
        public int UrgencyId { get; set; }
    }
}
