using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
    public class Report:ITablo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }

        public int DutyId { get; set; }
        public Duty Duty { get; set; }
    }
}
