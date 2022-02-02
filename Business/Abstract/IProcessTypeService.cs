using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProcessTypeService
    {
        IDataResult<List<ProcessType>> GetAllByLicenceIdAndActivity(int licenceId, int isActive);
        IDataResult<ProcessType> GetById(int id);
        IResult Add(ProcessType processType);
        IResult Update(ProcessType processType);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
    }
}
