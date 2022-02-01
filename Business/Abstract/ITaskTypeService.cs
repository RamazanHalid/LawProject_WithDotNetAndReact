using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITaskTypeService
    {
        IDataResult<List<TaskType>> GetAll();
        IDataResult<TaskType> GetById(int id);
        IDataResult<List<TaskType>> GetAllByLicenceId(int licenceId);
        IResult Add(TaskType taskType);
        IResult Update(TaskType taskType);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
