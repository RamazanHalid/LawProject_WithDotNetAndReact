using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICourtOfficeService
    {
        IDataResult<List<CourtOffice>> GetAll(int courtOfficeTypeId,int isActive);
        IDataResult<CourtOffice> GetById(int id);
        IResult Add(CourtOffice courtOffice);
        IResult Update(CourtOffice courtOffice);
        IResult Delete(int id);
    }
}
