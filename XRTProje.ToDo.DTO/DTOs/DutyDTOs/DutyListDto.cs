using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace XRTProje.ToDo.DTO.DTOs.DutyDTOs
{
    public class DutyListDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime OlusturulmaTarih { get; set; }

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
    }
}
