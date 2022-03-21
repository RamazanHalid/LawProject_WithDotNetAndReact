using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
        public LicenceManager(ILicenceDal licenceDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService, IOperationClaimService operationClaimService, IUserOperationClaimService userOperationClaimService, ISmsAccountService smsAccountService)
        {
            _licenceDal = licenceDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
            _smsAccountService = smsAccountService;
        }

        //Add new licence as an user.
        //No need authority.
        public IResult Add(LicenceAddDto licenceAddDto)
        {
            BusinessRules.Run(DoesLicenceProfileNameExist(licenceAddDto.ProfilName));
            Licence licence = _mapper.Map<Licence>(licenceAddDto);
            licence.Balance = 0;
            licence.Gb = 1;
            licence.SmsAccountId = 1;
            licence.StartDate = DateTime.Now;
            licence = _licenceDal.AddWithReturn(licence);
            //Change here later. It will be GetAllByCategoryName!
            var defaultClaims = _operationClaimService.GetAllByCategoryId(1);
            foreach (var claim in defaultClaims.Data)
            {
                var result = _userOperationClaimService.Add(new UserOperationClaim
                {
                    LicenceId = licence.LicenceId,
                    UserId = licenceAddDto.UserId,
                    OperationClaimId = claim.Id
                });
                if (!result.Success)
                    return result;
            }

            _smsAccountService.Add(new SmsAccountAddDto()
            {
                LicenceId = licence.LicenceId
            });

            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //Get current auth user licence informations.
        //Need to LicenceGet authority.
        [SecuredOperation("LicenceGet")]
        public IDataResult<LicenceGetForUpdatingDto> GetCurrentAuthUserLicence()
        {
            var licence = _licenceDal.GetByIdWithInclude(l => l.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            if (licence == null)
                return new ErrorDataResult<LicenceGetForUpdatingDto>(Messages.TheItemDoesNotExists);
            LicenceGetForUpdatingDto licenceGetDto = _mapper.Map<LicenceGetForUpdatingDto>(licence);
            return new SuccessDataResult<LicenceGetForUpdatingDto>(licenceGetDto, Messages.GetByIdSuccessfuly);
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
        [SecuredOperation("LicenceUpdate")]
        public IResult Update(LicenceUpdateDto licenceUpdateDto)
        {
            var licenceResult = LicenceUpdateDtoToLicence(licenceUpdateDto);
            if (!licenceResult.Success)
                return licenceResult;
            _licenceDal.Update(licenceResult.Data);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }



        #region Some methods which using in this class
        //Mapping LicenceUpdateDto to Licence
        //LicenceUpdate needed for authority
        [SecuredOperation("LicenceUpdate")]
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
        #endregion
    }
}
