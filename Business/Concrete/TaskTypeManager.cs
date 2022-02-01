using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TaskTypeManager : ITaskTypeService
    {
        private ITaskTypeDal _taskTypeDal;

        public TaskTypeManager(ITaskTypeDal taskTypeDal)
        {
            _taskTypeDal = taskTypeDal;
        }

        public IResult Add(TaskType taskType)
        {
            _taskTypeDal.Add(taskType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult ChangeActivity(int id)
        {
            var taskType = _taskTypeDal.Get(tp => tp.TaskTypeId == id);
            if (taskType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            taskType.IsActive = !taskType.IsActive;
            var result = Update(taskType);
            if (!result.Success)
                return result;
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var taskType = _taskTypeDal.Get(tp => tp.TaskTypeId == id);
            if (taskType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _taskTypeDal.Delete(taskType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<TaskType>> GetAll()
        {
            return new SuccessDataResult<List<TaskType>>(_taskTypeDal.GetAll(), Messages.GetAllSuccessfuly);
        }

        public IDataResult<List<TaskType>> GetAllByLicenceId(int licenceId)
        {
            return new SuccessDataResult<List<TaskType>>(_taskTypeDal.GetAll(tp => tp.LicenceId == licenceId), Messages.GetAllByLicenceIdSuccessfuly);
        }

        public IDataResult<TaskType> GetById(int id)
        {
            var taskType = _taskTypeDal.Get(tp => tp.TaskTypeId == id);
            if (taskType == null)
                return new ErrorDataResult<TaskType>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<TaskType>(taskType, Messages.GetByIdSuccessfuly);
        }

        public IResult Update(TaskType taskType)
        {
            _taskTypeDal.Update(taskType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
