using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{

    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public Report GetirGorevileId(int id)
        {
            using var context = new TodoContext();
            return context.Reports.Include(I => I.Duty).ThenInclude(I => I.Urgency).Where(I => I.Id == id).FirstOrDefault();
        }

        public int GetirRaporSayisi()
        {
            using var context = new TodoContext();
            return context.Reports.Count();
        }

        public int GetirRaporSayisiileAppUserId(int id)
        {
            using var context = new TodoContext();
            var result = context.Duties.Include(I => I.Reports).Where(I => I.AppUserId == id);
            return result.SelectMany(I => I.Reports).Count();

        }
    }
}
