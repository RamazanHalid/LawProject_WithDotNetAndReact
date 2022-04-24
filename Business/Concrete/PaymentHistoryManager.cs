using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PaymentHistoryManager : IPaymentHistoryService
    {
        private readonly IPaymentHistoryDal _paymentHistoryDal;
        private readonly ICurrentUserService _currentUserService;

        public PaymentHistoryManager(IPaymentHistoryDal paymentHistoryDal, ICurrentUserService currentUserService)
        {
            _paymentHistoryDal = paymentHistoryDal;
            _currentUserService = currentUserService;
        }

        public IResult Add(PaymentHistory paymentHistory)
        {
            _paymentHistoryDal.Add(paymentHistory);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<PaymentHistory>> GetAll()
        {
            return new SuccessDataResult<List<PaymentHistory>>(_paymentHistoryDal.GetAll(p => p.LicenceId == _currentUserService.GetLicenceId()), Messages.GetAllSuccessfuly);
        }

    }
}
