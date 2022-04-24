using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface IPaymentHistoryService
    {
        IDataResult<List<PaymentHistory>> GetAll();
        IResult Add(PaymentHistory PaymentHistory);
    }
}
