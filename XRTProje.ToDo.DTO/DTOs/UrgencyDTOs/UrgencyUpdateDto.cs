using System;
using System.Collections.Generic;
using System.Text;

namespace XRTProje.ToDo.DTO.DTOs.UrgencyDTOs
{
    public class UrgencyUpdateDto
    {
        public int Id { get; set; }
        //[Display(Name = "Tanım")]
        //[Required(ErrorMessage = "Tanım Alanı Boş Geçilemez")]
        public string Description { get; set; }
    }
}
