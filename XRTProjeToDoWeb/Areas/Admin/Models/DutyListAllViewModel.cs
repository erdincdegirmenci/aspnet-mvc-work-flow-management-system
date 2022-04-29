using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Areas.Admin.Models
{
    public class DutyListAllViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarih { get; set; }

        public Urgency Urgency { get; set; }

        public AppUser AppUser { get; set; }

        public List<Report> Reports { get; set; }
    }
}
