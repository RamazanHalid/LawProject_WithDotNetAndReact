using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.SmsAccountDtos;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class SmsAccountManager : ISmsAccountService
    {
        private readonly ISmsAccountDal _smsAccountDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        public SmsAccountManager(ISmsAccountDal smsAccountDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _smsAccountDal = smsAccountDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        //Needed to authority as a lawyer or licence owner.
        //[SecuredOperation("SmsAccountAdd")]
        public IResult Add(SmsAccountAddDto smsAccountAddDto)
        {
            SmsAccount smsAccount = _mapper.Map<SmsAccount>(smsAccountAddDto);
            smsAccount.SmsCount = 50;
            _smsAccountDal.Add(smsAccount);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //Increase count of message.
        public IResult IncreaseCountOfSms(int id, int smsCount)
        {
            var smsAccount = _smsAccountDal.Get(c => c.SmsAccountId == id);
            if (smsAccount == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            smsAccount.SmsCount += smsCount;
            _smsAccountDal.Update(smsAccount);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        //[SecuredOperation("SmsAccountDelete")]
        public IResult Delete(int id)
        {
            var smsAccount = _smsAccountDal.Get(cs => cs.SmsAccountId == id);
            if (smsAccount == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _smsAccountDal.Delete(smsAccount);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        //[SecuredOperation("SmsAccountGetAll")]
        public IDataResult<List<SmsAccountGetDto>> GetAll()
        {
            List<SmsAccount> smsAccountes = _smsAccountDal.GetAll(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<SmsAccountGetDto> smsAccountDtos = _mapper.Map<List<SmsAccountGetDto>>(smsAccountes);
            return new SuccessDataResult<List<SmsAccountGetDto>>(smsAccountDtos, Messages.GetAllSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        //[SecuredOperation("SmsAccountGetAll")]
        public IDataResult<SmsAccountGetDto> GetById(int id)
        {
            var smsAccount = _smsAccountDal.Get(cs => cs.SmsAccountId == id);
            SmsAccountGetDto smsAccountDto = _mapper.Map<SmsAccountGetDto>(smsAccount);
            if (smsAccount == null)
                return new ErrorDataResult<SmsAccountGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<SmsAccountGetDto>(smsAccountDto, Messages.GetByIdSuccessfuly);
        }
        public IDataResult<SmsAccount> GetByLicenceId(int licenceId)
        {
            var smsAccount = _smsAccountDal.Get(cs => cs.LicenceId == licenceId);
             return new SuccessDataResult<SmsAccount>(smsAccount, Messages.GetByIdSuccessfuly);
        }
    }
}
