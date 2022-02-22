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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly int _authUserLicenceId;
        public ProcessTypeManager(IProcessTypeDal processTypeDal, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _processTypeDal = processTypeDal;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                _authUserLicenceId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GroupSid).Value);
        }
        [SecuredOperation("process_type_CUD")]
        public IResult Add(ProcessTypeDto processTypeDto)
        {
            ProcessType processType = _mapper.Map<ProcessType>(processTypeDto);
            processType.LicenceId = _authUserLicenceId;
            _processTypeDal.Add(processType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        [SecuredOperation("process_type_R")]
        public IDataResult<List<ProcessTypeDto>> GetAllByLicenceIdAndActivity(int isActive)
        {
            List<ProcessType> processTypes;
            if (isActive == 0)
                processTypes = _processTypeDal.GetAll(p => p.LicenceId == _authUserLicenceId && p.IsActive == false);
            else if (isActive == 0)
                processTypes = _processTypeDal.GetAll(p => p.LicenceId == _authUserLicenceId && p.IsActive == true);
            else
                processTypes = _processTypeDal.GetAll(p => p.LicenceId == _authUserLicenceId);
            List<ProcessTypeDto> processTypeDtos = _mapper.Map<List<ProcessTypeDto>>(processTypes);
            return new SuccessDataResult<List<ProcessTypeDto>>(processTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        [SecuredOperation("process_type_R")]
        public IDataResult<ProcessTypeDto> GetById(int id)
        {
            ProcessType processType = _processTypeDal.Get(pt => pt.ProcessTypeId == id);
            ProcessTypeDto processTypeDto = _mapper.Map<ProcessTypeDto>(processType);
            return new SuccessDataResult<ProcessTypeDto>(processTypeDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("process_type_CUD")]
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
        [SecuredOperation("process_type_CUD")]
        public IResult Delete(int id)
        {
            var processType = _processTypeDal.Get(pt => pt.ProcessTypeId == id);
            _processTypeDal.Delete(processType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
    
        [SecuredOperation("process_type_CUD")]
        public IResult Update(ProcessTypeDto processTypeDto)
        {
            ProcessType processType = _mapper.Map<ProcessType>(processTypeDto);
            _processTypeDal.Update(processType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
