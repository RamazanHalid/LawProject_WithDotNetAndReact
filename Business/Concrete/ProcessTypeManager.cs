using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProcessTypeDtos;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class ProcessTypeManager : IProcessTypeService
    {
        private readonly IProcessTypeDal _processTypeDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        public ProcessTypeManager(IProcessTypeDal processTypeDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _processTypeDal = processTypeDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        //Adding new item as an User
        //Authority needed
        [SecuredOperation("ProcessTypeAdd")]
        public IResult Add(ProcessTypeAddDto processTypeAddDto)
        {
            ProcessType processType = _mapper.Map<ProcessType>(processTypeAddDto);
            processType.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _processTypeDal.Add(processType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        //GetAll items as an User
        //Authority needed
        [SecuredOperation("ProcessTypeGetAll")]
        public IDataResult<List<ProcessTypeGetDto>> GetAll()
        {
            List<ProcessType> processTypes = _processTypeDal.GetAll(p => p.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<ProcessTypeGetDto> processTypeDtos = _mapper.Map<List<ProcessTypeGetDto>>(processTypes);
            return new SuccessDataResult<List<ProcessTypeGetDto>>(processTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        //GetAll items as an User
        //Authority needed
        [SecuredOperation("ProcessTypeGetAllActive")]
        public IDataResult<List<ProcessTypeGetDto>> GetAllActive()
        {
            List<ProcessType> processTypes = _processTypeDal.GetAll(p => p.LicenceId == _authenticatedUserInfoService.GetLicenceId() && p.IsActive == true);
            List<ProcessTypeGetDto> processTypeDtos = _mapper.Map<List<ProcessTypeGetDto>>(processTypes);
            return new SuccessDataResult<List<ProcessTypeGetDto>>(processTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        //Get special item
        //Authority needed
        [SecuredOperation("ProcessTypeGetAll")]
        public IDataResult<ProcessTypeGetDto> GetById(int id)
        {
            ProcessType processType = _processTypeDal.Get(pt => pt.ProcessTypeId == id);
            ProcessTypeGetDto processTypeDto = _mapper.Map<ProcessTypeGetDto>(processType);
            return new SuccessDataResult<ProcessTypeGetDto>(processTypeDto, Messages.GetByIdSuccessfuly);
        }
        //Change activity special item
        //Authority needed
        [SecuredOperation("ProcessTypeUpdate")]
        public IResult ChangeActivity(int id)
        {
            var processType = _processTypeDal.Get(p => p.ProcessTypeId == id);
            if (processType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            processType.IsActive = !processType.IsActive;
            _processTypeDal.Update(processType);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }

        //Delete special item
        //Authority needed
        [SecuredOperation("ProcessTypeDelete")]
        public IResult Delete(int id)
        {
            var processType = _processTypeDal.Get(pt => pt.ProcessTypeId == id);
            _processTypeDal.Delete(processType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        //Update special item
        //Authority needed
        [SecuredOperation("ProcessTypeUpdate")]
        public IResult Update(ProcessTypeUpdateDto processTypeDto)
        {
            ProcessType processType = _mapper.Map<ProcessType>(processTypeDto);
            processType.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _processTypeDal.Update(processType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
