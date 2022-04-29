using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace XRTProje.ToDo.DTO.DTOs.DutyDTOs
{
    public class DutyListAllDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarih { get; set; }

        public YSKProje.ToDo.Entities.Concrete.Urgency Urgency { get; set; }

        public AppUser AppUser { get; set; }

        public List<Report> Reports { get; set; }
    }
}
