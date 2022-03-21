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
    public class EfTransactionActivityDal : EfEntityRepositoryBase<TransactionActivity, HukukContext>, ITransactionActivityDal
    {
        public List<TransactionActivity> GetAllWithInclude(Expression<Func<TransactionActivity, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null ? context.Set<TransactionActivity>()
                                 .Include(c => c.TransactionActivitySubType)
                                 .ThenInclude(c => c.TransactionActivityType)
                                 .Include(c => c.UserWhoAdd)
                                 .Include(c => c.WhoApproved)
                                 .ToList()
                                : context.Set<TransactionActivity>()
                                 .Where(filter)
                                 .Include(c => c.TransactionActivitySubType)
                                 .ThenInclude(c => c.TransactionActivityType)
                                 .Include(c => c.UserWhoAdd)
                                 .Include(c => c.WhoApproved).ToList();
            }
        }
        public TransactionActivity GetWithInclude(Expression<Func<TransactionActivity, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<TransactionActivity>()
                                .Include(c => c.TransactionActivitySubType)
                                 .ThenInclude(c => c.TransactionActivityType)
                                 .Include(c => c.UserWhoAdd) 
                                 .Include(c => c.WhoApproved) 
                                 .SingleOrDefault(filter)
                                 ;
            }
        }
    }
}
