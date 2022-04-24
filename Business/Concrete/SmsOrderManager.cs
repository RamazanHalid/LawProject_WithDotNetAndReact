using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.SmsOrderDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SmsOrderManager : ISmsOrderService
    {
        private ISmsOrderDal _smsOrderDal;
        private readonly IMapper _mapper;
        private readonly ILicenceService _licenceService;
        private readonly ISmsAccountService _smsAccountService;
        private readonly ICurrentUserService _currentUserService;
        public SmsOrderManager(ISmsOrderDal smsOrderDal, IMapper mapper, ILicenceService licenceService, ISmsAccountService smsAccountService, ICurrentUserService currentUserService)
        {
            _smsOrderDal = smsOrderDal;
            _mapper = mapper;
            _licenceService = licenceService;
            _smsAccountService = smsAccountService;
            _currentUserService = currentUserService;
        }
        public IResult Add(SmsOrderAddDto smsOrderAddDto)
        {
            SmsOrder smsOrder = _mapper.Map<SmsOrder>(smsOrderAddDto);
            _smsOrderDal.Add(smsOrder);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<SmsOrderGetDto>> GetAll()
        {
            List<SmsOrder> smsOrders = _smsOrderDal.GetAll();
            List<SmsOrderGetDto> smsOrderGetDtos = _mapper.Map<List<SmsOrderGetDto>>(smsOrders);
            return new SuccessDataResult<List<SmsOrderGetDto>>(smsOrderGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<SmsOrderGetDto> GetById(int id)
        {
            var smsOrder = _smsOrderDal.Get(c => c.Id == id);
            if (smsOrder == null)
                return new ErrorDataResult<SmsOrderGetDto>(Messages.TheItemDoesNotExists);
            SmsOrderGetDto smsOrderGetDto = _mapper.Map<SmsOrderGetDto>(smsOrder);
            return new SuccessDataResult<SmsOrderGetDto>(Messages.GetByIdSuccessfuly);
        }

        public IResult BuyTheSms(int smsOrderId)
        {
            var smsOrder = _smsOrderDal.Get(c => c.Id == smsOrderId);
            if (smsOrder == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            var licence = _licenceService.GetById(_currentUserService.GetLicenceId());
            if (!licence.Success)
                return licence;
            if (licence.Data.Balance < smsOrder.Price)
                return new ErrorResult("Balanced is not enough!");
            var licenceSmsAccount = _smsAccountService.GetByLicenceId(_currentUserService.GetLicenceId());
            if (!licenceSmsAccount.Success)
                return licenceSmsAccount;
            var encreaseSmsCount = _smsAccountService.IncreaseCountOfSms(licenceSmsAccount.Data.SmsAccountId, smsOrder.SmsCount);
            if (!encreaseSmsCount.Success)
                return encreaseSmsCount;
            return new SuccessResult("MMessage Encreased!");
        }

        public IResult Delete(int id)
        {
            var smsOrder = _smsOrderDal.Get(c => c.Id == id);
            if (smsOrder == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _smsOrderDal.Delete(smsOrder);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IResult Update(SmsOrderUpdateDto smsOrderUpdateDto)
        {
            SmsOrder smsOrder = _mapper.Map<SmsOrder>(smsOrderUpdateDto);
            _smsOrderDal.Update(smsOrder);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult DoesItExist(int id)
        {
            var result = _smsOrderDal.Get(c => c.Id == id);
            if (result == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            return new SuccessResult(Messages.TheItemExists);
        }
    }
}
