using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class DutyManager : IDutyService
    {
        private readonly IDutyDal _dutyDal;

        public DutyManager(IDutyDal dutyDal)
        {
            _dutyDal = dutyDal;
        }

        public Duty GetirAciliyetileId(int id)
        {
            return _dutyDal.GetirAciliyetileId(id);
        }

        public List<Duty> GetirAciliyetİleTamamlanmayan()
        {
            return _dutyDal.GetirAciliyetİleTamamlanmayan();
        }

        public int GetirAtanmayıBekleyenGorevSayisi()
        {
            return _dutyDal.GetirAtanmayıBekleyenGorevSayisi();
        }

        public int GetirGorevSayisiTamamlananileAppUserId(int id)
        {
            return _dutyDal.GetirGorevSayisiTamamlananileAppUserId(id);
        }

        public int GetirGorevSayisiTamamlanmasıGerekenileAppUserId(int id)
        {
            return _dutyDal.GetirGorevSayisiTamamlanmasıGerekenileAppUserId(id);
        }

        public int GetirGorevTamamlanmis()
        {
            return _dutyDal.GetirGorevTamamlanmis();
        }

        public List<Duty> GetirHepsi()
        {
            return _dutyDal.GetirHepsi();
        }

        public Duty GetirIdile(int id)
        {
            return _dutyDal.GetirIdile(id);
        }

        public List<Duty> GetirileAppUserId(int appuserId)
        {
            return _dutyDal.GetirileAppUserId(appuserId);
        }

        public Duty GetirRaporlarileId(int id)
        {
            return _dutyDal.GetirRaporlarileId(id);
        }

        public List<Duty> GetirTumTablolarla()
        {
            return _dutyDal.GetirTumTablolarla();
        }

        public List<Duty> GetirTumTablolarla(Expression<Func<Duty, bool>> filter)
        {
            return _dutyDal.GetirTumTablolarla(filter);
        }

        public List<Duty> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa)
        {
            return _dutyDal.GetirTumTablolarlaTamamlanmayan(out toplamSayfa, userId, aktifSayfa);
        }

        public void Guncelle(Duty tablo)
        {
            _dutyDal.Guncelle(tablo);
        }

        public void Kaydet(Duty tablo)
        {
            _dutyDal.Kaydet(tablo);
        }

        public void Sil(Duty tablo)
        {
            _dutyDal.Sil(tablo);
        }

    }
}
