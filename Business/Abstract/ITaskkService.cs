using Core.Utilities.Results;
using Entities.DTOs.TaskkDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface ITaskkService
    {
        IDataResult<List<TaskkGetDto>> GetAll();
        IDataResult<TaskkGetDto> GetById(int id);
        IResult Add(TaskkAddDto taskkAddDto);
        IResult Update(TaskkUpdateDto taskkUpdateDro);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
        IResult ChangeStatus(int id, int statusId);

    }
}
