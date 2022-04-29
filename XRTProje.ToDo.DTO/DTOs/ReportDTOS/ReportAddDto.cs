using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace XRTProje.ToDo.DTO.DTOs.ReportDTOS
{
   public  class ReportAddDto
    {
        //[Required(ErrorMessage = "Tanım Alanı Boş Bırakılamaz.")]
        //[Display(Name = "Tanım")]
        public string Tanım { get; set; }

        //[Required(ErrorMessage = "Detay Alanı Boş Bırakılamaz.")]
        //[Display(Name = "Detay")]
        public string Detay { get; set; }

        public Duty Gorev { get; set; }

        public int GorevId { get; set; }
    }
}
