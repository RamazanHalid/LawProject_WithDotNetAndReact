using Core.Utilities.Results;
using Entities.DTOs.AccountActivityTypeDtos;
using System.Collections.Generic;

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
