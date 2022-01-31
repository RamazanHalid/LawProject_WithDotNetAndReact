using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICaseTypeService
    {
        IDataResult<List<CaseType>> GetAll();
        IDataResult<CaseType> GetById(int id);
        IResult Add(CaseType caseType);
        IResult Update(CaseType caseType);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
    }
}
