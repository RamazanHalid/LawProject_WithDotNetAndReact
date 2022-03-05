using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITransactionActivitySubTypeService
    {
        IDataResult<List<TransactionActivitySubTypeDto>> GetAll();
        IDataResult<List<TransactionActivitySubTypeDto>> GetAllActive();
        IDataResult<TransactionActivitySubTypeDto> GetById(int id);
        IResult Add(TransactionActivitySubTypeDto transactionActivitySubType);
        IResult Update(TransactionActivitySubTypeDto transactionActivitySubType);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
