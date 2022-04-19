using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface INotificationService
    {
        IDataResult<List<Notification>> GetAll();
        IDataResult<Notification> GetById(int id);
        IResult Add(Notification notification);
        IResult Delete(int id);
        IResult MakeItReadAll();
        IResult DeleteAll();
        IResult MakeItRead(int id);
        IDataResult<int> GetCount();
    }
}
