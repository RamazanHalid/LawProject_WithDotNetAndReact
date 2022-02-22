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
        IDataResult<List<CaseStatusDto>> GetAllByLicenceIdAndActivity(int isActive);
        IDataResult<CaseStatusDto> GetById(int id);
        IResult Add(CaseStatusDto caseStatusDto);
        IResult Update(CaseStatusDto caseStatusDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
