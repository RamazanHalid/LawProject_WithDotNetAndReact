using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Encryption;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CreditCardReminderDtos;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CreditCardReminderManager : ICreditCardReminderService
    {
        private readonly ICreditCardReminderDal _creditCardReminderDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        public CreditCardReminderManager(ICreditCardReminderDal creditCardReminderDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _creditCardReminderDal = creditCardReminderDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        //Adding new item as an User
        //Authority needed
        //[SecuredOperation("CreditCardReminderAdd")]
        public IResult Add(CreditCardReminderAddDto creditCardReminderAddDto)
        {
            CreditCardReminder creditCardReminder = _mapper.Map<CreditCardReminder>(creditCardReminderAddDto);
            creditCardReminder.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            creditCardReminder.CreditCardNo = SecurityString.EncryptString(creditCardReminder.CreditCardNo);
            _creditCardReminderDal.Add(creditCardReminder);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        //GetAll items as an User
        //Authority needed
        //[SecuredOperation("CreditCardReminderGetAll")]
        public IDataResult<List<CreditCardReminderGetDto>> GetAll()
        {
            List<CreditCardReminder> creditCardReminders = _creditCardReminderDal.GetAllWithDecrypted(p => p.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<CreditCardReminderGetDto> creditCardReminderDtos = _mapper.Map<List<CreditCardReminderGetDto>>(creditCardReminders);
            return new SuccessDataResult<List<CreditCardReminderGetDto>>(creditCardReminderDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }

        //Get special item
        //Authority needed
        //[SecuredOperation("CreditCardReminderGetAll")]
        public IDataResult<CreditCardReminderGetDetailsDto> GetById(int id)
        {
            CreditCardReminder creditCardReminder = _creditCardReminderDal.GetWithDecrypted(pt => pt.Id == id);
            CreditCardReminderGetDetailsDto creditCardReminderDto = _mapper.Map<CreditCardReminderGetDetailsDto>(creditCardReminder);
            return new SuccessDataResult<CreditCardReminderGetDetailsDto>(creditCardReminderDto, Messages.GetByIdSuccessfuly);
        }

        public IDataResult<bool> CheckTheCardIsExist(string creditCardNo)
        {
            var creditCardReminder = _creditCardReminderDal.GetAllWithDecrypted();
            var re = creditCardReminder.Find(e => e.CreditCardNo == creditCardNo);
            if (re == null)
                return new SuccessDataResult<bool>(false,Messages.TheItemDoesNotExists);
            return new SuccessDataResult<bool>(true, Messages.TheItemExists);
        }
        //Delete special item
        //Authority needed
        //[SecuredOperation("CreditCardReminderDelete")]
        public IResult Delete(int id)
        {
            var creditCardReminder = _creditCardReminderDal.Get(pt => pt.Id == id);
            _creditCardReminderDal.Delete(creditCardReminder);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        //Update special item
        //Authority needed
        //[SecuredOperation("CreditCardReminderUpdate")]
        public IResult Update(CreditCardReminderUpdateDto creditCardReminderDto)
        {
            CreditCardReminder creditCardReminder = _mapper.Map<CreditCardReminder>(creditCardReminderDto);
            creditCardReminder.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            creditCardReminder.CreditCardNo = SecurityString.EncryptString(creditCardReminder.CreditCardNo);
            _creditCardReminderDal.Update(creditCardReminder);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
