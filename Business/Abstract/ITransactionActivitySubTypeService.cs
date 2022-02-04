using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITransactionActivitySubTypeService
    {
        IDataResult<List<TransactionActivitySubType>> GetAllByLicenceIdWithTransactionActivityType(int licenceId, int isActive);
        IDataResult<TransactionActivitySubType> GetByIdWithTransactionActivityType(int id);
        IResult Add(TransactionActivitySubType transactionActivitySubType);
        IResult Update(TransactionActivitySubType transactionActivitySubType);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
