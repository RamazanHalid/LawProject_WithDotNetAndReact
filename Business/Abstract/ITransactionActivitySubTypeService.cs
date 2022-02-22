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
        IDataResult<List<TransactionActivitySubTypeDto>> GetAllByLicenceIdWithTransactionActivityType(int isActive);
        IDataResult<TransactionActivitySubTypeDto> GetByIdWithTransactionActivityType(int id);
        IResult Add(TransactionActivitySubTypeDto transactionActivitySubType);
        IResult Update(TransactionActivitySubTypeDto transactionActivitySubType);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
