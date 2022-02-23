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

    public interface ILicenceService
    {
        IDataResult<List<Licence>> GetAll();
        IDataResult<Licence> GetById(int id);
        IResult Add(LicenceAddDto licenceAddDto);
        IResult Update(Licence licence);
    }
}
