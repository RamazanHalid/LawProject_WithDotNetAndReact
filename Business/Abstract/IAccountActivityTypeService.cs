using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.AccountActivityType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{

    public interface IAccountActivityTypeService
    {
        IDataResult<List<AccountActivityTypeGetDto>> GetAll();
        IDataResult<AccountActivityTypeGetDto> GetById(int id);
        IResult Add(AccountActivityTypeAddDto accountActivityTypeAddDto);
        IResult Update(AccountActivityTypeUpdateDto accountActivityTypeUpdateDto);
        IResult Delete(int id);
    }
}
