using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.EventtDtos;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class EventtManager : IEventtService
    {
        private readonly IEventtDal _eventtDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        public EventtManager(IEventtDal eventtDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _eventtDal = eventtDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,EventtAdd")]
        [ValidationAspect(typeof(EventtAddDtoValidator))]
        public IResult Add(EventtAddDto eventtAddDto)
        {
            Eventt eventt = _mapper.Map<Eventt>(eventtAddDto);
            eventt.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            eventt.CreatorId = _authenticatedUserInfoService.GetUserId();
            _eventtDal.Add(eventt);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,EventtUpdate")]
        public IResult ChangeActivity(int id)
        {
            var eventt = _eventtDal.Get(c => c.EventtId == id);
            if (eventt == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            eventt.IsActive = !eventt.IsActive;
            _eventtDal.Update(eventt);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,EventtDelete")]
        public IResult Delete(int id)
        {
            var eventt = _eventtDal.Get(cs => cs.EventtId == id);
            if (eventt == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _eventtDal.Delete(eventt);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,EventtGetAll")]
        public IDataResult<List<EventtGetDto>> GetAll()
        {
            List<Eventt> eventtes = _eventtDal.GetAllWithInclude(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<EventtGetDto> eventtDtos = _mapper.Map<List<EventtGetDto>>(eventtes);
            return new SuccessDataResult<List<EventtGetDto>>(eventtDtos, Messages.GetAllSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,EventtGetAll")]
        public IDataResult<List<EventtGetDto>> GetAllLastEventsByNumber(int number)
        {
            List<Eventt> eventtes = _eventtDal.GetAllWithIncludeLastEventsByNumber(number,c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<EventtGetDto> eventtDtos = _mapper.Map<List<EventtGetDto>>(eventtes);
            return new SuccessDataResult<List<EventtGetDto>>(eventtDtos, Messages.GetAllSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,EventtGetAllActive")]
        public IDataResult<List<EventtGetDto>> GetAllActive()
        {
            List<Eventt> eventtes = _eventtDal.GetAllWithInclude(
                c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId() && c.IsActive == true);
            List<EventtGetDto> eventtDtos = _mapper.Map<List<EventtGetDto>>(eventtes);
            return new SuccessDataResult<List<EventtGetDto>>(eventtDtos, Messages.GetAllSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,EventtGetAll")]
        public IDataResult<EventtGetDto> GetById(int id)
        {
            var eventt = _eventtDal.GetByIdWithInclude(cs => cs.EventtId == id);
            EventtGetDto eventtDto = _mapper.Map<EventtGetDto>(eventt);
            if (eventt == null)
                return new ErrorDataResult<EventtGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<EventtGetDto>(eventtDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("LicenceOwner,EventtUpdate")]
        [ValidationAspect(typeof(EventtUpdateDtoValidator))]
        public IResult Update(EventtUpdateDto eventtUpdateDto)
        {
            Eventt eventt = _eventtDal.Get(e => e.EventtId == eventtUpdateDto.EventtId);
            if (eventt == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            eventt.CaseeId = eventtUpdateDto.CaseeId;
            eventt.EndDate = eventtUpdateDto.EndDate;
            eventt.StartDate = eventtUpdateDto.StartDate;
            eventt.UserId = eventtUpdateDto.UserId;
            eventt.IsActive = eventtUpdateDto.IsActive;
            eventt.Info = eventtUpdateDto.Info;
            eventt.EventTypeId = eventtUpdateDto.EventTypeId;
            eventt.CustomerId = eventtUpdateDto.CustomerId;
            _eventtDal.Update(eventt);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
