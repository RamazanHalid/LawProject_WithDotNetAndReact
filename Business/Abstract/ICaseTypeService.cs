using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICaseTypeService
    {
        IDataResult<List<CaseTypeDto>> GetAll(int courtOfficeTypeId, int isActive);
        IDataResult<CaseTypeDto> GetById(int id);
        IResult Add(CaseTypeDto caseTypeDto);
        IResult Update(CaseTypeDto caseTypeDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
    }
}
