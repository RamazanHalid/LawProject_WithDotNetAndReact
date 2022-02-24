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
using System.Text;

namespace Business.Concrete
{
    public class ProcessTypeManager : IProcessTypeService
    {
        private readonly IProcessTypeDal _processTypeDal;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserInfoService _authenticatedUserInfoService;
        public ProcessTypeManager(IProcessTypeDal processTypeDal, IMapper mapper, IAuthenticatedUserInfoService authenticatedUserInfoService)
        {
            _processTypeDal = processTypeDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        //Adding new item as an User
        //Authority needed
        [SecuredOperation("ProcessTypeAdd")]
        public IResult Add(ProcessTypeDto processTypeDto)
        {
            ProcessType processType = _mapper.Map<ProcessType>(processTypeDto);
            processType.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _processTypeDal.Add(processType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        //GetAll items as an User
        //Authority needed
        [SecuredOperation("ProcessTypeGet")]
        public IDataResult<List<ProcessTypeDto>> GetAll(int isActive)
        {
            List<ProcessType> processTypes;
            if (isActive == 0 || isActive == 1)
                processTypes = _processTypeDal.GetAll(p => p.LicenceId == _authenticatedUserInfoService.GetLicenceId()
                && p.IsActive == Convert.ToBoolean(isActive));
            else
                processTypes = _processTypeDal.GetAll(p => p.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<ProcessTypeDto> processTypeDtos = _mapper.Map<List<ProcessTypeDto>>(processTypes);
            return new SuccessDataResult<List<ProcessTypeDto>>(processTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        //Get special item
        //Authority needed
        [SecuredOperation("ProcessTypeGet")]
        public IDataResult<ProcessTypeDto> GetById(int id)
        {
            ProcessType processType = _processTypeDal.Get(pt => pt.ProcessTypeId == id);
            ProcessTypeDto processTypeDto = _mapper.Map<ProcessTypeDto>(processType);
            return new SuccessDataResult<ProcessTypeDto>(processTypeDto, Messages.GetByIdSuccessfuly);
        }
        //Change activity special item
        //Authority needed
        [SecuredOperation("ProcessTypeUpdate")]
        public IResult ChangeActivity(int id)
        {
            var processType = GetById(id);
            if (!processType.Success)
                return new ErrorResult(processType.Message);
            processType.Data.IsActive = !processType.Data.IsActive;
            var result = Update(processType.Data);
            if (!result.Success)
                return result;
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
        public IResult Update(ProcessTypeDto processTypeDto)
        {
            ProcessType processType = _mapper.Map<ProcessType>(processTypeDto);
            processType.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _processTypeDal.Update(processType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
