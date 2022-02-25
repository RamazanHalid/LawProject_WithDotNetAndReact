using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.CaseType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICaseTypeService
    {
        IDataResult<List<CaseTypeGetDto>> GetAll();
        IDataResult<List<CaseTypeGetDto>> GetAllActive();
        IDataResult<CaseTypeGetDto> GetById(int id);
        IResult Add(CaseTypeAddDto caseTypeDto);
        IResult Update(CaseTypeUpdateDto caseTypeDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
    }
}
