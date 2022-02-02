using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICaseStatusService
    {
        IDataResult<List<CaseStatus>> GetAllByLicenceIdAndActivity(int licenceId, int isActive);
        IDataResult<CaseStatus> GetById(int id);
        IResult Add(CaseStatus caseStatus);
        IResult Update(CaseStatus caseStatus);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
