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
    public class CaseStatusManager : ICaseStatusService
    {
        private readonly ICaseStatusDal _caseStatusDal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly int _authUserlicenceId;
        public CaseStatusManager(ICaseStatusDal caseStatusDal, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _caseStatusDal = caseStatusDal;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                _authUserlicenceId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GroupSid).Value);
            }
        }
        [SecuredOperation("case_status_CUD")]
        public IResult Add(CaseStatusDto caseStatusDto)
        {
            CaseStatus caseStatus = _mapper.Map<CaseStatus>(caseStatusDto);
            caseStatus.LicenceId = _authUserlicenceId;
            _caseStatusDal.Add(caseStatus);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        [SecuredOperation("case_status_R")]
        public IResult ChangeActivity(int id)
        {
            var caseStatus = GetById(id);
            if (!caseStatus.Success)
                return caseStatus;
            caseStatus.Data.IsActive = !caseStatus.Data.IsActive;
            var result = Update(caseStatus.Data);
            if (!result.Success)
                return result;
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }
        [SecuredOperation("case_status_CUD,admin")]
        public IResult Delete(int id)
        {
            var caseStatus = _caseStatusDal.Get(cs => cs.CaseStatusId == id);
            if (caseStatus == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _caseStatusDal.Delete(caseStatus);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        [SecuredOperation("case_status_R")]
        public IDataResult<List<CaseStatusDto>> GetAllByLicenceIdAndActivity(int isActive)
        {
            List<CaseStatus> caseStatuses;
            if (isActive == 0)
                caseStatuses = _caseStatusDal.GetAllWithCourtOfficeType(cs => cs.LicenceId == _authUserlicenceId && cs.IsActive == false);
            else if (isActive == 1)
                caseStatuses = _caseStatusDal.GetAllWithCourtOfficeType(cs => cs.LicenceId == _authUserlicenceId && cs.IsActive == true);
            else
                caseStatuses = _caseStatusDal.GetAllWithCourtOfficeType(cs => cs.LicenceId == _authUserlicenceId);
            List<CaseStatusDto> caseStatusDtos = _mapper.Map<List<CaseStatusDto>>(caseStatuses);
            return new SuccessDataResult<List<CaseStatusDto>>(caseStatusDtos, Messages.GetAllSuccessfuly);
        }
        [SecuredOperation("case_status_R,admin")]
        public IDataResult<CaseStatusDto> GetById(int id)
        {
            var caseStatus = _caseStatusDal.GetByIdWithCourtOfficeType(cs => cs.CaseStatusId == id);
            CaseStatusDto caseStatusDto = _mapper.Map<CaseStatusDto>(caseStatus);

            if (caseStatus == null)
                return new ErrorDataResult<CaseStatusDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<CaseStatusDto>(caseStatusDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("case_status_R")]
        public IResult Update(CaseStatusDto caseStatusDto)
        {
            CaseStatus caseStatus = _mapper.Map<CaseStatus>(caseStatusDto);
            caseStatus.LicenceId = _authUserlicenceId;
            _caseStatusDal.Update(caseStatus);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
