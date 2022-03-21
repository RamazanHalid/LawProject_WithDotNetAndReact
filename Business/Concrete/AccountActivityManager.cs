using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AccountActivityDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AccountActivityManager : IAccountActivityService
    {
        private readonly IAccountActivityDal _accountActivityDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public AccountActivityManager(IAccountActivityDal accountActivityDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _accountActivityDal = accountActivityDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public IResult Add(AccountActivityAddDto accountActivityAddDto)
        {
            AccountActivity accountActivity = _mapper.Map<AccountActivity>(accountActivityAddDto);
            accountActivity.LicenceId = _currentUserService.GetLicenceId();
            _accountActivityDal.Add(accountActivity);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            AccountActivity accountActivity = _accountActivityDal.Get(c => c.AccountActivityId == id);
            if (accountActivity == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _accountActivityDal.Delete(accountActivity);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<AccountActivityGetDto>> GetAll()
        {
            List<AccountActivity> accountActivitys = _accountActivityDal.GetAllWithInclude(c => c.LicenceId == _currentUserService.GetLicenceId());
            List<AccountActivityGetDto> accountActivityGetDtos = _mapper.Map<List<AccountActivityGetDto>>(accountActivitys);
            return new SuccessDataResult<List<AccountActivityGetDto>>(accountActivityGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<List<AccountActivityGetDto>> GetAllActive()
        {
            List<AccountActivity> accountActivitys = _accountActivityDal.GetAllWithInclude(c => c.LicenceId == _currentUserService.GetLicenceId() && c.IsActive == true);
            List<AccountActivityGetDto> accountActivityGetDtos = _mapper.Map<List<AccountActivityGetDto>>(accountActivitys);
            return new SuccessDataResult<List<AccountActivityGetDto>>(accountActivityGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<AccountActivityGetDto> GetById(int id)
        {
            AccountActivity accountActivity = _accountActivityDal.GetWithInclude(c => c.AccountActivityId == id);
            AccountActivityGetDto accountActivityGetDto = _mapper.Map<AccountActivityGetDto>(accountActivity);
            return new SuccessDataResult<AccountActivityGetDto>(accountActivityGetDto, Messages.GetByIdSuccessfuly);
        }

        public IResult Update(AccountActivityUpdateDto accountActivityUpdateDto)
        {
            AccountActivity accountActivity = _mapper.Map<AccountActivity>(accountActivityUpdateDto);
            accountActivity.LicenceId = _currentUserService.GetLicenceId();
            _accountActivityDal.Update(accountActivity);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult ChangeActivity(int id)
        {
            AccountActivity accountActivity = _accountActivityDal.Get(c => c.AccountActivityId == id);
            if (accountActivity == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            accountActivity.IsActive = !accountActivity.IsActive;
            _accountActivityDal.Update(accountActivity);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
