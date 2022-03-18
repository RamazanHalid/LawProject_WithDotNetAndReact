using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.TransactionActivitySubType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITransactionActivitySubTypeService
    {
        IDataResult<List<TransactionActivitySubTypeGetDto>> GetAll();
        IDataResult<List<TransactionActivitySubTypeGetDto>> GetAllActive();
        IDataResult<TransactionActivitySubTypeGetDto> GetById(int id);
        IResult Add(TransactionActivitySubTypeAddDto transactionActivitySubType);
        IResult Update(TransactionActivitySubTypeUpdateDto transactionActivitySubType);
        IDataResult<List<TransactionActivitySubTypeGetDto>> GetAllByTransactionActovotyId(int id);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
