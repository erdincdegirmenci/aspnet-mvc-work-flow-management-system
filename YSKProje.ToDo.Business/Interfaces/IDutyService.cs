using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Interfaces
{
    public interface IDutyService : IGenericService<Duty>
    {
        List<Duty> GetirAciliyetİleTamamlanmayan();
        List<Duty> GetirTumTablolarla();
        Duty GetirAciliyetileId(int id);
        List<Duty> GetirileAppUserId(int appuserId);
        Duty GetirRaporlarileId(int id);
        List<Duty> GetirTumTablolarla(Expression<Func<Duty, bool>> filter);
        List<Duty> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa=1);
        int GetirGorevSayisiTamamlananileAppUserId(int id);
        int GetirGorevSayisiTamamlanmasıGerekenileAppUserId(int id);

        int GetirAtanmayıBekleyenGorevSayisi();
        int GetirGorevTamamlanmis();
    }
}
