using Core.Utilities.Results;
using Entities.DTOs.AccountActivityStatusDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface IAccountActivityStatusService
    {
        IDataResult<List<AccountActivityStatusGetDto>> GetAll();
        IDataResult<AccountActivityStatusGetDto> GetById(int id);
        IResult Add(AccountActivityStatusAddDto accountActivityStatusAddDto);
        IResult Update(AccountActivityStatusUpdateDto accountActivityStatusUpdateDto);
        IResult Delete(int id);
    }
}
