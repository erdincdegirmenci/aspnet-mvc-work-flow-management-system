using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Interfaces
{
    public interface IDutyDal : IGenericDal<Duty>
    {
        List<Duty> GetirAciliyetİleTamamlanmayan();
        List<Duty> GetirTumTablolarla();
        Duty GetirAciliyetileId(int id);
        List<Duty> GetirileAppUserId(int appuserId);
        Duty GetirRaporlarileId(int id);
        /// <summary>
        /// Linq sorgusu
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        List<Duty> GetirTumTablolarla(Expression<Func<Duty, bool>> filter);
        List<Duty> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId,int aktifSayfa);

        int GetirGorevSayisiTamamlananileAppUserId(int id);
        int GetirGorevSayisiTamamlanmasıGerekenileAppUserId(int id);

        int GetirAtanmayıBekleyenGorevSayisi();

        int GetirGorevTamamlanmis();

    }
}
