using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SmsHistoryManager : ISmsHistoryService
    {
        private ISmsHistoryDal _smsHistoryDal;
        private readonly ICurrentUserService _currentUserService;
        public SmsHistoryManager(ISmsHistoryDal smsHistoryDal, ICurrentUserService currentUserService)
        {
            _smsHistoryDal = smsHistoryDal;
            _currentUserService = currentUserService;
        }

        public IResult Add(SmsHistory smsHistory)
        {
            _smsHistoryDal.Add(smsHistory);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<SmsHistory>> GetAll(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<SmsHistory>>(
                _smsHistoryDal.GetAllWithPagination(pageNumber, pageSize, c => c.LicenceId == _currentUserService.GetLicenceId())
                , Messages.GetAllSuccessfuly);
        }

    }
}
