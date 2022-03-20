using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.TaskStatusDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TaskStatusManager : ITaskStatusService
    {
        private readonly ITaskStatusDal _taskStatusDal;
        private readonly IMapper _mapper;
        public TaskStatusManager(ITaskStatusDal taskStatusDal, IMapper mapper)
        {
            _taskStatusDal = taskStatusDal;
            _mapper = mapper;
        }

        //Adding new item as an user
        //Authority needed
        //[SecuredOperation("TaskStatusAdd")]
        public IResult Add(TaskStatusAddDto taskStatusAddDto)
        {
            TaskStatus taskStatus = _mapper.Map<TaskStatus>(taskStatusAddDto);
            _taskStatusDal.Add(taskStatus);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //Get all items as an user
        //Authority needed
        //[SecuredOperation("TaskStatusGetAll")]
        public IDataResult<List<TaskStatusGetDto>> GetAll()
        {
            List<TaskStatus> taskStatuss = _taskStatusDal.GetAll();
            List<TaskStatusGetDto> taskStatusGetDtos = _mapper.Map<List<TaskStatusGetDto>>(taskStatuss);
            return new SuccessDataResult<List<TaskStatusGetDto>>(taskStatusGetDtos, Messages.GetAllSuccessfuly);
        }

        //Get special item 
        //Authority needed
        //[SecuredOperation("TaskStatusGetAll")]
        public IDataResult<TaskStatusGetDto> GetById(int id)
        {
            TaskStatus taskStatus = _taskStatusDal.Get(tp => tp.TaskStatusId == id);
            TaskStatusGetDto taskStatusGetDto = _mapper.Map<TaskStatusGetDto>(taskStatus);
            if (taskStatusGetDto == null)
                return new ErrorDataResult<TaskStatusGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<TaskStatusGetDto>(taskStatusGetDto, Messages.GetByIdSuccessfuly);
        }

        //Change activity special TaskStatus
        //Authority needed
        //[SecuredOperation("TaskStatusDelete")]
        public IResult Delete(int id)
        {
            var taskStatus = _taskStatusDal.Get(tp => tp.TaskStatusId == id);
            if (taskStatus == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _taskStatusDal.Delete(taskStatus);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        //Update special TaskStatus
        //Authority needed
        //[SecuredOperation("TaskStatusUpdate")]
        public IResult Update(TaskStatusUpdateDto taskStatusUpdateDto)
        {
            TaskStatus taskStatus = _mapper.Map<TaskStatus>(taskStatusUpdateDto);
            _taskStatusDal.Update(taskStatus);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
