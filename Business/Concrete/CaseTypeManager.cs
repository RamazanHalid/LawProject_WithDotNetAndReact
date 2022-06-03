using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CaseTypeDtos;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CaseTypeManager : ICaseTypeService
    {
        private readonly ICaseTypeDal _caseTypeDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfoService;
        public CaseTypeManager(ICaseTypeDal caseTypeDal, IMapper mapper, ICurrentUserService currentUserInfoService)
        {
            _caseTypeDal = caseTypeDal;
            _mapper = mapper;
            _currentUserInfoService = currentUserInfoService;
        }
        //Get all Case Types as an user
        //Authority needed
        [SecuredOperation("LicenceOwner,CaseTypeGetAll")]
        public IDataResult<List<CaseTypeGetDto>> GetAll()
        {
            List<CaseType> caseTypes = _caseTypeDal.GetAllWithInclude(c => c.LicenceId == _currentUserInfoService.GetLicenceId());
            List<CaseTypeGetDto> caseTypeGetDto = _mapper.Map<List<CaseTypeGetDto>>(caseTypes);
            return new SuccessDataResult<List<CaseTypeGetDto>>(caseTypeGetDto, Messages.GetAllSuccessfuly);
        }
        //Add Case Type as an user
        //Authority needed
        [SecuredOperation("LicenceOwner,CaseTypeAdd")]
        [ValidationAspect(typeof(CaseTypeAddDtoValidator))]

        public IResult Add(CaseTypeAddDto caseTypeAddDto)
        {
            CaseType caseType = _mapper.Map<CaseType>(caseTypeAddDto);
            caseType.LicenceId = _currentUserInfoService.GetLicenceId();
            _caseTypeDal.Add(caseType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        //Get all Active Case Types as an user
        //Authority needed
        [SecuredOperation("LicenceOwner,CaseTypeGetAllActive")]
        public IDataResult<List<CaseTypeGetDto>> GetAllActive()
        {
            List<CaseType> caseTypes = _caseTypeDal.GetAllWithInclude(c => c.LicenceId == _currentUserInfoService.GetLicenceId() && c.IsActive == true);
            List<CaseTypeGetDto> caseTypeGetDto = _mapper.Map<List<CaseTypeGetDto>>(caseTypes);
            return new SuccessDataResult<List<CaseTypeGetDto>>(caseTypeGetDto, Messages.GetAllSuccessfuly);
        }
        //Get Case Type
        //Authority needed
        [SecuredOperation("LicenceOwner,CaseTypeGetAll")]
        public IDataResult<CaseTypeGetDto> GetById(int id)
        {
            CaseType caseType = _caseTypeDal.GetByIdWithInclude(ct => ct.CaseTypeId == id);
            if (caseType == null)
                return new ErrorDataResult<CaseTypeGetDto>(Messages.TheItemDoesNotExists);
            CaseTypeGetDto caseTypeGetDto = _mapper.Map<CaseTypeGetDto>(caseType);
            return new SuccessDataResult<CaseTypeGetDto>(caseTypeGetDto, Messages.GetByIdSuccessfuly);
        }
        //Change activity Case Type as an user
        //Authority needed
        [SecuredOperation("LicenceOwner,CaseTypeUpdate")]
        public IResult ChangeActivity(int id)
        {
            var caseType = _caseTypeDal.Get(ct => ct.CaseTypeId == id);
            caseType.IsActive = !caseType.IsActive;
            _caseTypeDal.Update(caseType);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }
        //Delete Case Type 
        //Authority needed
        [SecuredOperation("LicenceOwner,CaseTypeDelete")]
        public IResult Delete(int id)
        {
            var caseType = _caseTypeDal.Get(ct => ct.CaseTypeId == id);
            if (caseType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _caseTypeDal.Delete(caseType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        //Update Case Type as an user
        //Authority needed
        [SecuredOperation("LicenceOwner,CaseTypeUpdate")]
        [ValidationAspect(typeof(CaseTypeUpdateDtoValidator))]
        public IResult Update(CaseTypeUpdateDto caseTypeUpdateDto)
        {
            CaseType caseType = _mapper.Map<CaseType>(caseTypeUpdateDto);
            caseType.LicenceId = _currentUserInfoService.GetLicenceId();
            _caseTypeDal.Update(caseType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
