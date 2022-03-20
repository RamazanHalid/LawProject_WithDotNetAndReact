using Core.Utilities.Results;
using Entities.DTOs.ProcessTypeDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProcessTypeService
    {
        IDataResult<List<ProcessTypeGetDto>> GetAll();
        IDataResult<List<ProcessTypeGetDto>> GetAllActive();
        IDataResult<ProcessTypeGetDto> GetById(int id);
        IResult Add(ProcessTypeAddDto processTypeAddDto);
        IResult Update(ProcessTypeUpdateDto processTypeDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
    }
}
