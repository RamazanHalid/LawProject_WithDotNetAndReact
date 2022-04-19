using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNotificationDal : EfEntityRepositoryBase<Notification, HukukContext>, INotificationDal
    {

        public void DeleteAll(List<Notification> notifications)
        {
            //IDisposable pattern implementation of c#
            using (var context = new HukukContext())
            {
                context.Notifications.RemoveRange(notifications);
                context.SaveChanges();
            }
        }
        public void UpdateAll(List<Notification> notifications)
        {
            //IDisposable pattern implementation of c#
            using (var context = new HukukContext())
            {
                context.Notifications.UpdateRange(notifications);
                context.SaveChanges();
            }
        }
        public void AddAll(List<Notification> notifications)
        {
            //IDisposable pattern implementation of c#
            using (var context = new HukukContext())
            {
                context.Notifications.AddRange(notifications);
                context.SaveChanges();
            }
        }

    }
}
