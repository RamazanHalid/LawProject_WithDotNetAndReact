using Core.Utilities.Results;
using Entities.DTOs.EventTypeDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEventTypeService
    {
        IDataResult<List<EventTypeGetDto>> GetAll();
        IDataResult<EventTypeGetDto> GetById(int id);
        IResult Add(EventTypeAddDto eventTypeAddDto);
        IResult Update(EventTypeUpdateDto eventTypeUpdateDto);
        IResult Delete(int id);
    }
}
