using Core.Utilities.Results;
using Entities.DTOs.SmsAccountDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISmsAccountService
    {
        IDataResult<List<SmsAccountGetDto>> GetAll();
        IDataResult<SmsAccountGetDto> GetById(int id);
        IResult Add(SmsAccountAddDto smsAccountAddDto);
        IResult Delete(int id);
        IResult IncreaseCountOfSms(int id, int count);

    }
}
