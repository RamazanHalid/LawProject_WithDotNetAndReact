using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.PaymentHistoryDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface IPaymentHistoryService
    {
        IDataResult<List<PaymentHistory>> GetAll();
        IResult Add(PaymentHistory PaymentHistory);
        [SecuredOperation("admin")]
        IDataResult<List<PaymentHistoryListAsAdmin>> GetAllAsAdminWithFilter(int pageNumber, int pageSize, int licenceId);
    }
}
