using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CourtOffice;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICourtOfficeService
    {
        IDataResult<List<CourtOfficeGetDto>> GetAll();
        IDataResult<List<CourtOfficeGetDto>> GetAllActive();
        IDataResult<CourtOfficeGetDto> GetById(int id);
        IResult Add(CourtOfficeAddDto courtOfficeAddDto);
        IResult Update(CourtOfficeUpdateDto courtOfficeUpdateDto);
        IResult Delete(int id);
    }
}
