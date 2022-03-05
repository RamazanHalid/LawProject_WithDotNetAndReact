using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.CourtOfficeType;
using System;
using System.Collections.Generic;
using System.Text;

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
