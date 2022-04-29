using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyDal _urgencyDal;
        public UrgencyManager(IUrgencyDal urgencyDal)
        {
            _urgencyDal = urgencyDal;
        }
        public List<Urgency> GetirHepsi()
        {
            return _urgencyDal.GetirHepsi();
        }

        public Urgency GetirIdile(int id)
        {
            return _urgencyDal.GetirIdile(id);
        }

        public void Guncelle(Urgency tablo)
        {
            _urgencyDal.Guncelle(tablo);
        }

        public void Kaydet(Urgency tablo)
        {
            _urgencyDal.Kaydet(tablo);
        }

        public void Sil(Urgency tablo)
        {
            _urgencyDal.Sil(tablo);
        }
    }
}
