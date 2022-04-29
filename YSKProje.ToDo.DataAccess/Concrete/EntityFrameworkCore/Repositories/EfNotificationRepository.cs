using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{

    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetirOkunmayanlar(int AppUserId)
        {
            using var context = new TodoContext();
            return context.Notifications.Where(I => I.AppUserId == AppUserId && !I.Durum).ToList();
        }

        public int GetirOkunmayanSayisiileAppUserId(int AppUserId)
        {
            using var context = new TodoContext();
            return context.Notifications.Count(I => I.AppUserId == AppUserId && !I.Durum);

        }
    }
}
