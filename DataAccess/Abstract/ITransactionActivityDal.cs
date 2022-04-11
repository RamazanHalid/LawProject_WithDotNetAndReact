using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ITransactionActivityDal : IEntityRepository<TransactionActivity>
    {
        List<TransactionActivity> GetAllWithInclude(Expression<Func<TransactionActivity, bool>> filter = null);
        TransactionActivity GetWithInclude(Expression<Func<TransactionActivity, bool>> filter);
        float GetSum(Expression<Func<TransactionActivity, float>> filterSum, Expression<Func<TransactionActivity, bool>> filter = null);
    }
}
