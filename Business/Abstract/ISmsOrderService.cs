using Core.Utilities.Results;
using Entities.DTOs.SmsOrderDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface ISmsOrderService
    {
        IDataResult<List<SmsOrderGetDto>> GetAll();
        IDataResult<SmsOrderGetDto> GetById(int id);
        IResult Add(SmsOrderAddDto smsOrderAddDto);
        IResult Update(SmsOrderUpdateDto smsOrderUpdateDto);
        IResult Delete(int id);
        IResult BuyTheSms(int smsOrderId);
    }
}
