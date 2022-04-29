using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Interfaces
{
    public interface INotificationService:IGenericService<Notification>
    {
        List<Notification> GetirOkunmayanlar(int AppUserId);
        int GetirOkunmayanSayisiileAppUserId(int AppUserId);
    }
}
