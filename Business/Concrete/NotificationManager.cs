using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notification;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        public NotificationManager(INotificationDal notification, ICurrentUserService authenticatedUserInfoService)
        {
            _notification = notification;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }
        public IResult Add(Notification notification)
        {
            notification.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _notification.Add(notification);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IResult AddAll(List<Notification> notifications)
        {
            notifications.ForEach(n => n.LicenceId = _authenticatedUserInfoService.GetLicenceId());
            notifications.AddRange(notifications);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<Notification>> GetAll()
        {
            List<Notification> notifications = _notification.GetAll(p => p.LicenceId == _authenticatedUserInfoService.GetLicenceId()
            && p.UserId == _authenticatedUserInfoService.GetUserId());
            return new SuccessDataResult<List<Notification>>(notifications, Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<Notification> GetById(int id)
        {
            Notification notification = _notification.Get(pt => pt.NotificationId == id);
            return new SuccessDataResult<Notification>(notification, Messages.GetByIdSuccessfuly);
        }
        public IDataResult<int> GetCount()
        {
            var notification = _notification.GetCount(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId()
            && c.UserId == _authenticatedUserInfoService.GetUserId() && c.IsRead == false);
            return new SuccessDataResult<int>(notification, Messages.GetCountSuccessfuly);
        }
        public IResult MakeItRead(int id)
        {
            var notification = _notification.Get(p => p.NotificationId == id);
            if (notification == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            notification.IsRead = true;
            _notification.Update(notification);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }
        public IResult Delete(int id)
        {
            var notification = _notification.Get(pt => pt.NotificationId == id);
            _notification.Delete(notification);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        public IResult DeleteAll()
        {
            var notifications = _notification.GetAll(p => p.LicenceId == _authenticatedUserInfoService.GetLicenceId()
             && p.UserId == _authenticatedUserInfoService.GetUserId());
            _notification.DeleteAll(notifications);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        public IResult MakeItReadAll()
        {
            var notifications = _notification.GetAll(p => p.LicenceId == _authenticatedUserInfoService.GetLicenceId()
             && p.UserId == _authenticatedUserInfoService.GetUserId() && p.IsRead == false);
            notifications.ForEach(w => w.IsRead = true);
            _notification.UpdateAll(notifications);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }


    }
}
