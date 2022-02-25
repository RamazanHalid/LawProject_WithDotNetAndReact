using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICaseStatusService
    {
        IDataResult<List<CaseStatusGetDto>> GetAll();
        IDataResult<List<CaseStatusGetDto>> GetAllActive();
        IDataResult<CaseStatusGetDto> GetById(int id);
        IResult Add(CaseStatusAddDto caseStatusAddDto);
        IResult Update(CaseStatusUpdateDto caseStatusUpdateDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
