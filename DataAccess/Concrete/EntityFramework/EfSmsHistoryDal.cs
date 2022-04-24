using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSmsHistoryDal : EfEntityRepositoryBase<SmsHistory, HukukContext>, ISmsHistoryDal
    {
        public List<SmsHistory> GetAllWithPagination(int pageNumber, int pageSize, Expression<Func<SmsHistory, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<SmsHistory>().Skip((pageNumber) * pageSize).Take(pageSize).ToList()
                    : context.Set<SmsHistory>().Skip((pageNumber) * pageSize).Take(pageSize).Where(filter).ToList();
            }
        }

    }
}
