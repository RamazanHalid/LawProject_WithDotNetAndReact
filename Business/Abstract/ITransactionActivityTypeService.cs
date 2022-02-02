using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITransactionActivityTypeService
    {
        IDataResult<List<TransactionActivityType>> GetAll();
        IDataResult<TransactionActivityType> GetById(int id);
        IResult Add(TransactionActivityType transactionActivityType);
        IResult Update(TransactionActivityType transactionActivityType);
        IResult Delete(int id);
    }
}
