using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.LicenceDtos;
using Entities.DTOs.SmsAccountDtos;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class LicenceManager : ILicenceService
    {
        private readonly ILicenceDal _licenceDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly ISmsAccountService _smsAccountService;
        private readonly ICaseeService _caseeService;
        private readonly ITransactionActivityService _transactionActivityService;
        private readonly ILicenceUserService _licenceUserService;
        private readonly ICustomerService _customerService;
        public LicenceManager(ILicenceDal licenceDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService, IOperationClaimService operationClaimService, IUserOperationClaimService userOperationClaimService, ISmsAccountService smsAccountService, ICaseeService caseeService, ITransactionActivityService transactionActivityService, ILicenceUserService licenceUserService, ICustomerService customerService)
        {
            _licenceDal = licenceDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
            _smsAccountService = smsAccountService;
            _caseeService = caseeService;
            _transactionActivityService = transactionActivityService;
            _licenceUserService = licenceUserService;
            _customerService = customerService;
        }

        //Add new licence as an user.
        [SecuredOperation("LicenceOwner")]
        public IResult Add(LicenceAddDto licenceAddDto)
        {
            var result = AddForSystem(licenceAddDto);
            return result;
        }
        [ValidationAspect(typeof(LicenceAddDtoValidator))]
        public IResult AddForSystem(LicenceAddDto licenceAddDto)
        {
            var rules = BusinessRules.Run(DoesLicenceProfileNameExist(licenceAddDto.ProfilName));
            bool doesItFirstLicence = DoesItFirstLicence(licenceAddDto.UserId).Success;
            if (!rules.Success)
                return rules;
            Licence licence = _mapper.Map<Licence>(licenceAddDto);
            licence.Balance = 0;
            licence.Gb = 1;
            licence.IsMain = doesItFirstLicence;
            licence.StartDate = DateTime.Now;
            licence = _licenceDal.AddWithReturn(licence);
            var defaultClaims = _operationClaimService.GetByName("LicenceOwner");
            var result = _userOperationClaimService.Add(new UserOperationClaim
            {
                LicenceId = licence.LicenceId,
                UserId = licenceAddDto.UserId,
                OperationClaimId = defaultClaims.Data.Id
            });
            if (!result.Success)
                return result;
            _smsAccountService.Add(new SmsAccountAddDto()
            {
                LicenceId = licence.LicenceId
            });

            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        //Get current auth user licence informations.
        //Need to LicenceGet authority.
        [SecuredOperation("LicenceOwner")]
        public IDataResult<LicenceGetForUpdatingDto> GetCurrentAuthUserLicence()
        {
            var licence = _licenceDal.GetByIdWithInclude(l => l.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            if (licence == null)
                return new ErrorDataResult<LicenceGetForUpdatingDto>(Messages.TheItemDoesNotExists);
            LicenceGetForUpdatingDto licenceGetDto = _mapper.Map<LicenceGetForUpdatingDto>(licence);
            return new SuccessDataResult<LicenceGetForUpdatingDto>(licenceGetDto, Messages.GetByIdSuccessfuly);
        }
        //Get Special licence by licence Id
        public IDataResult<Licence> GetById(int id)
        {
            var licence = _licenceDal.GetByIdWithInclude(l => l.LicenceId == id);
            if (licence == null)
                return new ErrorDataResult<Licence>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<Licence>(licence);
        }

        //Just after login, lists the licences with userId.
        //No need authority.
        public IDataResult<List<LicenceAfterLoginDto>> GetAllAfterLogin(int userId)
        {
            List<Licence> licences = _licenceDal.GetAllWithInclude(l => l.UserId == userId);
            List<LicenceAfterLoginDto> licenceAfterLoginDtos = _mapper.Map<List<LicenceAfterLoginDto>>(licences);
            return new SuccessDataResult<List<LicenceAfterLoginDto>>(licenceAfterLoginDtos, Messages.GetAllSuccessfuly);
        }

        //Update current licence infoarmations!
        //LicenceUpdate needed for authority
        [SecuredOperation("LicenceOwner")]
        [ValidationAspect(typeof(LicenceAddDtoValidator))]
        public IResult Update(LicenceUpdateDto licenceUpdateDto)
        {
            var licenceResult = LicenceUpdateDtoToLicence(licenceUpdateDto);
            if (!licenceResult.Success)
                return licenceResult;
            _licenceDal.Update(licenceResult.Data);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }

        public IResult CheckLicenceBelongToUser(int userId, int licenceId)
        {
            bool doesItExist = _licenceDal.DoesItExist(l => l.UserId == userId && l.LicenceId == licenceId);
            if (doesItExist)
                return new SuccessResult(Messages.TheItemExists);
            return new ErrorResult(Messages.TheItemDoesNotExists);
        }
        [SecuredOperation("LicenceOwner")]
        public IResult AddBalance(int licenceId, float balance)
        {
            var licence = _licenceDal.Get(l => l.LicenceId == licenceId);

            if (licence == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            licence.Balance += balance;
            _licenceDal.Update(licence);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        [SecuredOperation("LicenceOwner")]
        public IDataResult<CountOfLicenceInfo> GetCountInfo()
        {
            int licenceId = _authenticatedUserInfoService.GetLicenceId();
            var licence = _licenceDal.Get(l => l.LicenceId == licenceId);
            var smsAccouint = _smsAccountService.GetByLicenceId(licenceId);
            return new SuccessDataResult<CountOfLicenceInfo>(new CountOfLicenceInfo
            {
                Case = _caseeService.GetCountByLicenceId(licenceId).Data,
                Client = _customerService.GetCountByLicenceId(licenceId).Data,
                CurrentBalance = licence.Balance,
                CurrentlyUsedDiskSpace = 0,
                NumberOfMember = _licenceUserService.GetCountByLicenceId(licenceId).Data,
                Sms = _smsAccountService.GetByLicenceId(licenceId).Data.SmsCount,
                TotalDiskSpace = licence.Gb,
                TransactionActivity = _transactionActivityService.GetCountByLicenceId(licenceId).Data
            }, Messages.GetAllSuccessfuly);
        }

        #region Some methods which using in this class
        //Mapping LicenceUpdateDto to Licence
        //LicenceUpdate needed for authority
        [SecuredOperation("LicenceUpdate")]
        [ValidationAspect(typeof(LicenceUpdateDtoValidator))]
        private IDataResult<Licence> LicenceUpdateDtoToLicence(LicenceUpdateDto licenceUpdateDto)
        {
            Licence licence = _licenceDal.Get(l => l.LicenceId == _authenticatedUserInfoService.GetLicenceId());//Get current licence
            if (licence.UserId != _authenticatedUserInfoService.GetUserId()) //Check Does updated licence belongs to current user
                return new ErrorDataResult<Licence>(Messages.OnlyLicenceOwnerCanChange);
            licence.BillAddress = licenceUpdateDto.BillAddress;
            licence.CityId = licenceUpdateDto.CityId;
            licence.Email = licenceUpdateDto.Email;
            licence.PersonTypeId = licenceUpdateDto.PersonTypeId;
            licence.PhoneNumber = licenceUpdateDto.PhoneNumber;
            licence.ProfilName = licenceUpdateDto.ProfilName;
            licence.TaxNo = licenceUpdateDto.TaxNo;
            licence.TaxOffice = licenceUpdateDto.TaxOffice;
            licence.WebSite = licenceUpdateDto.WebSite;
            licence.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            return new SuccessDataResult<Licence>(licence);
        }
        #endregion
        #region Business Rules
        public IResult DoesLicenceProfileNameExist(string profileName)
        {
            bool result = _licenceDal.DoesItExist(l => l.ProfilName == profileName);
            if (result)
            {
                return new SuccessResult(Messages.TheItemExists);
            }
            return new ErrorResult(Messages.TheItemDoesNotExists);


        }
        public IResult DoesItFirstLicence(int userId)
        {
            int result = _licenceDal.GetCount(l => l.UserId == userId);
            if (result == 0)
            {
                return new SuccessResult(Messages.TheItemExists);
            }
            return new ErrorResult(Messages.TheItemDoesNotExists);


        }
        #endregion
    }
}
