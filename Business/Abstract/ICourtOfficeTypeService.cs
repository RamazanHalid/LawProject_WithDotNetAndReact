using Core.Utilities.Results;
using Entities.DTOs.CourtOfficeTypeDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface ICourtOfficeTypeService
    {
        IDataResult<List<CourtOfficeTypeGetDto>> GetAll();
        IDataResult<CourtOfficeTypeGetDto> GetById(int id);
        IResult Add(CourtOfficeTypeAddDto courtOfficeTypeAddDto);
        IResult Update(CourtOfficeTypeUpdateDto courtOfficeTypeUpdateDto);
        IResult Delete(int id);
    }
}
