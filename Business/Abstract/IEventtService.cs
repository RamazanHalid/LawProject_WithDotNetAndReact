using Core.Utilities.Results;
using Entities.DTOs.EventtDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEventtService
    {
        IDataResult<List<EventtGetDto>> GetAll();
        IDataResult<List<EventtGetDto>> GetAllActive();
        IDataResult<EventtGetDto> GetById(int id);
        IResult Add(EventtAddDto eventtAddDto);
        IResult Update(EventtUpdateDto eventtUpdateDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
