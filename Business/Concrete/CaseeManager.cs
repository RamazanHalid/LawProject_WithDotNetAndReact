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
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CaseeManager : ICaseeService
    {
        private readonly ICaseeDal _caseeDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        public CaseeManager(ICaseeDal caseeDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _caseeDal = caseeDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseeAdd")]
        [ValidationAspect(typeof(CaseeAddDtoValidator))]
        public IResult Add(CaseeAddDto caseeAddDto)
        {
            Casee casee = _mapper.Map<Casee>(caseeAddDto);
            casee.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _caseeDal.Add(casee);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseeUpdate")]

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
        [SecuredOperation("CaseeDelete")]
        public IResult Delete(int id)
        {
            var casee = _caseeDal.Get(cs => cs.CaseeId == id);
            if (casee == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _caseeDal.Delete(casee);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseeGetAll")]
        public IDataResult<List<CaseeGetDto>> GetAll()
        {
            List<Casee> caseees = _caseeDal.GetAllWithInclude(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<CaseeGetDto> caseeDtos = _mapper.Map<List<CaseeGetDto>>(caseees);
            return new SuccessDataResult<List<CaseeGetDto>>(caseeDtos, Messages.GetAllSuccessfuly);
        }
        [SecuredOperation("CaseeGetAll")]
        public IDataResult<List<CaseeGetDto>> GetAllByCustomerId(int customerId)
        {
            List<Casee> caseees = _caseeDal.GetAllWithInclude(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId() && c.CustomerId == customerId);
            List<CaseeGetDto> caseeDtos = _mapper.Map<List<CaseeGetDto>>(caseees);
            return new SuccessDataResult<List<CaseeGetDto>>(caseeDtos, Messages.GetAllSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("CaseeGetAll")]
        public IDataResult<CaseeGetDto> GetById(int id)
        {
            var casee = _caseeDal.GetByIdWithInclude(cs => cs.CaseeId == id);
            CaseeGetDto caseeDto = _mapper.Map<CaseeGetDto>(casee);
            if (casee == null)
                return new ErrorDataResult<CaseeGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<CaseeGetDto>(caseeDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("CaseeUpdate")]
        [ValidationAspect(typeof(CaseeUpdateDtoValidator))]
        public IResult Update(CaseeUpdateDto caseeUpdateDto)
        {
            Casee casee = _mapper.Map<Casee>(caseeUpdateDto);
            casee.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _caseeDal.Update(casee);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IDataResult<int> GetCountByLicenceId(int licenceId)
        {
            var caseeCount = _caseeDal.GetCount(cs => cs.LicenceId == licenceId);
            return new SuccessDataResult<int>(caseeCount, Messages.GetByIdSuccessfuly);
        }

    }
}
