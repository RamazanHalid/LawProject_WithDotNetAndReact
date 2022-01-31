using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{

    public interface ICourtOfficeTypeService
    {
        IDataResult<List<CourtOfficeType>> GetAll();
        IDataResult<CourtOfficeType> GetById(int id);
        IResult Add(CourtOfficeType courtOfficeType);
        IResult Update(CourtOfficeType courtOfficeType);
        IResult Delete(int id);
    }
}
