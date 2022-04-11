using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.TransactionActivityDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TransactionActivityManager : ITransactionActivityService
    {
        private readonly ITransactionActivityDal _transactionActivityDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public TransactionActivityManager(ITransactionActivityDal transactionActivityDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _transactionActivityDal = transactionActivityDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public IResult Add(TransactionActivityAddDto transactionActivityAddDto)
        {
            TransactionActivity transactionActivity = _mapper.Map<TransactionActivity>(transactionActivityAddDto);
            transactionActivity.LicenceId = _currentUserService.GetLicenceId();
            transactionActivity.UserWhoAddId = _currentUserService.GetUserId();
            _transactionActivityDal.Add(transactionActivity);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            TransactionActivity transactionActivity = _transactionActivityDal.Get(c => c.TransactionActivityId == id);
            if (transactionActivity == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _transactionActivityDal.Delete(transactionActivity);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<TransactionActivityGetDto>> GetAll()
        {
            List<TransactionActivity> transactionActivitys = _transactionActivityDal.GetAllWithInclude(c => c.LicenceId == _currentUserService.GetLicenceId());
            List<TransactionActivityGetDto> transactionActivityGetDtos = _mapper.Map<List<TransactionActivityGetDto>>(transactionActivitys);
            return new SuccessDataResult<List<TransactionActivityGetDto>>(transactionActivityGetDtos, Messages.GetAllSuccessfuly);
        }

        public IDataResult<TransactionActivityGetDto> GetById(int id)
        {
            TransactionActivity transactionActivity = _transactionActivityDal.GetWithInclude(c => c.TransactionActivityId == id);
            TransactionActivityGetDto transactionActivityGetDto = _mapper.Map<TransactionActivityGetDto>(transactionActivity);
            return new SuccessDataResult<TransactionActivityGetDto>(transactionActivityGetDto, Messages.GetByIdSuccessfuly);
        }

        public IResult ApproveTransactionActivity(int id)
        {
            TransactionActivity transactionActivity = _transactionActivityDal.GetWithInclude(c => c.TransactionActivityId == id);
            transactionActivity.IsApproved = true;
            transactionActivity.WhoApprovedId = _currentUserService.GetUserId();
            _transactionActivityDal.Update(transactionActivity);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }


        public IResult Update(TransactionActivityUpdateDto transactionActivityUpdateDto)
        {
            TransactionActivity transactionActivity = _transactionActivityDal.Get(t => t.TransactionActivityId == transactionActivityUpdateDto.TransactionActivityId);
            //TransactionActivity transactionActivity = _mapper.Map<TransactionActivity>(transactionActivityUpdateDto);
            transactionActivity.Info = transactionActivityUpdateDto.Info;
            transactionActivity.TransactionActivitySubTypeId = transactionActivityUpdateDto.TransactionActivitySubTypeId;
            transactionActivity.IsItExpense = transactionActivityUpdateDto.IsItExpense;
            transactionActivity.Amount = transactionActivityUpdateDto.Amount;
            transactionActivity.Date = transactionActivityUpdateDto.Date;
            _transactionActivityDal.Update(transactionActivity);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }

        public IDataResult<int> GetCountByLicenceId(int licenceId)
        {
            var countObj = _transactionActivityDal.GetCount(cs => cs.LicenceId == licenceId);
            return new SuccessDataResult<int>(countObj, Messages.GetCountSuccessfuly);
        }

        public IDataResult<float> TotalBalance()
        {
            float expenseSum = _transactionActivityDal.GetSum(r => r.Amount, w => w.IsItExpense == true && w.LicenceId == _currentUserService.GetLicenceId());
            float incomingSum = _transactionActivityDal.GetSum(r => r.Amount, w => w.IsItExpense == false && w.LicenceId == _currentUserService.GetLicenceId());
            return new SuccessDataResult<float>(incomingSum - expenseSum, Messages.GetCountSuccessfuly);
        }
        public IDataResult<float> TotalExpense()
        {
            float expenseSum = _transactionActivityDal.GetSum(r => r.Amount, w => w.IsItExpense == true && w.LicenceId == _currentUserService.GetLicenceId());
            return new SuccessDataResult<float>(expenseSum, Messages.GetCountSuccessfuly);
        }
        public IDataResult<float> TotalIncome()
        {
            float incomingSum = _transactionActivityDal.GetSum(r => r.Amount, w => w.IsItExpense == false && w.LicenceId == _currentUserService.GetLicenceId());
            return new SuccessDataResult<float>(incomingSum, Messages.GetCountSuccessfuly);
        }
    }
}
