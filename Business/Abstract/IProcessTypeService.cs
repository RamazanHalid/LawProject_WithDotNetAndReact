using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProcessTypeService
    {
        IDataResult<List<ProcessTypeDto>> GetAll(int isActive);
        IDataResult<ProcessTypeDto> GetById(int id);
        IResult Add(ProcessTypeDto processTypeDto);
        IResult Update(ProcessTypeDto processTypeDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
    }
}
