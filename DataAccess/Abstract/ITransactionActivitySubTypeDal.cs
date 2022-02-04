using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITransactionActivitySubTypeDal : IEntityRepository<TransactionActivitySubType>
    {
        List<TransactionActivitySubType> GetAllWithTransactionActivityType(Expression<Func<TransactionActivitySubType, bool>> filter = null);
        TransactionActivitySubType GetWithTransactionActivityType(Expression<Func<TransactionActivitySubType, bool>> filter);
    }
}
