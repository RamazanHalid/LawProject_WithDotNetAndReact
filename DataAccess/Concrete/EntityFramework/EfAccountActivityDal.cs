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
    public class EfAccountActivityDal : EfEntityRepositoryBase<AccountActivity, HukukContext>, IAccountActivityDal
    {
        public List<AccountActivity> GetAllWithInclude(Expression<Func<AccountActivity, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null ? context.Set<AccountActivity>()
                                 .Include(c => c.AccountActivityStatus)
                                 .Include(c => c.AccountActivityType).ToList()
                                : context.Set<AccountActivity>()
                                 .Where(filter)
                                 .Include(c => c.AccountActivityStatus)
                                 .Include(c => c.AccountActivityType).ToList();
            }
        }
        public AccountActivity GetWithInclude(Expression<Func<AccountActivity, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<AccountActivity>()
                                 .Include(c => c.AccountActivityStatus)
                                 .Include(c => c.AccountActivityType).SingleOrDefault(filter);
            }
        }
    }
}
