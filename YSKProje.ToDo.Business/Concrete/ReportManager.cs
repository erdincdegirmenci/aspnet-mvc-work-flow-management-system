using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public Report GetirGorevileId(int id)
        {
            return _reportDal.GetirGorevileId(id);
        }

        public List<Report> GetirHepsi()
        {
            return _reportDal.GetirHepsi();
        }

        public Report GetirIdile(int id)
        {
            return _reportDal.GetirIdile(id);
        }

        public int GetirRaporSayisi()
        {
            return _reportDal.GetirRaporSayisi();
        }

        public int GetirRaporSayisiileAppUserId(int id)
        {
            return _reportDal.GetirRaporSayisiileAppUserId(id);
        }

        public void Guncelle(Report tablo)
        {
            _reportDal.Guncelle(tablo);
        }

        public void Kaydet(Report tablo)
        {
            _reportDal.Kaydet(tablo);
        }

        public void Sil(Report tablo)
        {
            _reportDal.Sil(tablo);
        }
    }
}
