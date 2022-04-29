using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDutyRepository : EfGenericRepository<Duty>, IDutyDal
    {
        public Duty GetirAciliyetileId(int id)
        {
            using var context = new TodoContext();
            //Eager Loading
            return context.Duties.Include(I => I.Urgency).FirstOrDefault(I => !I.Durum && I.Id == id);
        }
        public Duty GetirRaporlarileId(int id)
        {
            using var context = new TodoContext();
            return context.Duties.Include(I => I.Reports).Include(I => I.AppUser).Where(I => I.Id == id).FirstOrDefault();
        }

        public List<Duty> GetirAciliyetİleTamamlanmayan()
        {
            using var context = new TodoContext();
            //Eager Loading
            return context.Duties.Include(I => I.Urgency).Where(I => !I.Durum).OrderByDescending(I => I.OlusturulmaTarih).ToList();
        }

        public List<Duty> GetirileAppUserId(int appuserId)
        {
            using var context = new TodoContext();
            return context.Duties.Where(I => I.AppUserId == appuserId).ToList();
        }

        public List<Duty> GetirTumTablolarla()
        {
            using var context = new TodoContext();

            return context.Duties.Include(I => I.Urgency).Include
            (I => I.Reports).Include(I => I.AppUser).Where(I => !I.Durum).OrderByDescending
            (I => I.OlusturulmaTarih).ToList();
        }

        public List<Duty> GetirTumTablolarla(Expression<Func<Duty, bool>> filter)
        {
            using var context = new TodoContext();

            return context.Duties.Include(I => I.Urgency).Include
            (I => I.Reports).Include(I => I.AppUser).Where(filter).OrderByDescending
            (I => I.OlusturulmaTarih).ToList();
        }

        public List<Duty> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa = 1)
        {
            using var context = new TodoContext();

            var returnValue = context.Duties.Include(I => I.Urgency).Include
            (I => I.Reports).Include(I => I.AppUser).Where(I => I.AppUserId == userId && I.Durum).OrderByDescending
            (I => I.OlusturulmaTarih);

            toplamSayfa = (int)Math.Ceiling((double)returnValue.Count() / 3);

            return returnValue.Skip((aktifSayfa - 1) * 3).Take(3).ToList();
        }

        public int GetirGorevSayisiTamamlananileAppUserId(int id)
        {
            using var context = new TodoContext();
            return context.Duties.Count(I => I.AppUserId == id && I.Durum);
        }

        public int GetirGorevSayisiTamamlanmasıGerekenileAppUserId(int id)
        {
            using var context = new TodoContext();
            return context.Duties.Count(I => I.AppUserId == id && !I.Durum);
        }

        public int GetirAtanmayıBekleyenGorevSayisi()
        {
            using var context = new TodoContext();
            return context.Duties.Count(I => I.AppUserId == null && !I.Durum);
        }

        public int GetirGorevTamamlanmis()
        {
            using var context = new TodoContext();
            return context.Duties.Count(I=>I.Durum);
        }
    }
}
