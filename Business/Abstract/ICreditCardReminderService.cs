
using Core.Utilities.Results;
using Entities.DTOs.CreditCardReminderDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICreditCardReminderService
    {
        IDataResult<List<CreditCardReminderGetDto>> GetAll();
        IDataResult<CreditCardReminderGetDetailsDto> GetById(int id);
        IResult Add(CreditCardReminderAddDto creditCardReminderAddDto);
        IResult Update(CreditCardReminderUpdateDto creditCardReminderDto);
        IDataResult<bool> CheckTheCardIsExist(string creditCardNo);
        IResult Delete(int id);
    }
}
