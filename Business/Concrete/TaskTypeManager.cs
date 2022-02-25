using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TaskTypeManager : ITaskTypeService
    {
        private readonly ITaskTypeDal _taskTypeDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        public TaskTypeManager(ITaskTypeDal taskTypeDal, ICurrentUserService authenticatedUserInfoService, IMapper mapper)
        {
            _taskTypeDal = taskTypeDal;
            _authenticatedUserInfoService = authenticatedUserInfoService;
            _mapper = mapper;
        }

        //Adding new item as an user
        //Authority needed
        [SecuredOperation("TaskTypeAdd")]
        public IResult Add(TaskTypeAddDto taskTypeAddDto)
        {
            TaskType taskType = _mapper.Map<TaskType>(taskTypeAddDto);
            taskType.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _taskTypeDal.Add(taskType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //Get all items as an user
        //Authority needed
        [SecuredOperation("TaskTypeGet")]
        public IDataResult<List<TaskTypeGetDto>> GetAll(int isActive)
        {
            List<TaskType> taskTypes;
            if (isActive == 0 || isActive == 1)
                taskTypes = _taskTypeDal.GetAll(tp => tp.LicenceId == _authenticatedUserInfoService.GetUserId()
                && tp.IsActive == Convert.ToBoolean(isActive));
            else
                taskTypes = _taskTypeDal.GetAll(tp => tp.LicenceId == _authenticatedUserInfoService.GetUserId());
            List<TaskTypeGetDto> taskTypeGetDtos = _mapper.Map<List<TaskTypeGetDto>>(taskTypes);
            return new SuccessDataResult<List<TaskTypeGetDto>>(taskTypeGetDtos, Messages.GetAllSuccessfuly);
        }
        //Get special item 
        //Authority needed
        [SecuredOperation("TaskTypeGet")]
        public IDataResult<TaskTypeGetDto> GetById(int id)
        {
            TaskType taskType = _taskTypeDal.Get(tp => tp.TaskTypeId == id);
            TaskTypeGetDto taskTypeGetDto = _mapper.Map<TaskTypeGetDto>(taskType);
            if (taskTypeGetDto == null)
                return new ErrorDataResult<TaskTypeGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<TaskTypeGetDto>(taskTypeGetDto, Messages.GetByIdSuccessfuly);
        }
        //Change activity special TaskType
        //Authority needed
        [SecuredOperation("TaskTypeUpdate")]
        public IResult ChangeActivity(int id)
        {
            var taskType = _taskTypeDal.Get(tp => tp.TaskTypeId == id); //Get special TaskType
            if (taskType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            taskType.IsActive = !taskType.IsActive;
            _taskTypeDal.Update(taskType);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }
        //Change activity special TaskType
        //Authority needed
        [SecuredOperation("TaskTypeDelete")]
        public IResult Delete(int id)
        {
            var taskType = _taskTypeDal.Get(tp => tp.TaskTypeId == id);
            if (taskType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _taskTypeDal.Delete(taskType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        //Update special TaskType
        //Authority needed
        [SecuredOperation("TaskTypeUpdate")]
        public IResult Update(TaskTypeUpdateDto taskTypeUpdateDto)
        {
            TaskType taskType = _mapper.Map<TaskType>(taskTypeUpdateDto);
            taskType.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _taskTypeDal.Update(taskType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
