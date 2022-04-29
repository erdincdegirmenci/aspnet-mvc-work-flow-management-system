using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;       
        }
        public List<Notification> GetirHepsi()
        {
            return _notificationDal.GetirHepsi();
        }

        public Notification GetirIdile(int id)
        {
           return _notificationDal.GetirIdile(id);
        }

        public List<Notification> GetirOkunmayanlar(int AppUserId)
        {
            return _notificationDal.GetirOkunmayanlar(AppUserId);
        }

        public int GetirOkunmayanSayisiileAppUserId(int AppUserId)
        {
            return _notificationDal.GetirOkunmayanSayisiileAppUserId(AppUserId);
        }

        public void Guncelle(Notification tablo)
        {
             _notificationDal.Guncelle(tablo);
        }

        public void Kaydet(Notification tablo)
        {
             _notificationDal.Kaydet(tablo);
        }

        public void Sil(Notification tablo)
        {
             _notificationDal.Sil(tablo);
        }
    }
}
