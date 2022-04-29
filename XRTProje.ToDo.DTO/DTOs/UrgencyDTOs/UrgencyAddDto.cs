using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XRTProje.ToDo.DTO.DTOs.UrgencyDTOs
{
    public class UrgencyAddDto
    {
         [Display(Name ="Tanım")]/*
        [Required(ErrorMessage ="Tanım Alanı Boş Bırakılamaz.")]*/
        public string Description { get; set; }
    }
}
