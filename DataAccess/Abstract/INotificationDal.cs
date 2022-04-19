using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface INotificationDal : IEntityRepository<Notification>
    {
        void DeleteAll(List<Notification> notifications);
        void UpdateAll(List<Notification> notifications);
        void AddAll(List<Notification> notifications);
    }
}
