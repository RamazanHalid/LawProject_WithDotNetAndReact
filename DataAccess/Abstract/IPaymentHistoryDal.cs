using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.PaymentHistoryDtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IPaymentHistoryDal : IEntityRepository<PaymentHistory>
    {
        List<PaymentHistoryListAsAdmin> GetAllAsAdmin(int pageNumber, int pageSize, int licenceId);
    }
}
