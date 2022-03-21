using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AccountActivityStatusDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AccountActivityStatusManager : IAccountActivityStatusService
    {
        private IAccountActivityStatusDal _accountActivityStatusDal;
        private readonly IMapper _mapper;

        public AccountActivityStatusManager(IAccountActivityStatusDal accountActivityStatusDal, IMapper mapper)
        {
            _accountActivityStatusDal = accountActivityStatusDal;
            _mapper = mapper;
        }
        [SecuredOperation("AccountActivityStatusAdd")]
        public IResult Add(AccountActivityStatusAddDto accountActivityStatusAddDto)
        {
            AccountActivityStatus accountActivityStatus = _mapper.Map<AccountActivityStatus>(accountActivityStatusAddDto);
            _accountActivityStatusDal.Add(accountActivityStatus);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        [SecuredOperation("AccountActivityStatusDelete")]
        public IResult Delete(int id)
        {
            var accountActivityStatus = _accountActivityStatusDal.Get(a => a.AccountActivityStatusId == id);
            if (accountActivityStatus == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _accountActivityStatusDal.Delete(accountActivityStatus);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        [SecuredOperation("AccountActivityStatusGetAll")]
        public IDataResult<List<AccountActivityStatusGetDto>> GetAll()
        {
            List<AccountActivityStatus> accountActivityStatuses = _accountActivityStatusDal.GetAll();
            List<AccountActivityStatusGetDto> accountActivityStatusGetDto = _mapper.Map<List<AccountActivityStatusGetDto>>(accountActivityStatuses);
            return new SuccessDataResult<List<AccountActivityStatusGetDto>>(accountActivityStatusGetDto, Messages.GetAllSuccessfuly);
        }
        [SecuredOperation("AccountActivityStatusGetAll")]
        public IDataResult<AccountActivityStatusGetDto> GetById(int id)
        {
            AccountActivityStatus accountActivityStatus = _accountActivityStatusDal.Get(t => t.AccountActivityStatusId == id);
            if (accountActivityStatus ==  null)
                return new ErrorDataResult<AccountActivityStatusGetDto>(Messages.TheItemDoesNotExists);
            AccountActivityStatusGetDto accountActivityStatusGetDto = _mapper.Map<AccountActivityStatusGetDto>(accountActivityStatus);
            return new SuccessDataResult<AccountActivityStatusGetDto>(accountActivityStatusGetDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("AccountActivityStatusUpdate")]
        public IResult Update(AccountActivityStatusUpdateDto accountActivityStatusUpdateDto)
        {
            AccountActivityStatus accountActivityStatus = _mapper.Map<AccountActivityStatus>(accountActivityStatusUpdateDto);
            _accountActivityStatusDal.Update(accountActivityStatus);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
