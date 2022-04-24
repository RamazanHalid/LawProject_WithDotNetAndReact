using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.TaskkDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TaskkManager : ITaskkService
    {
        private readonly ITaskkDal _taskkDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITaskStatusService _taskStatusService;
        public TaskkManager(ITaskkDal taskkDal, IMapper mapper, ICurrentUserService currentUserService, ITaskStatusService taskStatusService)
        {
            _taskkDal = taskkDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _taskStatusService = taskStatusService;
        }

        public IResult Add(TaskkAddDto taskkAddDto)
        {
            Taskk taskk = _mapper.Map<Taskk>(taskkAddDto);
            taskk.LicenceId = _currentUserService.GetLicenceId();
            taskk.CreatorId = _currentUserService.GetUserId();
            _taskkDal.Add(taskk);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            Taskk taskk = _taskkDal.Get(c => c.TaskkId == id);
            if (taskk == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _taskkDal.Delete(taskk);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<TaskkGetDto>> GetAll()
        {
            List<Taskk> taskks = _taskkDal.GetAllWithInclude(c => c.LicenceId == _currentUserService.GetLicenceId());
            List<TaskkGetDto> taskkGetDtos = _mapper.Map<List<TaskkGetDto>>(taskks);
            return new SuccessDataResult<List<TaskkGetDto>>(taskkGetDtos, Messages.GetAllSuccessfuly);
        }

        public IDataResult<TaskkGetDto> GetById(int id)
        {
            Taskk taskk = _taskkDal.GetByIdWithInclude(c => c.TaskkId == id);
            TaskkGetDto taskkGetDto = _mapper.Map<TaskkGetDto>(taskk);
            return new SuccessDataResult<TaskkGetDto>(taskkGetDto, Messages.GetByIdSuccessfuly);
        }

        public IResult ChangeActivity(int id)
        {
            Taskk taskk = _taskkDal.Get(c => c.TaskkId == id);
            taskk.IsActive = !taskk.IsActive;
            _taskkDal.Update(taskk);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult ChangeStatus(int id, int statusId)
        {
            Taskk taskk = _taskkDal.Get(c => c.TaskkId == id);
            taskk.TaskStatusId = statusId;
            _taskkDal.Update(taskk);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }


        public IResult Update(TaskkUpdateDto taskkUpdateDto)
        {
            Taskk taskk = _taskkDal.Get(t => t.TaskkId == taskkUpdateDto.TaskkId);
            //Taskk taskk = _mapper.Map<Taskk>(taskkUpdateDto);
            taskk.Info = taskkUpdateDto.Info;
            taskk.CaseId = taskkUpdateDto.CaseId;
            taskk.CreatorId = taskkUpdateDto.CustomerId;
            taskk.LastDate = taskkUpdateDto.LastDate;
            taskk.EndDate = taskkUpdateDto.EndDate;
            taskk.StartDate = taskkUpdateDto.StartDate;
            taskk.UserId = taskkUpdateDto.UserId;
            taskk.IsActive = taskkUpdateDto.IsActive;
            taskk.TaskTypeId = taskkUpdateDto.TaskTypeId;
            taskk.TaskStatusId = taskkUpdateDto.TaskStatusId;
            _taskkDal.Update(taskk);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
