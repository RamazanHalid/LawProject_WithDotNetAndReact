using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface ISmsHistoryService
    {
        IDataResult<List<SmsHistory>> GetAll(int pageNumber, int pageSize);
        IResult Add(SmsHistory smsHistory);
    }
}
