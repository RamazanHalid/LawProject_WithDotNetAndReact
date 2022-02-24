using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class LicenceManager : ILicenceService
    {
        private readonly ILicenceDal _licenceDal;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserInfoService _authenticatedUserInfoService;
        public LicenceManager(ILicenceDal licenceDal, IMapper mapper, IAuthenticatedUserInfoService authenticatedUserInfoService)
        {
            _licenceDal = licenceDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        //Add new licence as an user.
        //No need authority.
        public IResult Add(LicenceAddDto licenceAddDto)
        {
            BusinessRules.Run(DoesLicenceProfileNameExist(licenceAddDto.ProfilName));
            Licence licence = _mapper.Map<Licence>(licenceAddDto);
            licence.Balance = 0;
            licence.Gb = 1;
            licence.IsApproved = false;
            licence.SmsAccountId = 1;
            licence.StartDate = DateTime.Now;
            _licenceDal.Add(licence);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //Get current auth user licence informations.
        //Need to LicenceGet authority.
        [SecuredOperation("LicenceGet")]
        public IDataResult<LicenceGetDto> GetCurrentAuthUserLicence()
        {
            var licence = _licenceDal.GetByIdWithInclude(l => l.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            if (licence == null)
                return new ErrorDataResult<LicenceGetDto>(Messages.TheItemDoesNotExists);
            LicenceGetDto licenceGetDto = _mapper.Map<LicenceGetDto>(licence);
            return new SuccessDataResult<LicenceGetDto>(licenceGetDto, Messages.GetByIdSuccessfuly);
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
            licence.Image = licenceUpdateDto.Image;
            licence.PersonTypeId = licenceUpdateDto.PersonTypeId;
            licence.PhoneNumber = licenceUpdateDto.PhoneNumber;
            licence.ProfilName = licenceUpdateDto.ProfilName;
            licence.TaxNo = licenceUpdateDto.TaxNo;
            licence.TaxOffice = licenceUpdateDto.TaxOffice;
            licence.WebSite = licenceUpdateDto.WebSite;
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
