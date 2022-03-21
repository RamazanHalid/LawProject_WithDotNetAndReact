using Core.Utilities.Results;
using Entities.DTOs.AccountActivityDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAccountActivityService
    {
        IDataResult<List<AccountActivityGetDto>> GetAll();
        IDataResult<List<AccountActivityGetDto>> GetAllActive();
        IDataResult<AccountActivityGetDto> GetById(int id);
        IResult Add(AccountActivityAddDto accountActivityAddDto);
        IResult Update(AccountActivityUpdateDto accountActivityUpdateDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
    }
}
