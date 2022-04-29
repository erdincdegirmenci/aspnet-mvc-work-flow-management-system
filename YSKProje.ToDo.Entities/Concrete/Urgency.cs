using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
    public class Urgency:ITablo
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Duty>Duties { get; set; }
    }
}
