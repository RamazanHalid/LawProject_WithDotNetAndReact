using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CaseeDtos;
using Entities.DTOs.CaseIngonereUserDtos;
using System;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CaseeManager : ICaseeService
    {
        private readonly ICaseeDal _caseeDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        private readonly ICaseIgnoreUserService _caseIgnoreUserService;
        private readonly ICasesUpdateHistoryService _casesUpdateHistoryService;
        private readonly INotificationService _notificationService;
        public CaseeManager(ICaseeDal caseeDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService, ICaseIgnoreUserService caseIgnoreUserService, ICasesUpdateHistoryService casesUpdateHistoryService, INotificationService notificationService)
        {
            _caseeDal = caseeDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
            _caseIgnoreUserService = caseIgnoreUserService;
            _casesUpdateHistoryService = casesUpdateHistoryService;
            _notificationService = notificationService;
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CaseeAdd")]
        [ValidationAspect(typeof(CaseeAddDtoValidator))]
        public IResult Add(CaseeAddDto caseeAddDto)
        {
            Casee casee = _mapper.Map<Casee>(caseeAddDto);
            casee.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            var newCasee = _caseeDal.AddWithReturn(casee);
            List<CaseIgnoreUserAddDto> caseIgnoreUserAddDtos = new List<CaseIgnoreUserAddDto>();
            for (int i = 0; i < caseeAddDto.CaseIgnoreUserIds.Count; i++)
            {
                caseIgnoreUserAddDtos.Add(new CaseIgnoreUserAddDto
                {
                    CaseeId = newCasee.CaseeId,
                    UserId = caseeAddDto.CaseIgnoreUserIds[i]
                });
            }
            _caseIgnoreUserService.AddWithRange(caseIgnoreUserAddDtos);
            _casesUpdateHistoryService.Add(new CasesUpdateHistory
            {
                ByWhichUserId = _authenticatedUserInfoService.GetUserId(),
                CaseeId = newCasee.CaseeId,
                CaseNo = newCasee.CaseNo,
                CaseStatusId = newCasee.CaseStatusId,
                CaseTypeId = newCasee.CaseTypeId,
                ChangeDate = newCasee.StartDate,
                StartDate = newCasee.StartDate,
                CourtOfficeId = newCasee.CourtOfficeId,
                CourtOfficeTypeId = newCasee.CourtOfficeTypeId,
                CustomerId = newCasee.CustomerId,
                IsEnd = newCasee.IsEnd,
                RoleTypeId = newCasee.RoleTypeId,
                EndDate = newCasee.EndDate,
                LicenceId = newCasee.LicenceId,
                Info = newCasee.Info,
                HasItBeenDecide = newCasee.HasItBeenDecide,
                DecisionDate = newCasee.DecisionDate,
            });
            _notificationService.Add(new Notification
            {
                Content = newCasee.Info,
                Date = DateTime.Now,
                IsRead = false,
                LicenceId = _authenticatedUserInfoService.GetLicenceId(),
                Title = "New Case added",
                UserId = _authenticatedUserInfoService.GetUserId()
            });
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CaseeUpdate")]

        public IResult ChangeStatus(int id, int caseStatusId)
        {
            var casee = _caseeDal.Get(c => c.CaseeId == id);
            if (casee == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            casee.CaseStatusId = caseStatusId;
            _caseeDal.Update(casee);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CaseeDelete")]
        public IResult Delete(int id)
        {
            var casee = _caseeDal.Get(cs => cs.CaseeId == id);
            if (casee == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _caseeDal.Delete(casee);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CaseeGetAll")]
        public IDataResult<List<CaseeGetDto>> GetAll()
        {
            var ignoreUsers = _caseIgnoreUserService.GetAllCaseIdsByUserId(_authenticatedUserInfoService.GetUserId());
            if (!ignoreUsers.Success)
                return new ErrorDataResult<List<CaseeGetDto>>(Messages.TheItemDoesNotExists);
            List<Casee> caseees = _caseeDal.GetAllWithInclude(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId()
               && !ignoreUsers.Data.Contains(c.CaseeId));
            List<CaseeGetDto> caseeDtos = _mapper.Map<List<CaseeGetDto>>(caseees);
            return new SuccessDataResult<List<CaseeGetDto>>(caseeDtos, Messages.GetAllSuccessfuly);

        }
           //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CaseeGetAll,CustomerGetAll,TaskGetAll,EventtGetAll,EventtGetAll,CaseeGetAll")]
        public IDataResult<List<CaseeGetForDropDownDto>> CaseeGetForDropDown()
        {
            var ignoreUsers = _caseIgnoreUserService.GetAllCaseIdsByUserId(_authenticatedUserInfoService.GetUserId());
            if (!ignoreUsers.Success)
                return new ErrorDataResult<List<CaseeGetForDropDownDto>>(Messages.TheItemDoesNotExists);
            List<Casee> caseees = _caseeDal.GetAllWithInclude(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId()
               && !ignoreUsers.Data.Contains(c.CaseeId));
            List<CaseeGetForDropDownDto> caseeDtos = _mapper.Map<List<CaseeGetForDropDownDto>>(caseees);
            return new SuccessDataResult<List<CaseeGetForDropDownDto>>(caseeDtos, Messages.GetAllSuccessfuly);
        }
        [SecuredOperation("LicenceOwner,CaseeGetAll")]
        public IDataResult<List<CaseeGetDto>> GetAllByCustomerId(int customerId)
        {
            List<Casee> caseees = _caseeDal.GetAllWithInclude(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId() && c.CustomerId == customerId);
            List<CaseeGetDto> caseeDtos = _mapper.Map<List<CaseeGetDto>>(caseees);
            return new SuccessDataResult<List<CaseeGetDto>>(caseeDtos, Messages.GetAllSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CaseeGetAll")]
        public IDataResult<CaseeGetDto> GetById(int id)
        {
            var casee = _caseeDal.GetByIdWithInclude(cs => cs.CaseeId == id);
            CaseeGetDto caseeDto = _mapper.Map<CaseeGetDto>(casee);
            if (casee == null)
                return new ErrorDataResult<CaseeGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<CaseeGetDto>(caseeDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("LicenceOwner,CaseeUpdate")]
        [ValidationAspect(typeof(CaseeUpdateDtoValidator))]
        public IResult Update(CaseeUpdateDto caseeUpdateDto)
        {
            Casee casee = _mapper.Map<Casee>(caseeUpdateDto);
            casee.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            var re = ComperingCasesProerties(caseeUpdateDto);
            re.CaseeId = caseeUpdateDto.CaseeId;
            _casesUpdateHistoryService.Add(re);
            _caseeDal.Update(casee);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public CasesUpdateHistory ComperingCasesProerties(CaseeUpdateDto caseeUpdateDto)
        {
            Casee forComparing = _caseeDal.Get(w => w.CaseeId == caseeUpdateDto.CaseeId);
            CasesUpdateHistory casesUpdateHistory = _mapper.Map<CasesUpdateHistory>(caseeUpdateDto);

            if (forComparing.CaseNo != caseeUpdateDto.CaseNo)
                casesUpdateHistory.DoesCaseNoChange = true;
            if (forComparing.CaseStatusId != caseeUpdateDto.CaseStatusId)
                casesUpdateHistory.DoesCaseStatusChange = true;
            if (forComparing.CaseTypeId != caseeUpdateDto.CaseTypeId)
                casesUpdateHistory.DoesCaseTypeChange = true;
            if (forComparing.CourtOfficeId != caseeUpdateDto.CourtOfficeId)
                casesUpdateHistory.DoesCourtOfficeChange = true;
            if (forComparing.CourtOfficeTypeId != caseeUpdateDto.CourtOfficeTypeId)
                casesUpdateHistory.DoesCourtOfficeTypeChange = true;
            if (forComparing.CustomerId != caseeUpdateDto.CustomerId)
                casesUpdateHistory.DoesCustomerChange = true;
            if (forComparing.DecisionDate != caseeUpdateDto.DecisionDate)
                casesUpdateHistory.DoesItDecisionDateChange = true;
            if (forComparing.EndDate != caseeUpdateDto.EndDate)
                casesUpdateHistory.DoesItEndDateChange = true;
            if (forComparing.StartDate != caseeUpdateDto.StartDate)
                casesUpdateHistory.DoesItStartDateChange = true;
            if (forComparing.IsEnd != caseeUpdateDto.IsEnd)
                casesUpdateHistory.DoesItEndChange = true;
            if (forComparing.Info != caseeUpdateDto.Info)
                casesUpdateHistory.DoesInfoChange = true;
            if (forComparing.RoleTypeId != caseeUpdateDto.RoleTypeId)
                casesUpdateHistory.DoesRoleTypeChange = true;
            if (forComparing.HasItBeenDecide != caseeUpdateDto.HasItBeenDecide)
                casesUpdateHistory.DoesItHasBeenDecideChange = true;

            casesUpdateHistory.ChangeDate = DateTime.Now;
            casesUpdateHistory.ByWhichUserId = _authenticatedUserInfoService.GetUserId();
            casesUpdateHistory.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            return casesUpdateHistory;
        }
        public IDataResult<int> GetCountByLicenceId(int licenceId)
        {
            var caseeCount = _caseeDal.GetCount(cs => cs.LicenceId == licenceId);
            return new SuccessDataResult<int>(caseeCount, Messages.GetByIdSuccessfuly);
        }

        public IDataResult<bool> CheckThisCaseBlognsToThisLicence(int id)
        {
            var result = _caseeDal.DoesItExist(c => c.CaseeId == id && c.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            if (result)
            {
                return new SuccessDataResult<bool>(true, Messages.TheItemExists);
            }
            return new ErrorDataResult<bool>(false, Messages.TheItemDoesNotExists);

        }
    }
}
