using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface ITaskTypeService
    {
        IDataResult<List<TaskTypeGetDto>> GetAll(int isActive);
        IDataResult<TaskTypeGetDto> GetById(int id);
        IResult Add(TaskTypeAddDto taskTypeAddDto);
        IResult Update(TaskTypeUpdateDto taskTypeUpdateDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
    }
}
