using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CourtOfficeDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CourtOfficeManager : ICourtOfficeService
    {
        private readonly ICourtOfficeDal _courtOfficeDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CourtOfficeManager(ICourtOfficeDal courtOfficeDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _courtOfficeDal = courtOfficeDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        [ValidationAspect(typeof(CourtOfficeAddDtoValidator))]
        public IResult Add(CourtOfficeAddDto courtOfficeAddDto)
        {
            CourtOffice courtOffice = _mapper.Map<CourtOffice>(courtOfficeAddDto);
            courtOffice.LicenceId = _currentUserService.GetLicenceId();
            _courtOfficeDal.Add(courtOffice);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            CourtOffice courtOffice = _courtOfficeDal.Get(c => c.CourtOfficeId == id);
            if (courtOffice == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _courtOfficeDal.Delete(courtOffice);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<CourtOfficeGetDto>> GetAll()
        {
            List<CourtOffice> courtOffices = _courtOfficeDal.GetAllWithInclude(c => c.LicenceId == _currentUserService.GetLicenceId());
            List<CourtOfficeGetDto> courtOfficeGetDtos = _mapper.Map<List<CourtOfficeGetDto>>(courtOffices);
            return new SuccessDataResult<List<CourtOfficeGetDto>>(courtOfficeGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<List<CourtOfficeGetDto>> GetAllActive()
        {
            List<CourtOffice> courtOffices = _courtOfficeDal.GetAllWithInclude(c => c.LicenceId == _currentUserService.GetLicenceId() && c.IsActive == true);
            List<CourtOfficeGetDto> courtOfficeGetDtos = _mapper.Map<List<CourtOfficeGetDto>>(courtOffices);
            return new SuccessDataResult<List<CourtOfficeGetDto>>(courtOfficeGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<CourtOfficeGetDto> GetById(int id)
        {
            CourtOffice courtOffice = _courtOfficeDal.GetWithInclude(c => c.CourtOfficeId == id);
            CourtOfficeGetDto courtOfficeGetDto = _mapper.Map<CourtOfficeGetDto>(courtOffice);
            return new SuccessDataResult<CourtOfficeGetDto>(courtOfficeGetDto, Messages.GetByIdSuccessfuly);
        }
        [ValidationAspect(typeof(CourtOfficeUpdateDtoValidator))]
        public IResult Update(CourtOfficeUpdateDto courtOfficeUpdateDto)
        {
            CourtOffice courtOffice = _mapper.Map<CourtOffice>(courtOfficeUpdateDto);
            courtOffice.LicenceId = _currentUserService.GetLicenceId();
            _courtOfficeDal.Update(courtOffice);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult ChangeActivity(int id)
        {
            CourtOffice courtOffice = _courtOfficeDal.Get(c => c.CourtOfficeId == id);
            if (courtOffice == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            courtOffice.IsActive = !courtOffice.IsActive;
            _courtOfficeDal.Update(courtOffice);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
