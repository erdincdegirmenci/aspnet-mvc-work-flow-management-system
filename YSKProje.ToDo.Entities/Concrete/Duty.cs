using System;
using System.Collections.Generic;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
    public class Duty : ITablo
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime OlusturulmaTarih { get; set; } = DateTime.Now;

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Report> Reports { get; set; }
    }
}
