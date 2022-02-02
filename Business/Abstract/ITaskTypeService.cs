using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITaskTypeService
    {
        IDataResult<List<TaskType>> GetAllByLicenceIdAndActivity(int licenceId, int isActive);
        IDataResult<TaskType> GetById(int id);
        IResult Add(TaskType taskType);
        IResult Update(TaskType taskType);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
