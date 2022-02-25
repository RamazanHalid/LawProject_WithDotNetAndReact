using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CaseStatusManager : ICaseStatusService
    {
        private readonly ICaseStatusDal _caseStatusDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        public CaseStatusManager(ICaseStatusDal caseStatusDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _caseStatusDal = caseStatusDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseStatusAdd")]
        public IResult Add(CaseStatusAddDto caseStatusAddDto)
        {
            CaseStatus caseStatus = _mapper.Map<CaseStatus>(caseStatusAddDto);
            caseStatus.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _caseStatusDal.Add(caseStatus);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseStatusUpdate")]
        public IResult ChangeActivity(int id)
        {
            var caseStatus = _caseStatusDal.GetWithInclude(c => c.CaseStatusId == id);
            if (caseStatus == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            caseStatus.IsActive = !caseStatus.IsActive;
            _caseStatusDal.Update(caseStatus);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseStatusDelete")]
        public IResult Delete(int id)
        {
            var caseStatus = _caseStatusDal.Get(cs => cs.CaseStatusId == id);
            if (caseStatus == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _caseStatusDal.Delete(caseStatus);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseStatusGetAll")]
        public IDataResult<List<CaseStatusGetDto>> GetAll()
        {
            List<CaseStatus> caseStatuses = _caseStatusDal.GetAllExpressionWithInclude(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<CaseStatusGetDto> caseStatusDtos = _mapper.Map<List<CaseStatusGetDto>>(caseStatuses);
            return new SuccessDataResult<List<CaseStatusGetDto>>(caseStatusDtos, Messages.GetAllSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseStatusGetAllActive")]
        public IDataResult<List<CaseStatusGetDto>> GetAllActive()
        {
            List<CaseStatus> caseStatuses = _caseStatusDal.GetAllExpressionWithInclude(
                c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId() && c.IsActive == true);
            List<CaseStatusGetDto> caseStatusDtos = _mapper.Map<List<CaseStatusGetDto>>(caseStatuses);
            return new SuccessDataResult<List<CaseStatusGetDto>>(caseStatusDtos, Messages.GetAllSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseStatusGet")]
        public IDataResult<CaseStatusGetDto> GetById(int id)
        {
            var caseStatus = _caseStatusDal.GetWithInclude(cs => cs.CaseStatusId == id);
            CaseStatusGetDto caseStatusDto = _mapper.Map<CaseStatusGetDto>(caseStatus);
            if (caseStatus == null)
                return new ErrorDataResult<CaseStatusGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<CaseStatusGetDto>(caseStatusDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("CaseStatusUpdate")]
        public IResult Update(CaseStatusUpdateDto caseStatusUpdateDto)
        {
            CaseStatus caseStatus = _mapper.Map<CaseStatus>(caseStatusUpdateDto);
            caseStatus.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _caseStatusDal.Update(caseStatus);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
