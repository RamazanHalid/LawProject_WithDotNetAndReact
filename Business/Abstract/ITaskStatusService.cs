using Core.Utilities.Results;
using Entities.DTOs.TaskStatusDtos;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface ITaskStatusService
    {
        IDataResult<List<TaskStatusGetDto>> GetAll();
        IDataResult<TaskStatusGetDto> GetById(int id);
        IResult Add(TaskStatusAddDto taskStatusAddDto);
        IResult Update(TaskStatusUpdateDto taskStatusUpdateDto);
        IResult Delete(int id);
    }
}
