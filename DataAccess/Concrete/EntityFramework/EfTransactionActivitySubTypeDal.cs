using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTransactionActivitySubTypeDal : EfEntityRepositoryBase<TransactionActivitySubType, HukukContext>, ITransactionActivitySubTypeDal
    {
        public List<TransactionActivitySubType> GetAllWithTransactionActivityType(Expression<Func<TransactionActivitySubType, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<TransactionActivitySubType>().Include(t => t.TransactionActivityType).ToList()
                    : context.Set<TransactionActivitySubType>().Where(filter).Include(t => t.TransactionActivityType).ToList();
            }
        }

        public TransactionActivitySubType GetWithTransactionActivityType(Expression<Func<TransactionActivitySubType, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<TransactionActivitySubType>().Include(t => t.TransactionActivityType).SingleOrDefault(filter);
            }
        }
    }
}
