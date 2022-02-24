using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
namespace Business.Concrete
{
    public class CaseTypeManager : ICaseTypeService
    {
        private readonly ICaseTypeDal _caseTypeDal;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int authUserLicenceId;
        public CaseTypeManager(ICaseTypeDal caseTypeDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _caseTypeDal = caseTypeDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                authUserLicenceId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GroupSid).Value);
        }
        [SecuredOperation("CaseTypeGet")]
        public IDataResult<List<CaseTypeDto>> GetAll(int courtOfficeTypeId, int isActive)
        {
            List<CaseType> caseTypes = _caseTypeDal.GetAllFilter(courtOfficeTypeId, isActive);
            List<CaseTypeDto> caseTypeDto = _mapper.Map<List<CaseTypeDto>>(caseTypes);
            return new SuccessDataResult<List<CaseTypeDto>>(caseTypeDto, Messages.GetAllSuccessfuly);
        }
        [SecuredOperation("CaseTypeGet")]
        public IDataResult<CaseTypeDto> GetById(int id)
        {
            CaseType caseType = _caseTypeDal.GetByIdWithCourtOfficeType(ct => ct.CaseTypeId == id);
            if (caseType == null)
                return new ErrorDataResult<CaseTypeDto>(Messages.TheItemDoesNotExists);
            CaseTypeDto caseTypeDto = _mapper.Map<CaseTypeDto>(caseType);
            return new SuccessDataResult<CaseTypeDto>(caseTypeDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("CaseTypeAdd")]
        public IResult Add(CaseTypeDto caseTypeDto)
        {
            CaseType caseType = _mapper.Map<CaseType>(caseTypeDto);
            caseType.LicenceId = authUserLicenceId;
            _caseTypeDal.Add(caseType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }


        [SecuredOperation("CaseTypeUpdate")]
        public IResult ChangeActivity(int id)
        {
            var caseType = _caseTypeDal.Get(ct => ct.CaseTypeId == id);
            caseType.IsActive = !caseType.IsActive;
            CaseTypeDto caseTypeDto = _mapper.Map<CaseTypeDto>(caseType);
            var result = Update(caseTypeDto);
            if (!result.Success)
                return new ErrorResult(result.Message);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }
        [SecuredOperation("CaseTypeDelete")]
        public IResult Delete(int id)
        {
            var caseType = _caseTypeDal.Get(ct => ct.CaseTypeId == id);
            if (caseType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _caseTypeDal.Delete(caseType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        [SecuredOperation("CaseTypeUpdate")]
        public IResult Update(CaseTypeDto caseTypeDto)
        {
            CaseType caseType = _mapper.Map<CaseType>(caseTypeDto);
            _caseTypeDal.Update(caseType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
