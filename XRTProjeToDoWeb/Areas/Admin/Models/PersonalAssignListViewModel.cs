using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Areas.Admin.Models
{
    public class PersonalAssignListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }
        public DutyListViewModel Duty { get; set; }
    }
}
